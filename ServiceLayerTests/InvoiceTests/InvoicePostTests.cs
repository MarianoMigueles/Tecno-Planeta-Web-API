using BLL.DTO.Invoice;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Exeptions;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.InvoiceTests
{
    public class InvoicePostTests : InvoiceTestBase
    {
        private static InvoiceCreateDTO ValidCreateDTO() => new()
        {
            CustomerId = 1,
            Status = EInvoiceStatus.DRAFT,
            SubTotal = 100m,
            Total = 121m,
            InvoiceNumber = 1001,
            IssueDate = DateTime.Today,
            PercentageDiscount = 0,
            PercentageTax = 21,
            Notes = "Test invoice",
            Items = new List<InvoiceItemDTO>
            {
                new() { ProductName = "RTX 4070 Ti", Quantity = 1, UnitPrice = 100m }
            }
        };

        [Fact]
        public async Task CreateAsync_ShouldReturnInvoiceResponseDTO_WhenDataIsValid()
        {
            InvoiceRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Invoice>()))
                .Returns(Task.CompletedTask);

            var result = await Service.CreateAsync(ValidCreateDTO());

            result.Should().NotBeNull();
            result.Should().BeOfType<InvoiceResponseDTO>();
        }

        [Fact]
        public async Task CreateAsync_ShouldCallSaveChanges_WhenInvoiceIsCreated()
        {
            InvoiceRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Invoice>()))
                .Returns(Task.CompletedTask);

            await Service.CreateAsync(ValidCreateDTO());

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallRepositoryCreateAsync_Once()
        {
            InvoiceRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Invoice>()))
                .Returns(Task.CompletedTask);

            await Service.CreateAsync(ValidCreateDTO());

            InvoiceRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<Invoice>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenRepositoryFails()
        {
            InvoiceRepositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Invoice>()))
                .ThrowsAsync(new DatabaseOperationException("DB error"));

            var act = async () => await Service.CreateAsync(ValidCreateDTO());

            await act.Should().ThrowAsync<DatabaseOperationException>();
        }
    }
}
