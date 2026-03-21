using Entities.Services;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.ServiceTests
{
    public class ServiceGetTests : ServiceTestBase
    {
        [Fact]
        public async Task GetAllByPriceRangeAsync_ShouldReturnServices_WhenPricesAreInRange()
        {
            var services = SharedMockData.GetMockServices().Where(s => s.BasePrice >= 30m && s.BasePrice <= 60m).ToList();
            ServiceRepositoryMock.Setup(r => r.GetAllByRangeOfPriceAsync(30m, 60m)).ReturnsAsync(services);

            var result = await Service.GetAllByPriceRangeAsync(30m, 60m);

            result.Should().HaveCount(services.Count);
            result.Should().OnlyContain(s => s.BasePrice >= 30m && s.BasePrice <= 60m);
        }

        [Fact]
        public async Task GetAllByPriceRangeAsync_ShouldReturnEmptyList_WhenNoServicesInRange()
        {
            ServiceRepositoryMock.Setup(r => r.GetAllByRangeOfPriceAsync(9000m, 9999m)).ReturnsAsync(new List<Service>());

            var result = await Service.GetAllByPriceRangeAsync(9000m, 9999m);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetByNameAsync_ShouldReturnService_WhenNameExists()
        {
            var service = SharedMockData.GetSingleService();
            ServiceRepositoryMock.Setup(r => r.GetByNameAsync(service.Name)).ReturnsAsync(service);

            var result = await Service.GetByNameAsync(service.Name);

            result.Should().NotBeNull();
            result.Name.Should().Be(service.Name);
        }

        [Fact]
        public async Task GetByNameAsync_ShouldThrowEntityNotFoundException_WhenNameDoesNotExist()
        {
            ServiceRepositoryMock.Setup(r => r.GetByNameAsync("Inexistente"))
                .ThrowsAsync(new EntityNotFoundException("Service not found"));

            var act = async () => await Service.GetByNameAsync("Inexistente");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task GetByPeriotOfEstimatedTimeAsync_ShouldReturnServices_WhenTimeIsInRange()
        {
            var services = SharedMockData.GetMockServices();
            var min = new TimeOnly(0, 30);
            var max = new TimeOnly(3, 0);
            ServiceRepositoryMock.Setup(r => r.GetByPeriotOfEstimatedTimeAsync(min, max)).ReturnsAsync(services);

            var result = await Service.GetByPeriotOfEstimatedTimeAsync(min, max);

            result.Should().HaveCount(services.Count);
        }

        [Fact]
        public async Task GetByPeriotOfEstimatedTimeAsync_ShouldReturnEmptyList_WhenNoServicesInRange()
        {
            var min = new TimeOnly(23, 0);
            var max = new TimeOnly(23, 59);
            ServiceRepositoryMock.Setup(r => r.GetByPeriotOfEstimatedTimeAsync(min, max)).ReturnsAsync(new List<Service>());

            var result = await Service.GetByPeriotOfEstimatedTimeAsync(min, max);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllServices()
        {
            var services = SharedMockData.GetMockServices();
            ServiceRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(services);

            var result = await Service.GetAllAsync();

            result.Should().HaveCount(services.Count);
        }
    }
}
