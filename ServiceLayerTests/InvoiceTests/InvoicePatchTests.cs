using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.InvoiceTests
{
    public class InvoicePatchTests : InvoiceTestBase
    {
        [Fact]
        public async Task UpdateStatusAsync_ShouldReturnUpdatedInvoice_WhenStatusIsValid()
        {
            var customer = SharedMockData.GetSingleCustomer();
            var invoice = new Invoice { Id = 1, CustomerID = customer.Id, Customer = customer, InvoiceNumber = 1001, IssueDate = DateTime.UtcNow };
            InvoiceRepositoryMock.Setup(r => r.UpdateStatusAsync(invoice.Id, EInvoiceStatus.PAID)).ReturnsAsync(invoice);

            var result = await Service.UpdateStatusAsync(invoice.Id, EInvoiceStatus.PAID);

            result.Should().NotBeNull();
            InvoiceRepositoryMock.Verify(r => r.UpdateStatusAsync(invoice.Id, EInvoiceStatus.PAID), Times.Once);
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowEntityNotFoundException_WhenInvoiceDoesNotExist()
        {
            InvoiceRepositoryMock.Setup(r => r.UpdateStatusAsync(999, EInvoiceStatus.PAID))
                .ThrowsAsync(new EntityNotFoundException("Invoice not found"));

            var act = async () => await Service.UpdateStatusAsync(999, EInvoiceStatus.PAID);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowValidationException_WhenInvoiceIsAlreadyPaid()
        {
            var customer = SharedMockData.GetSingleCustomer();
            var invoice = new Invoice { Id = 1, CustomerID = customer.Id, Customer = customer, InvoiceNumber = 1001, IssueDate = DateTime.UtcNow };
            invoice.EditStatus(EInvoiceStatus.PAID);

            var act = () => invoice.EditStatus(EInvoiceStatus.DRAFT);

            act.Should().Throw<Exception>();
        }
    }
}
