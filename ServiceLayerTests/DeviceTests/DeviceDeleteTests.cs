using Entities.Elements;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.DeviceTests
{
    public class DeviceDeleteTests : DeviceTestBase
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenDeviceExists()
        {
            var device = SharedMockData.GetSingleDevice();
            DeviceRepositoryMock.Setup(r => r.GetByIdAsync(device.Id)).ReturnsAsync(device);
            DeviceRepositoryMock.Setup(r => r.Delete(It.IsAny<Device>()));

            var result = await Service.DeleteAsync(device.Id);

            result.Should().BeTrue();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenDeviceDoesNotExist()
        {
            DeviceRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Device not found"));

            var act = async () => await Service.DeleteAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallSaveChanges_WhenDeletionSucceeds()
        {
            var device = SharedMockData.GetSingleDevice();
            DeviceRepositoryMock.Setup(r => r.GetByIdAsync(device.Id)).ReturnsAsync(device);
            DeviceRepositoryMock.Setup(r => r.Delete(It.IsAny<Device>()));

            await Service.DeleteAsync(device.Id);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
