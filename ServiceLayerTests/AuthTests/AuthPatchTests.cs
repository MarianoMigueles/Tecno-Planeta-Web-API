using BLL.DTO.Users.Login;
using FluentAssertions;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace ServiceLayerTests.AuthTests
{
    /// <summary>
    /// Verifica propiedades del token JWT generado por LoginAsync.
    /// </summary>
    public class AuthPatchTests : AuthTestBase
    {
        [Fact]
        public async Task LoginAsync_ShouldGenerateTokenWithValidIssuer()
        {
            var plainPassword = "Admin@1234";
            var user = CreateUserWithHashedPassword(plainPassword);
            UserRepositoryMock.Setup(r => r.GetByEmailAsync(user.Email)).ReturnsAsync(user);

            var token       = await Service.LoginAsync(new LoginRequestDTO { Email = user.Email, Password = plainPassword });
            var parsedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            parsedToken.Issuer.Should().Be("TecnoPlanetaTestIssuer");
        }

        [Fact]
        public async Task LoginAsync_ShouldGenerateTokenWithValidAudience()
        {
            var plainPassword = "Admin@1234";
            var user = CreateUserWithHashedPassword(plainPassword);
            UserRepositoryMock.Setup(r => r.GetByEmailAsync(user.Email)).ReturnsAsync(user);

            var token       = await Service.LoginAsync(new LoginRequestDTO { Email = user.Email, Password = plainPassword });
            var parsedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            parsedToken.Audiences.Should().Contain("TecnoPlanetaTestAudience");
        }

        [Fact]
        public async Task LoginAsync_ShouldGenerateUniqueTokenOnEachCall()
        {
            var plainPassword = "Admin@1234";
            var user = CreateUserWithHashedPassword(plainPassword);
            UserRepositoryMock.Setup(r => r.GetByEmailAsync(user.Email)).ReturnsAsync(user);

            var request = new LoginRequestDTO { Email = user.Email, Password = plainPassword };
            var token1  = await Service.LoginAsync(request);
            var token2  = await Service.LoginAsync(request);

            // Cada token debe tener un JTI distinto (Guid único por llamada)
            var jti1 = new JwtSecurityTokenHandler().ReadJwtToken(token1).Id;
            var jti2 = new JwtSecurityTokenHandler().ReadJwtToken(token2).Id;

            jti1.Should().NotBe(jti2);
        }
    }
}
