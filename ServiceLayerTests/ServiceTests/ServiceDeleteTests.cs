using Entities.Services;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.ServiceTests
{
    public class ServiceDeleteTests : ServiceTestBase
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenServiceExists()
        {
            var service = SharedMockData.GetSingleService();
            ServiceRepositoryMock.Setup(r => r.GetByIdAsync(service.Id)).ReturnsAsync(service);
            ServiceRepositoryMock.Setup(r => r.Delete(It.IsAny<Service>()));

            var result = await Service.DeleteAsync(service.Id);

            result.Should().BeTrue();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenServiceDoesNotExist()
        {
            ServiceRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Service not found"));

            var act = async () => await Service.DeleteAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallSaveChanges_WhenDeletionSucceeds()
        {
            var service = SharedMockData.GetSingleService();
            ServiceRepositoryMock.Setup(r => r.GetByIdAsync(service.Id)).ReturnsAsync(service);
            ServiceRepositoryMock.Setup(r => r.Delete(It.IsAny<Service>()));

            await Service.DeleteAsync(service.Id);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
