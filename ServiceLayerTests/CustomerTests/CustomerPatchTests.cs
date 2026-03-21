using Entities.Users;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.CustomerTests
{
    public class CustomerPatchTests : CustomerTestBase
    {
        // ── UpdateName ───────────────────────────────────────────────
        [Fact]
        public async Task UpdateNameAsync_ShouldReturnUpdatedCustomer_WhenCustomerExists()
        {
            var customer = SharedMockData.GetSingleCustomer();
            var newName = "Juan Alberto Perez";
            var updated = new Customer { Id = customer.Id, Name = newName, Phone = customer.Phone, RegisterDate = customer.RegisterDate };
            CustomerRepositoryMock.Setup(r => r.UpdateNameAsync(customer.Id, newName)).ReturnsAsync(updated);

            var result = await Service.UpdateNameAsync(customer.Id, newName);

            result.Should().NotBeNull();
            result.Name.Should().Be(newName);
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task UpdateNameAsync_ShouldThrowEntityNotFoundException_WhenCustomerDoesNotExist()
        {
            CustomerRepositoryMock.Setup(r => r.UpdateNameAsync(999, "X"))
                .ThrowsAsync(new EntityNotFoundException("Customer not found"));

            var act = async () => await Service.UpdateNameAsync(999, "X");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        // ── UpdatePhone ──────────────────────────────────────────────
        [Fact]
        public async Task UpdatePhoneAsync_ShouldReturnUpdatedCustomer_WhenCustomerExists()
        {
            var customer = SharedMockData.GetSingleCustomer();
            string newPhone = "3410000001";
            var updated = new Customer { Id = customer.Id, Name = customer.Name, Phone = newPhone, RegisterDate = customer.RegisterDate };
            CustomerRepositoryMock.Setup(r => r.UpdatePhoneAsync(customer.Id, newPhone)).ReturnsAsync(updated);

            var result = await Service.UpdatePhoneAsync(customer.Id, newPhone);

            result.Should().NotBeNull();
            result.Phone.Should().Be(newPhone.ToString());
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task UpdatePhoneAsync_ShouldThrowEntityNotFoundException_WhenCustomerDoesNotExist()
        {
            CustomerRepositoryMock.Setup(r => r.UpdatePhoneAsync(999, "111"))
                .ThrowsAsync(new EntityNotFoundException("Customer not found"));

            var act = async () => await Service.UpdatePhoneAsync(999, "111");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }
    }
}
