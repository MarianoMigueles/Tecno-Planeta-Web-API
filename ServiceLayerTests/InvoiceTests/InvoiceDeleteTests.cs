using Entities.Elements.InvoiceFolder;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.InvoiceTests
{
    public class InvoiceDeleteTests : InvoiceTestBase
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenInvoiceExists()
        {
            var customer = SharedMockData.GetSingleCustomer();
            var invoice = new Invoice { Id = 1, CustomerID = customer.Id, Customer = customer, InvoiceNumber = 1001, IssueDate = DateTime.UtcNow };
            InvoiceRepositoryMock.Setup(r => r.GetByIdAsync(invoice.Id)).ReturnsAsync(invoice);
            InvoiceRepositoryMock.Setup(r => r.Delete(It.IsAny<Invoice>()));

            var result = await Service.DeleteAsync(invoice.Id);

            result.Should().BeTrue();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenInvoiceDoesNotExist()
        {
            InvoiceRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Invoice not found"));

            var act = async () => await Service.DeleteAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallSaveChanges_WhenDeletionSucceeds()
        {
            var customer = SharedMockData.GetSingleCustomer();
            var invoice = new Invoice { Id = 1, CustomerID = customer.Id, Customer = customer, InvoiceNumber = 1001, IssueDate = DateTime.UtcNow };
            InvoiceRepositoryMock.Setup(r => r.GetByIdAsync(invoice.Id)).ReturnsAsync(invoice);
            InvoiceRepositoryMock.Setup(r => r.Delete(It.IsAny<Invoice>()));

            await Service.DeleteAsync(invoice.Id);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
