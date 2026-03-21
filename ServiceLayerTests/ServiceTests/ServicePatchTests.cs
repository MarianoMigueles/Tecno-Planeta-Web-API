using Entities.Services;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.ServiceTests
{
    public class ServicePatchTests : ServiceTestBase
    {
        [Fact]
        public async Task UpdateBasePriceAsync_ShouldReturnUpdatedService_WhenServiceExists()
        {
            var service = SharedMockData.GetSingleService();
            ServiceRepositoryMock.Setup(r => r.UpdateBasePriceAsync(service.Id, 75m)).ReturnsAsync(service);

            var result = await Service.UpdateBasePriceAsync(service.Id, 75m);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateBasePriceAsync_ShouldThrowEntityNotFoundException_WhenServiceDoesNotExist()
        {
            ServiceRepositoryMock.Setup(r => r.UpdateBasePriceAsync(999, 75m))
                .ThrowsAsync(new EntityNotFoundException("Service not found"));

            var act = async () => await Service.UpdateBasePriceAsync(999, 75m);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task UpdateBasePriceAsync_ShouldThrowValidationException_WhenPriceIsNegative()
        {
            var service = SharedMockData.GetSingleService();

            var act = () => service.EditBasePrice(-1m);

            act.Should().Throw<Exception>();
        }

        [Fact]
        public async Task UpdateDescriptionAsync_ShouldReturnUpdatedService_WhenServiceExists()
        {
            var service = SharedMockData.GetSingleService();
            ServiceRepositoryMock.Setup(r => r.UpdateDescriptionAsync(service.Id, "Nueva descripcion")).ReturnsAsync(service);

            var result = await Service.UpdateDescriptionAsync(service.Id, "Nueva descripcion");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateDescriptionAsync_ShouldThrowEntityNotFoundException_WhenServiceDoesNotExist()
        {
            ServiceRepositoryMock.Setup(r => r.UpdateDescriptionAsync(999, "X"))
                .ThrowsAsync(new EntityNotFoundException("Service not found"));

            var act = async () => await Service.UpdateDescriptionAsync(999, "X");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task UpdateEstimatedTimeAsync_ShouldReturnUpdatedService_WhenTimeIsValid()
        {
            var service = SharedMockData.GetSingleService();
            var newTime = new TimeOnly(3, 0);
            ServiceRepositoryMock.Setup(r => r.UpdateEstimatedTimeAsync(service.Id, newTime)).ReturnsAsync(service);

            var result = await Service.UpdateEstimatedTimeAsync(service.Id, newTime);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateEstimatedTimeAsync_ShouldThrowValidationException_WhenTimeIsTheSame()
        {
            var service = SharedMockData.GetSingleService();

            var act = () => service.EditEstimatedTime(service.EstimatedTime);

            act.Should().Throw<Exception>();
        }

        [Fact]
        public async Task UpdateNameAsync_ShouldReturnUpdatedService_WhenServiceExists()
        {
            var service = SharedMockData.GetSingleService();
            ServiceRepositoryMock.Setup(r => r.UpdateNameAsync(service.Id, "Nuevo Nombre")).ReturnsAsync(service);

            var result = await Service.UpdateNameAsync(service.Id, "Nuevo Nombre");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateNameAsync_ShouldThrowEntityNotFoundException_WhenServiceDoesNotExist()
        {
            ServiceRepositoryMock.Setup(r => r.UpdateNameAsync(999, "X"))
                .ThrowsAsync(new EntityNotFoundException("Service not found"));

            var act = async () => await Service.UpdateNameAsync(999, "X");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }
    }
}
