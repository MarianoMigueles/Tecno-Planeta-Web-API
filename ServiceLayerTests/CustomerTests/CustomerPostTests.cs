using BLL.DTO.Users.Customer;
using Entities.Users;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.CustomerTests
{
    public class CustomerPostTests : CustomerTestBase
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnCustomerResponseDTO_WhenDataIsValid()
        {
            var dto = new CustomerCreateDTO { Name = "Nuevo Cliente", Phone = "3411112233" };
            CustomerRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Customer>())).Returns(Task.CompletedTask);

            var result = await Service.CreateAsync(dto);

            result.Should().NotBeNull();
            result.Should().BeOfType<CustomerResponseDTO>();
            CustomerRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<Customer>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallSaveChanges_WhenCustomerIsCreated()
        {
            var dto = new CustomerCreateDTO { Name = "Nuevo Cliente", Phone = "3411112233" };
            CustomerRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Customer>())).Returns(Task.CompletedTask);

            await Service.CreateAsync(dto);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
