using Entities.Users;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.CustomerTests
{
    public class CustomerDeleteTests : CustomerTestBase
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenCustomerExists()
        {
            var customer = SharedMockData.GetSingleCustomer();
            CustomerRepositoryMock.Setup(r => r.GetByIdAsync(customer.Id)).ReturnsAsync(customer);
            CustomerRepositoryMock.Setup(r => r.Delete(It.IsAny<Customer>()));

            var result = await Service.DeleteAsync(customer.Id);

            result.Should().BeTrue();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenCustomerDoesNotExist()
        {
            CustomerRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Customer not found"));

            var act = async () => await Service.DeleteAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallSaveChanges_WhenDeletionSucceeds()
        {
            var customer = SharedMockData.GetSingleCustomer();
            CustomerRepositoryMock.Setup(r => r.GetByIdAsync(customer.Id)).ReturnsAsync(customer);
            CustomerRepositoryMock.Setup(r => r.Delete(It.IsAny<Customer>()));

            await Service.DeleteAsync(customer.Id);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
