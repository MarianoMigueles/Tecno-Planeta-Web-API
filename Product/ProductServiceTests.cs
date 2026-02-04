using Entities.Elements.ProductFolder;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductTest
{
    public class ProductServiceTests : ProductServiceTestBase
    {
        [Fact]
        public async Task GetAllByActiveStatus_ShouldReturnMappedProducts_WhenStatusIsTrue()
        {
            // Arrange
            var products = new List<Product>
            {
                new() { Id = 1, Name = "Prod A"},
                new() { Id = 2, Name = "Prod B"}
            };

            foreach (var p in products)
            {
                p.EditStatus(true);
            }

            ProductRepositoryMock
                .Setup(r => r.GetAllByActiveStatusAsync(true))
                .ReturnsAsync(products);

            // Act
            var result = await Service.GetAllByActiveStatusAsync(true);

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be("Prod A");

            ProductRepositoryMock.Verify(
                r => r.GetAllByActiveStatusAsync(true),
                Times.Once);
        }

        [Fact]
        public async Task GetByName_ShouldReturnProduct() { }
    }
}
