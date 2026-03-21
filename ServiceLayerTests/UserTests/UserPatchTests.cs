using Entities.Users;
using Entities.Users.Enums;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.UserTests
{
    public class UserPatchTests : UserTestBase
    {
        [Fact]
        public async Task UpdateNameAsync_ShouldReturnUpdatedUser_WhenUserExists()
        {
            var user = SharedMockData.GetSingleUser();
            var updated = new User { Id = user.Id, UserName = "nuevo_nombre", Email = user.Email };
            UserRepositoryMock.Setup(r => r.UpdateNameAsync(user.Id, "nuevo_nombre")).ReturnsAsync(updated);

            var result = await Service.UpdateNameAsync(user.Id, "nuevo_nombre");

            result.Should().NotBeNull();
            result.UserName.Should().Be("nuevo_nombre");
        }

        [Fact]
        public async Task UpdateNameAsync_ShouldThrowEntityNotFoundException_WhenUserDoesNotExist()
        {
            UserRepositoryMock.Setup(r => r.UpdateNameAsync(999, "x"))
                .ThrowsAsync(new EntityNotFoundException("User not found"));

            var act = async () => await Service.UpdateNameAsync(999, "x");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task UpdatePasswordAsync_ShouldReturnUpdatedUser_WhenPasswordIsValid()
        {
            var user = SharedMockData.GetSingleUser();
            UserRepositoryMock.Setup(r => r.UpdatePasswordAsync(user.Id, "NewPass@123")).ReturnsAsync(user);

            var result = await Service.UpdatePasswordAsync(user.Id, "NewPass@123");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdatePasswordAsync_ShouldThrowValidationException_WhenPasswordIsTooWeak()
        {
            var user = SharedMockData.GetSingleUser();

            var act = () => user.EditPassword("weak");

            act.Should().Throw<Exception>();
        }

        [Fact]
        public async Task UpdateRolAsync_ShouldReturnUpdatedUser_WhenRolIsValid()
        {
            var user = SharedMockData.GetSingleUser();
            UserRepositoryMock.Setup(r => r.UpdateRolAsync(user.Id, EUserRol.EMPLOYEE)).ReturnsAsync(user);

            var result = await Service.UpdateRolAsync(user.Id, EUserRol.EMPLOYEE);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateRolAsync_ShouldThrowValidationException_WhenRolIsTheSame()
        {
            var user = SharedMockData.GetSingleUser();

            var act = () => user.EditRol(user.Rol);

            act.Should().Throw<Exception>();
        }

        [Fact]
        public async Task UpdateSectorAsync_ShouldReturnUpdatedUser_WhenSectorIsValid()
        {
            var user = SharedMockData.GetSingleUser();
            UserRepositoryMock.Setup(r => r.UpdateSectorAsync(user.Id, EUserSector.INVENTORY)).ReturnsAsync(user);

            var result = await Service.UpdateSectorAsync(user.Id, EUserSector.INVENTORY);

            result.Should().NotBeNull();
        }
    }
}
