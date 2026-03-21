using Entities.Users;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.UserTests
{
    public class UserDeleteTests : UserTestBase
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            var user = SharedMockData.GetSingleUser();
            UserRepositoryMock.Setup(r => r.GetByIdAsync(user.Id)).ReturnsAsync(user);
            UserRepositoryMock.Setup(r => r.Delete(It.IsAny<User>()));

            var result = await Service.DeleteAsync(user.Id);

            result.Should().BeTrue();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenUserDoesNotExist()
        {
            UserRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("User not found"));

            var act = async () => await Service.DeleteAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallSaveChanges_WhenDeletionSucceeds()
        {
            var user = SharedMockData.GetSingleUser();
            UserRepositoryMock.Setup(r => r.GetByIdAsync(user.Id)).ReturnsAsync(user);
            UserRepositoryMock.Setup(r => r.Delete(It.IsAny<User>()));

            await Service.DeleteAsync(user.Id);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
