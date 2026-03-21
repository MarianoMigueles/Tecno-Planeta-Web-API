using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.InvoiceTests
{
    public class InvoiceGetTests : InvoiceTestBase
    {
        private List<Invoice> GetMockInvoices()
        {
            var customer = SharedMockData.GetSingleCustomer();
            return new List<Invoice>
            {
                new Invoice { Id = 1, CustomerID = customer.Id, Customer = customer, InvoiceNumber = 1001, IssueDate = new DateTime(2024, 5, 10) },
                new Invoice { Id = 2, CustomerID = customer.Id, Customer = customer, InvoiceNumber = 1002, IssueDate = new DateTime(2024, 6, 15) },
            };
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnInvoice_WhenIdExists()
        {
            var invoices = GetMockInvoices();
            var invoice = invoices.First();
            InvoiceRepositoryMock.Setup(r => r.GetByIdAsync(invoice.Id)).ReturnsAsync(invoice);

            var result = await Service.GetByIdAsync(invoice.Id);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowEntityNotFoundException_WhenIdDoesNotExist()
        {
            InvoiceRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Invoice not found"));

            var act = async () => await Service.GetByIdAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task GetByNumberAsync_ShouldReturnInvoice_WhenNumberExists()
        {
            var invoice = GetMockInvoices().First();
            InvoiceRepositoryMock.Setup(r => r.GetByNumberAsync(1001)).ReturnsAsync(invoice);

            var result = await Service.GetByNumberAsync(1001);

            result.Should().NotBeNull();
            result.InvoiceNumber.Should().Be(1001);
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnInvoice_WhenCustomerExists()
        {
            var invoice = GetMockInvoices().First();
            InvoiceRepositoryMock.Setup(r => r.GetByCustomerNameAsync("Juan Perez")).ReturnsAsync(invoice);

            var result = await Service.GetByCustomerNameAsync("Juan Perez");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAllByStatusAsync_ShouldReturnInvoices_WhenStatusMatches()
        {
            var invoices = GetMockInvoices();
            InvoiceRepositoryMock.Setup(r => r.GetAllByStatusAsync(EInvoiceStatus.DRAFT)).ReturnsAsync(invoices);

            var result = await Service.GetAllByStatusAsync(EInvoiceStatus.DRAFT);

            result.Should().HaveCount(invoices.Count);
        }

        [Fact]
        public async Task GetAllByStatusAsync_ShouldReturnEmptyList_WhenNoInvoicesMatchStatus()
        {
            InvoiceRepositoryMock.Setup(r => r.GetAllByStatusAsync(EInvoiceStatus.CANCELED)).ReturnsAsync(new List<Invoice>());

            var result = await Service.GetAllByStatusAsync(EInvoiceStatus.CANCELED);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllByOperationTypeAsync_ShouldReturnInvoices_WhenTypeMatches()
        {
            var invoices = GetMockInvoices();
            InvoiceRepositoryMock.Setup(r => r.GetAllByOperationTypeAsync(EInvoiceOperation.INCOME)).ReturnsAsync(invoices);

            var result = await Service.GetAllByOperationTypeAsync(EInvoiceOperation.INCOME);

            result.Should().HaveCount(invoices.Count);
        }

        [Fact]
        public async Task GetAllByIssueDateAsync_ShouldReturnInvoices_WhenDateMatches()
        {
            var invoices = GetMockInvoices();
            var date = new DateTime(2024, 5, 10);
            InvoiceRepositoryMock.Setup(r => r.GetAllByIssueDateAsync(date)).ReturnsAsync(invoices);

            var result = await Service.GetAllByIssueDateAsync(date);

            result.Should().HaveCount(invoices.Count);
        }

        [Fact]
        public async Task GetContainsProductIdAsync_ShouldReturnInvoices_WhenProductIdsMatch()
        {
            var invoices = GetMockInvoices();
            var ids = new List<int> { 1, 2 };
            InvoiceRepositoryMock.Setup(r => r.GetContainsProductIdAsync(ids)).ReturnsAsync(invoices);

            var result = await Service.GetContainsProductIdAsync(ids);

            result.Should().HaveCount(invoices.Count);
        }

        [Fact]
        public async Task GetContainsProductIdAsync_ShouldReturnEmptyList_WhenNoInvoicesContainProducts()
        {
            InvoiceRepositoryMock.Setup(r => r.GetContainsProductIdAsync(new List<int> { 999 })).ReturnsAsync(new List<Invoice>());

            var result = await Service.GetContainsProductIdAsync(new List<int> { 999 });

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllByProductQuantityAsync_ShouldReturnInvoices_WhenQuantityIsInRange()
        {
            var invoices = GetMockInvoices();
            InvoiceRepositoryMock.Setup(r => r.GetAllByProductQuantityAsync(0, 10)).ReturnsAsync(invoices);

            var result = await Service.GetAllByProductQuantityAsync(0, 10);

            result.Should().HaveCount(invoices.Count);
        }
    }
}
