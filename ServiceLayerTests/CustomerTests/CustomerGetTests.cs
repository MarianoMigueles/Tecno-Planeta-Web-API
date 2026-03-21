using Entities.Users;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.CustomerTests
{
    public class CustomerGetTests : CustomerTestBase
    {
        // ── GetByName ────────────────────────────────────────────────
        [Fact]
        public async Task GetByNameAsync_ShouldReturnCustomer_WhenNameExists()
        {
            var customer = SharedMockData.GetSingleCustomer();
            CustomerRepositoryMock.Setup(r => r.GetByNameAsync(customer.Name)).ReturnsAsync(customer);

            var result = await Service.GetByNameAsync(customer.Name);

            result.Should().NotBeNull();
            result.Name.Should().Be(customer.Name);
            CustomerRepositoryMock.Verify(r => r.GetByNameAsync(customer.Name), Times.Once);
        }

        [Fact]
        public async Task GetByNameAsync_ShouldThrowEntityNotFoundException_WhenNameDoesNotExist()
        {
            CustomerRepositoryMock.Setup(r => r.GetByNameAsync("Inexistente"))
                .ThrowsAsync(new EntityNotFoundException("Customer not found"));

            var act = async () => await Service.GetByNameAsync("Inexistente");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        // ── GetByPhone ───────────────────────────────────────────────
        [Fact]
        public async Task GetByPhoneAsync_ShouldReturnCustomer_WhenPhoneExists()
        {
            var customer = SharedMockData.GetSingleCustomer();
            CustomerRepositoryMock.Setup(r => r.GetByPhoneAsync(customer.Phone)).ReturnsAsync(customer);

            var result = await Service.GetByPhoneAsync(customer.Phone);

            result.Should().NotBeNull();
            result.Phone.Should().Be(customer.Phone.ToString());
            CustomerRepositoryMock.Verify(r => r.GetByPhoneAsync(customer.Phone), Times.Once);
        }

        [Fact]
        public async Task GetByPhoneAsync_ShouldThrowEntityNotFoundException_WhenPhoneDoesNotExist()
        {
            CustomerRepositoryMock.Setup(r => r.GetByPhoneAsync("9999999"))
                .ThrowsAsync(new EntityNotFoundException("Customer not found"));

            var act = async () => await Service.GetByPhoneAsync("9999999");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        // ── GetByPeriodOfTime ────────────────────────────────────────
        [Fact]
        public async Task GetByPeriodOfTimeAsync_ShouldReturnCustomers_WhenDatesAreValid()
        {
            var customers = SharedMockData.GetMockCustomers();
            var min = new DateTime(2024, 1, 1);
            var max = new DateTime(2024, 12, 31);
            CustomerRepositoryMock.Setup(r => r.GetByPeriodOfTimeAsync(min, max)).ReturnsAsync(customers);

            var result = await Service.GetByPeriodOfTimeAsync(min, max);

            result.Should().HaveCount(customers.Count);
            CustomerRepositoryMock.Verify(r => r.GetByPeriodOfTimeAsync(min, max), Times.Once);
        }

        [Fact]
        public async Task GetByPeriodOfTimeAsync_ShouldReturnEmptyList_WhenNoCustomersInRange()
        {
            var min = new DateTime(2020, 1, 1);
            var max = new DateTime(2020, 12, 31);
            CustomerRepositoryMock.Setup(r => r.GetByPeriodOfTimeAsync(min, max)).ReturnsAsync(new List<Customer>());

            var result = await Service.GetByPeriodOfTimeAsync(min, max);

            result.Should().NotBeNull().And.BeEmpty();
        }

        // ── GetAll ───────────────────────────────────────────────────
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCustomers()
        {
            var customers = SharedMockData.GetMockCustomers();
            CustomerRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(customers);

            var result = await Service.GetAllAsync();

            result.Should().HaveCount(customers.Count);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoCustomersExist()
        {
            CustomerRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Customer>());

            var result = await Service.GetAllAsync();

            result.Should().NotBeNull().And.BeEmpty();
        }

        // ── GetById ──────────────────────────────────────────────────
        [Fact]
        public async Task GetByIdAsync_ShouldReturnCustomer_WhenIdExists()
        {
            var customer = SharedMockData.GetSingleCustomer();
            CustomerRepositoryMock.Setup(r => r.GetByIdAsync(customer.Id)).ReturnsAsync(customer);

            var result = await Service.GetByIdAsync(customer.Id);

            result.Should().NotBeNull();
            result.Name.Should().Be(customer.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowEntityNotFoundException_WhenIdDoesNotExist()
        {
            CustomerRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Customer not found"));

            var act = async () => await Service.GetByIdAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }
    }
}
