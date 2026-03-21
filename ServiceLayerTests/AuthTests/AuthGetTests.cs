using BLL.DTO.Users.Login;
using Exeptions;
using FluentAssertions;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace ServiceLayerTests.AuthTests
{
    public class AuthGetTests : AuthTestBase
    {
        // ── Login exitoso ────────────────────────────────────────────
        [Fact]
        public async Task LoginAsync_ShouldReturnJwtToken_WhenCredentialsAreValid()
        {
            var plainPassword = "Admin@1234";
            var user = CreateUserWithHashedPassword(plainPassword);

            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(user.Email))
                .ReturnsAsync(user);

            var request = new LoginRequestDTO { Email = user.Email, Password = plainPassword };

            var token = await Service.LoginAsync(request);

            token.Should().NotBeNullOrWhiteSpace();
            // Verificar que es un JWT válido de 3 partes
            token.Split('.').Should().HaveCount(3);
        }

        [Fact]
        public async Task LoginAsync_ShouldGenerateTokenWithCorrectClaims()
        {
            var plainPassword = "Admin@1234";
            var user = CreateUserWithHashedPassword(plainPassword);

            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(user.Email))
                .ReturnsAsync(user);

            var token = await Service.LoginAsync(new LoginRequestDTO { Email = user.Email, Password = plainPassword });

            var handler    = new JwtSecurityTokenHandler();
            var parsedToken = handler.ReadJwtToken(token);

            parsedToken.Claims.Should().Contain(c => c.Type == JwtRegisteredClaimNames.Sub);
            parsedToken.Claims.Should().Contain(c => c.Type == JwtRegisteredClaimNames.Email);
            parsedToken.Claims.Should().Contain(c => c.Value == user.Email);
        }

        [Fact]
        public async Task LoginAsync_ShouldGenerateTokenWithExpiration()
        {
            var plainPassword = "Admin@1234";
            var user = CreateUserWithHashedPassword(plainPassword);

            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(user.Email))
                .ReturnsAsync(user);

            var token = await Service.LoginAsync(new LoginRequestDTO { Email = user.Email, Password = plainPassword });

            var parsedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            parsedToken.ValidTo.Should().BeAfter(DateTime.UtcNow);
            // El servicio configura 5 horas, verificamos que expire en aprox ese rango
            parsedToken.ValidTo.Should().BeBefore(DateTime.UtcNow.AddHours(6));
        }

        [Fact]
        public async Task LoginAsync_ShouldGenerateTokenWithUserRole()
        {
            var plainPassword = "Admin@1234";
            var user = CreateUserWithHashedPassword(plainPassword);

            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(user.Email))
                .ReturnsAsync(user);

            var token = await Service.LoginAsync(new LoginRequestDTO { Email = user.Email, Password = plainPassword });

            var parsedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var roleClaim   = parsedToken.Claims.FirstOrDefault(c => c.Type == "role" || c.Type.EndsWith("/role"));

            roleClaim.Should().NotBeNull();
            roleClaim!.Value.Should().Be(user.Rol.ToString());
        }

        // ── Login fallido ────────────────────────────────────────────
        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenUserDoesNotExist()
        {
            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync("noexiste@test.com"))
                .ReturnsAsync((Entities.Users.User)null!);

            var request = new LoginRequestDTO { Email = "noexiste@test.com", Password = "Password@1" };

            var act = async () => await Service.LoginAsync(request);

            await act.Should().ThrowAsync<Exception>()
                .WithMessage("*Incorrect*");
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenPasswordIsIncorrect()
        {
            var user = CreateUserWithHashedPassword("CorrectPass@1");

            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(user.Email))
                .ReturnsAsync(user);

            var request = new LoginRequestDTO { Email = user.Email, Password = "WrongPass@9" };

            var act = async () => await Service.LoginAsync(request);

            await act.Should().ThrowAsync<Exception>()
                .WithMessage("*Incorrect*");
        }

        [Fact]
        public async Task LoginAsync_ShouldNotRevealWhetherUserExistsOrPasswordIsWrong()
        {
            // Seguridad: ambos casos de fallo deben devolver el mismo mensaje
            // para no filtrar si el email existe o no en la base
            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((Entities.Users.User)null!);

            var actNoUser = async () =>
                await Service.LoginAsync(new LoginRequestDTO { Email = "x@x.com", Password = "Pass@1234" });

            var user = CreateUserWithHashedPassword("RealPass@1");
            UserRepositoryMock
                .Setup(r => r.GetByEmailAsync(user.Email))
                .ReturnsAsync(user);

            var actBadPass = async () =>
                await Service.LoginAsync(new LoginRequestDTO { Email = user.Email, Password = "WrongPass@9" });

            var exNoUser  = await Record.ExceptionAsync(actNoUser);
            var exBadPass = await Record.ExceptionAsync(actBadPass);

            exNoUser!.Message.Should().Be(exBadPass!.Message);
        }
    }
}
