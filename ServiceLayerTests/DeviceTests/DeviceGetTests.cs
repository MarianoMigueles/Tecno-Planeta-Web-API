using Entities.Elements;
using Entities.Elements.Enums;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.DeviceTests
{
    public class DeviceGetTests : DeviceTestBase
    {
        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnDevices_WhenCustomerExists()
        {
            var devices = SharedMockData.GetMockDevices();
            DeviceRepositoryMock.Setup(r => r.GetByCustomerNameAsync("Juan Perez")).ReturnsAsync(devices);

            var result = await Service.GetByCustomerNameAsync("Juan Perez");

            result.Should().HaveCount(devices.Count);
            DeviceRepositoryMock.Verify(r => r.GetByCustomerNameAsync("Juan Perez"), Times.Once);
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnEmptyList_WhenCustomerHasNoDevices()
        {
            DeviceRepositoryMock.Setup(r => r.GetByCustomerNameAsync("Sin Dispositivos")).ReturnsAsync(new List<Device>());

            var result = await Service.GetByCustomerNameAsync("Sin Dispositivos");

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllByTypeAsync_ShouldReturnDevices_WhenTypeExists()
        {
            var phones = SharedMockData.GetMockDevices().Where(d => d.Type == EDeviceType.PHONE).ToList();
            DeviceRepositoryMock.Setup(r => r.GetAllByTypeAsync(EDeviceType.PHONE)).ReturnsAsync(phones);

            var result = await Service.GetAllByTypeAsync(EDeviceType.PHONE);

            result.Should().HaveCount(phones.Count);
        }

        [Fact]
        public async Task GetAllByTypeAsync_ShouldReturnEmptyList_WhenNoDevicesMatchType()
        {
            DeviceRepositoryMock.Setup(r => r.GetAllByTypeAsync(EDeviceType.TABLET)).ReturnsAsync(new List<Device>());

            var result = await Service.GetAllByTypeAsync(EDeviceType.TABLET);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllByModelAsync_ShouldReturnDevices_WhenModelExists()
        {
            var devices = SharedMockData.GetMockDevices().Where(d => d.Model == "Galaxy S23").ToList();
            DeviceRepositoryMock.Setup(r => r.GetAllByModelAsync("Galaxy S23")).ReturnsAsync(devices);

            var result = await Service.GetAllByModelAsync("Galaxy S23");

            result.Should().HaveCount(devices.Count);
        }

        [Fact]
        public async Task GetAllByModelAsync_ShouldReturnEmptyList_WhenModelDoesNotExist()
        {
            DeviceRepositoryMock.Setup(r => r.GetAllByModelAsync("ModeloInexistente")).ReturnsAsync(new List<Device>());

            var result = await Service.GetAllByModelAsync("ModeloInexistente");

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllByBrandAsync_ShouldReturnDevices_WhenBrandExists()
        {
            var devices = SharedMockData.GetMockDevices().Where(d => d.Brand == "Samsung").ToList();
            DeviceRepositoryMock.Setup(r => r.GetAllByBrandAsync("Samsung")).ReturnsAsync(devices);

            var result = await Service.GetAllByBrandAsync("Samsung");

            result.Should().HaveCount(devices.Count);
        }

        [Fact]
        public async Task GetAllByBrandAsync_ShouldReturnEmptyList_WhenBrandDoesNotExist()
        {
            DeviceRepositoryMock.Setup(r => r.GetAllByBrandAsync("MarcaInexistente")).ReturnsAsync(new List<Device>());

            var result = await Service.GetAllByBrandAsync("MarcaInexistente");

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDevice_WhenIdExists()
        {
            var device = SharedMockData.GetSingleDevice();
            DeviceRepositoryMock.Setup(r => r.GetByIdAsync(device.Id)).ReturnsAsync(device);

            var result = await Service.GetByIdAsync(device.Id);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowEntityNotFoundException_WhenIdDoesNotExist()
        {
            DeviceRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Device not found"));

            var act = async () => await Service.GetByIdAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllDevices()
        {
            var devices = SharedMockData.GetMockDevices();
            DeviceRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(devices);

            var result = await Service.GetAllAsync();

            result.Should().HaveCount(devices.Count);
        }
    }
}
