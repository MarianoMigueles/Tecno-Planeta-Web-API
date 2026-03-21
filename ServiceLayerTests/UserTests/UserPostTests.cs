using BLL.DTO.Users.User;
using Entities.Users;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.UserTests
{
    public class UserPostTests : UserTestBase
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnUserResponseDTO_WhenDataIsValid()
        {
            var dto = new UserCreateDTO { UserName = "test_user", Password = "Test@1234" };
            UserRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var result = await Service.CreateAsync(dto);

            result.Should().NotBeNull();
            result.Should().BeOfType<UserResponseDTO>();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallSaveChanges_WhenUserIsCreated()
        {
            var dto = new UserCreateDTO { UserName = "test_user2", Password = "Test@5678" };
            UserRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            await Service.CreateAsync(dto);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
