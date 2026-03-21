using Entities.Services;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.RepairTests
{
    public class RepairGetTests : RepairTestBase
    {
        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnRepairs_WhenCustomerExists()
        {
            var repairs = SharedMockData.GetMockRepairs();
            RepairRepositoryMock.Setup(r => r.GetByCustomerNameAsync("Juan Perez")).ReturnsAsync(repairs);

            var result = await Service.GetByCustomerNameAsync("Juan Perez");

            result.Should().NotBeNull().And.HaveCount(repairs.Count);
            RepairRepositoryMock.Verify(r => r.GetByCustomerNameAsync("Juan Perez"), Times.Once);
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnEmptyList_WhenCustomerHasNoRepairs()
        {
            RepairRepositoryMock.Setup(r => r.GetByCustomerNameAsync("Sin Reparaciones")).ReturnsAsync(new List<Repair>());

            var result = await Service.GetByCustomerNameAsync("Sin Reparaciones");

            result.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task GetByEntryDateAsync_ShouldReturnRepairs_WhenDateMatches()
        {
            var repairs = SharedMockData.GetMockRepairs();
            var date = DateTime.UtcNow;
            RepairRepositoryMock.Setup(r => r.GetByEntryDateAsync(date)).ReturnsAsync(repairs);

            var result = await Service.GetByEntryDateAsync(date);

            result.Should().HaveCount(repairs.Count);
        }

        [Fact]
        public async Task GetByEntryDateAsync_ShouldReturnEmptyList_WhenNoRepairsMatchDate()
        {
            var date = new DateTime(2000, 1, 1);
            RepairRepositoryMock.Setup(r => r.GetByEntryDateAsync(date)).ReturnsAsync(new List<Repair>());

            var result = await Service.GetByEntryDateAsync(date);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetByPeriodOfEntryDateAsync_ShouldReturnRepairs_WhenDatesAreValid()
        {
            var repairs = SharedMockData.GetMockRepairs();
            var min = DateTime.UtcNow.AddDays(-30);
            var max = DateTime.UtcNow;
            RepairRepositoryMock.Setup(r => r.GetByPeriodOfEntryDateAsync(min, max)).ReturnsAsync(repairs);

            var result = await Service.GetByPeriodOfEntryDateAsync(min, max);

            result.Should().HaveCount(repairs.Count);
        }

        [Fact]
        public async Task GetByPeriodOfEntryDateAsync_ShouldReturnEmptyList_WhenNoRepairsInRange()
        {
            var min = new DateTime(2000, 1, 1);
            var max = new DateTime(2000, 12, 31);
            RepairRepositoryMock.Setup(r => r.GetByPeriodOfEntryDateAsync(min, max)).ReturnsAsync(new List<Repair>());

            var result = await Service.GetByPeriodOfEntryDateAsync(min, max);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllRepairs()
        {
            var repairs = SharedMockData.GetMockRepairs();
            RepairRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(repairs);

            var result = await Service.GetAllAsync();

            result.Should().HaveCount(repairs.Count);
        }
    }
}
