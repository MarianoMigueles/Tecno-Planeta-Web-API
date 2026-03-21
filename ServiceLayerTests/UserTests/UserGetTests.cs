using Entities.Users;
using Entities.Users.Enums;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.UserTests
{
    public class UserGetTests : UserTestBase
    {
        [Fact]
        public async Task GetByNameAsync_ShouldReturnUser_WhenNameExists()
        {
            var user = SharedMockData.GetSingleUser();
            UserRepositoryMock.Setup(r => r.GetByNameAsync(user.UserName)).ReturnsAsync(user);

            var result = await Service.GetByNameAsync(user.UserName);

            result.Should().NotBeNull();
            result.UserName.Should().Be(user.UserName);
        }

        [Fact]
        public async Task GetByNameAsync_ShouldThrowEntityNotFoundException_WhenUserDoesNotExist()
        {
            UserRepositoryMock.Setup(r => r.GetByNameAsync("inexistente"))
                .ThrowsAsync(new EntityNotFoundException("User not found"));

            var act = async () => await Service.GetByNameAsync("inexistente");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task GetAllBySectorAsync_ShouldReturnUsers_WhenSectorExists()
        {
            var users = SharedMockData.GetMockUsers();
            UserRepositoryMock.Setup(r => r.GetAllBySectorAsync(EUserSector.SALES)).ReturnsAsync(users);

            var result = await Service.GetAllBySectorAsync(EUserSector.SALES);

            result.Should().HaveCount(users.Count);
        }

        [Fact]
        public async Task GetAllBySectorAsync_ShouldReturnEmptyList_WhenNoUsersInSector()
        {
            UserRepositoryMock.Setup(r => r.GetAllBySectorAsync(EUserSector.REPAIR)).ReturnsAsync(new List<User>());

            var result = await Service.GetAllBySectorAsync(EUserSector.REPAIR);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllUsers()
        {
            var users = SharedMockData.GetMockUsers();
            UserRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

            var result = await Service.GetAllAsync();

            result.Should().HaveCount(users.Count);
        }
    }
}
