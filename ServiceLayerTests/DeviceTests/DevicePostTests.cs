using BLL.DTO.Device;
using Entities.Elements;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.DeviceTests
{
    public class DevicePostTests : DeviceTestBase
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnDeviceResponseDTO_WhenDataIsValid()
        {
            var dto = new DeviceCreateDTO
            {
                Type = Entities.Elements.Enums.EDeviceType.PHONE,
                Brand = "Samsung",
                Model = "Galaxy A54",
                SerialNumber = "SN-TEST-001"
            };
            DeviceRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Device>())).Returns(Task.CompletedTask);

            var result = await Service.CreateAsync(dto);

            result.Should().NotBeNull();
            result.Should().BeOfType<DeviceResponseDTO>();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallSaveChanges_WhenDeviceIsCreated()
        {
            var dto = new DeviceCreateDTO { Type = Entities.Elements.Enums.EDeviceType.PC, Brand = "Dell", Model = "Optiplex", SerialNumber = "SN-002" };
            DeviceRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Device>())).Returns(Task.CompletedTask);

            await Service.CreateAsync(dto);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
