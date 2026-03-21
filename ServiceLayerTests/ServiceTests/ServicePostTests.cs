using BLL.DTO.Services.Service;
using Entities.Services;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.ServiceTests
{
    public class ServicePostTests : ServiceTestBase
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnServiceResponseDTO_WhenDataIsValid()
        {
            var dto = new ServiceCreateDTO
            {
                Name = "Nuevo Servicio",
                Description = "Descripcion del nuevo servicio de prueba",
                BasePrice = 80m,
                EstimatedTime = new TimeOnly(2, 0)
            };
            ServiceRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Service>())).Returns(Task.CompletedTask);

            var result = await Service.CreateAsync(dto);

            result.Should().NotBeNull();
            result.Should().BeOfType<ServiceResponseDTO>();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallSaveChanges_WhenServiceIsCreated()
        {
            var dto = new ServiceCreateDTO { Name = "Test Svc", Description = "Desc servicio test", BasePrice = 50m, EstimatedTime = new TimeOnly(1, 0) };
            ServiceRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Service>())).Returns(Task.CompletedTask);

            await Service.CreateAsync(dto);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
