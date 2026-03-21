using BLL.DTO.Users.Login;
using BLL.DTO.Users.User;
using Entities.Users;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.AuthTests
{
    public class AuthPutTests : AuthTestBase
    {
        private static RegisterRequestDTO ValidRegisterRequest() => new()
        {
            UserName = "nuevo_usuario",
            Email    = "nuevo@tecno.com",
            Password = "NuevoPass@1234",
            Rol      = Entities.Users.Enums.EUserRol.EMPLOYEE,
            Sector   = Entities.Users.Enums.EUserSector.SALES
        };

        [Fact]
        public async Task RegisterAsync_ShouldReturnUserResponseDTO_WhenDataIsValid()
        {
            UserRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            var result = await Service.RegisterAsync(ValidRegisterRequest());

            result.Should().NotBeNull();
            result.Should().BeOfType<UserResponseDTO>();
        }

        [Fact]
        public async Task RegisterAsync_ShouldCallUnitOfWorkSave_WhenUserIsCreated()
        {
            UserRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            await Service.RegisterAsync(ValidRegisterRequest());

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task RegisterAsync_ShouldHashPassword_BeforeSavingUser()
        {
            User? capturedUser = null;
            UserRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<User>()))
                .Callback<User>(u => capturedUser = u)
                .Returns(Task.CompletedTask);

            var request = ValidRegisterRequest();
            await Service.RegisterAsync(request);

            capturedUser.Should().NotBeNull();
            // El password guardado debe ser un hash BCrypt (empieza con $2)
            capturedUser!.Password.Should().StartWith("$2");
            // Y no debe ser el password en texto plano
            capturedUser.Password.Should().NotBe(request.Password);
        }

        [Fact]
        public async Task RegisterAsync_ShouldCallCreateAsync_OnUserRepository()
        {
            UserRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            await Service.RegisterAsync(ValidRegisterRequest());

            UserRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task RegisterAsync_ShouldThrowException_WhenRepositoryFails()
        {
            UserRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<User>()))
                .ThrowsAsync(new DatabaseOperationException("DB error"));

            var act = async () => await Service.RegisterAsync(ValidRegisterRequest());

            await act.Should().ThrowAsync<DatabaseOperationException>();
        }

        [Fact]
        public async Task RegisterAsync_ShouldStoreHashThatVerifiesAgainstOriginalPassword()
        {
            User? capturedUser = null;
            UserRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<User>()))
                .Callback<User>(u => capturedUser = u)
                .Returns(Task.CompletedTask);

            var request = ValidRegisterRequest();
            await Service.RegisterAsync(request);

            // El hash guardado debe poder verificarse con BCrypt
            var isValid = BCrypt.Net.BCrypt.Verify(request.Password, capturedUser!.Password);
            isValid.Should().BeTrue();
        }
    }
}
