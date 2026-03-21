using BLL.DTO.Services.Repair;
using Entities.Services;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.RepairTests
{
    public class RepairPostTests : RepairTestBase
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnRepairResponseDTO_WhenDataIsValid()
        {
            var dto = new RepairCreateDTO
            {
                Cost = 150m,
                ExitDate = DateTime.UtcNow.AddDays(3),
                EntryDate = DateTime.UtcNow,
                RepairStatus = Entities.Services.Enums.ERepairStatus.PENDING,
                Notes = "Pantalla rota",
                DeviceId = 1,
                DeviceType = Entities.Elements.Enums.EDeviceType.PHONE,
                DeviceBrand = "Samsung",
                OwnerId = 1,
                OwnerName = "Juan Perez",
                DeviceModel = "Galaxy S23",
                DeviceSerialNumber = "SN-001"
            };
            RepairRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Repair>())).Returns(Task.CompletedTask);

            var result = await Service.CreateAsync(dto);

            result.Should().NotBeNull();
            result.Should().BeOfType<RepairResponseDTO>();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallSaveChanges_WhenRepairIsCreated()
        {
            var dto = new RepairCreateDTO
            {
                Cost = 50m, ExitDate = DateTime.UtcNow.AddDays(1), EntryDate = DateTime.UtcNow,
                RepairStatus = Entities.Services.Enums.ERepairStatus.PENDING,
                DeviceId = 1, DeviceType = Entities.Elements.Enums.EDeviceType.PC,
                DeviceBrand = "Dell", OwnerId = 1, OwnerName = "Test", DeviceModel = "XPS", DeviceSerialNumber = "SN-002"
            };
            RepairRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Repair>())).Returns(Task.CompletedTask);

            await Service.CreateAsync(dto);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
