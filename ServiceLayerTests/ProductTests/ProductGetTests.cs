using Entities.Elements.ProductFolder;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.ProductTests
{
    public class ProductGetTests : ProductServiceTestBase
    {
        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByRangeOfPurchasePrice -------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetAllByRangeOfPurchasePriceAsync_ShouldReturnProducts_WhenRangeIsValid()
        {
            var products = ProductMockData.GetMockProducts()
                .Where(p => p.Details.PurchasePrice >= 100 && p.Details.PurchasePrice <= 700)
                .ToList();
            ProductRepositoryMock
                .Setup(r => r.GetAllByRangeOfPurchasePriceAsync(100, 700))
                .ReturnsAsync(products);

            var result = await Service.GetAllByRangeOfPurchasePriceAsync(100, 700);

            result.Should().NotBeNull().And.HaveCount(products.Count);
            ProductRepositoryMock.Verify(r => r.GetAllByRangeOfPurchasePriceAsync(100, 700), Times.Once);
        }

        [Fact]
        public async Task GetAllByRangeOfPurchasePriceAsync_ShouldReturnEmptyList_WhenNoProductsMatch()
        {
            ProductRepositoryMock
                .Setup(r => r.GetAllByRangeOfPurchasePriceAsync(9000, 9999))
                .ReturnsAsync(new List<Product>());

            var result = await Service.GetAllByRangeOfPurchasePriceAsync(9000, 9999);

            result.Should().NotBeNull().And.BeEmpty();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByBarCode -----------------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetByBarCodeAsync_ShouldReturnProduct_WhenBarCodeExists()
        {
            var product = ProductMockData.GetMockProducts().First(p => p.Details.BarCode == "GPU001");
            ProductRepositoryMock
                .Setup(r => r.GetByBarCodeAsync("GPU001"))
                .ReturnsAsync(product);

            var result = await Service.GetByBarCodeAsync("GPU001");

            result.Should().NotBeNull();
            result.BarCode.Should().Be("GPU001");
            ProductRepositoryMock.Verify(r => r.GetByBarCodeAsync("GPU001"), Times.Once);
        }

        [Fact]
        public async Task GetByBarCodeAsync_ShouldThrowException_WhenBarCodeDoesNotExist()
        {
            ProductRepositoryMock
                .Setup(r => r.GetByBarCodeAsync("INEXISTENTE"))
                .ThrowsAsync(new Exeptions.EntityNotFoundException("Product not found"));

            var act = async () => await Service.GetByBarCodeAsync("INEXISTENTE");

            await act.Should().ThrowAsync<Exeptions.EntityNotFoundException>();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetById ----------------------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            var product = ProductMockData.GetMockProducts().First();
            ProductRepositoryMock
                .Setup(r => r.GetByIdAsync(product.Id))
                .ReturnsAsync(product);

            var result = await Service.GetByIdAsync(product.Id);

            result.Should().NotBeNull();
            result.Name.Should().Be(product.Name);
            ProductRepositoryMock.Verify(r => r.GetByIdAsync(product.Id), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowException_WhenProductDoesNotExist()
        {
            ProductRepositoryMock
                .Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new Exeptions.EntityNotFoundException("Product not found"));

            var act = async () => await Service.GetByIdAsync(999);

            await act.Should().ThrowAsync<Exeptions.EntityNotFoundException>();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetAll -----------------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            var products = ProductMockData.GetMockProducts();
            ProductRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(products);

            var result = await Service.GetAllAsync();

            result.Should().HaveCount(products.Count);
            ProductRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoProductsExist()
        {
            ProductRepositoryMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Product>());

            var result = await Service.GetAllAsync();

            result.Should().NotBeNull().And.BeEmpty();
        }

        //--------------------------------------------------------------------------------------
        //------------------------ GetAllByActiveStatusTests -----------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllByActiveStatusTests_ShouldReturnMappedProducts_WhenStatusIsTrue()
        {
            // Arrange
            var products = ProductMockData.GetActiveProducts();

            ProductRepositoryMock
                .Setup(r => r.GetAllByActiveStatusAsync(true))
                .ReturnsAsync(products);

            // Act
            var result = await Service.GetAllByActiveStatusAsync(true);

            // Assert
            result.Should().HaveCount(products.Count);
            result.Should().OnlyContain(p => p.IsActive);

            ProductRepositoryMock.Verify(
                r => r.GetAllByActiveStatusAsync(true),
                Times.Once);
        }

        [Fact]
        public async Task GetAllByActiveStatusTests_ShouldReturnMappedProducts_WhenStatusIsFalse()
        {
            // Arrange
            var products = ProductMockData.GetInactiveProducts();

            ProductRepositoryMock
                .Setup(r => r.GetAllByActiveStatusAsync(false))
                .ReturnsAsync(products);

            // Act
            var result = await Service.GetAllByActiveStatusAsync(false);

            // Assert
            result.Should().HaveCount(products.Count);
            result.Should().OnlyContain(p => p.IsActive == false);

            ProductRepositoryMock.Verify(
                r => r.GetAllByActiveStatusAsync(false),
                Times.Once);
        }

        [Fact]
        public async Task GetAllByActiveStatusTests_ShouldReturnEmptyList_WhenNoProductsMatch()
        {
            // Arrange
            var products = new List<Product>();

            ProductRepositoryMock
                .Setup(r => r.GetAllByActiveStatusAsync(true))
                .ReturnsAsync(products);

            // Act
            var result = await Service.GetAllByActiveStatusAsync(true);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();

            ProductRepositoryMock.Verify(
                r => r.GetAllByActiveStatusAsync(true),
                Times.Once);
        }



        //--------------------------------------------------------------------------------------
        //----------------------------------- GetByName ----------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByName_ShouldReturnMappedProduct()
        {
            var product = ProductMockData.GetMockProducts().First(p => p.Name == "NVIDIA RTX 4070 Ti");

            ProductRepositoryMock
                .Setup(r => r.GetByNameAsync("NVIDIA RTX 4070 Ti"))
                .ReturnsAsync(product);

            var result = await Service.GetByNameAsync("NVIDIA RTX 4070 Ti");

            result.Should().NotBeNull();
            result.Name.Should().Be("NVIDIA RTX 4070 Ti");
        }

        [Fact]
        public async Task GetByName_ShouldReturnExeption_WhenNoProductMatch()
        {
            // Arrange
            ProductRepositoryMock
                .Setup(r => r.GetByNameAsync("Producto no registrado"))
                .ReturnsAsync((Product)null);

            // Act
            var result = await Service.GetByNameAsync("Producto no registrado");

            // Assert
            result.Should().BeNull();

            ProductRepositoryMock.Verify(
                r => r.GetByNameAsync("Producto no registrado"),
                Times.Once);
        }

        //--------------------------------------------------------------------------------------
        //----------------------------------- GetByBarCode -------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByBarCode_ShouldReturnMappedProduct()
        {
            var product = ProductMockData.GetMockProducts().First(p => p.Details.BarCode == "GPU001");

            ProductRepositoryMock
                .Setup(r => r.GetByBarCodeAsync("GPU001"))
                .ReturnsAsync(product);

            var result = await Service.GetByBarCodeAsync("GPU001");

            result.Should().NotBeNull();
            result.BarCode.Should().Be("GPU001");
        }

        //--------------------------------------------------------------------------------------
        //----------------------------------- GetAllByRangeOfPurchasePriceAsync ----------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllByRangeOfPurchasePriceAsync_ShouldReturnMappedProduct_WhenProductsExistInRange()
        {
            var products = ProductMockData.GetMockProducts()
                .Where(p => p.Details.PurchasePrice >= 100 && p.Details.PurchasePrice <= 500)
                .ToList();

            ProductRepositoryMock
                .Setup(r => r.GetAllByRangeOfPurchasePriceAsync(100, 500))
                .ReturnsAsync(products);

            var result = await Service.GetAllByRangeOfPurchasePriceAsync(100, 500);

            result.Should().NotBeNull();
            result.Should().HaveCount(products.Count);

            result.Should().OnlyContain(p =>
                p.PurchasePrice >= 100 && p.PurchasePrice <= 500);

            ProductRepositoryMock.Verify(
                r => r.GetAllByRangeOfPurchasePriceAsync(100, 500),
                Times.Once);
        }
    }
}
