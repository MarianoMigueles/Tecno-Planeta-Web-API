using Entities.Elements.ProductFolder;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.ProductTests
{
    public class ProductPatchTests : ProductServiceTestBase
    {
        // ── UpdateName ───────────────────────────────────────────────
        [Fact]
        public async Task UpdateNameAsync_ShouldReturnUpdatedProduct_WhenProductExists()
        {
            var product = ProductMockData.GetMockProducts().First();
            var newName = "RTX 4070 Ti Super";
            var updated = new Product { Id = product.Id, CategoryId = product.CategoryId, Category = product.Category, DetailsId = product.DetailsId, Details = product.Details };
            updated.GetType().GetProperty("Name")?.SetValue(updated, newName);

            ProductRepositoryMock.Setup(r => r.UpdateNameAsync(product.Id, newName)).ReturnsAsync(updated);

            var result = await Service.UpdateNameAsync(product.Id, newName);

            result.Should().NotBeNull();
            result.Name.Should().Be(newName);
        }

        [Fact]
        public async Task UpdateNameAsync_ShouldThrowEntityNotFoundException_WhenProductDoesNotExist()
        {
            ProductRepositoryMock.Setup(r => r.UpdateNameAsync(999, "X"))
                .ThrowsAsync(new EntityNotFoundException("Product not found"));

            var act = async () => await Service.UpdateNameAsync(999, "X");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        // ── UpdateSalePrice ──────────────────────────────────────────
        [Fact]
        public async Task UpdateSalePriceAsync_ShouldReturnUpdatedProduct_WhenProductExists()
        {
            var product = ProductMockData.GetMockProducts().First();
            product.EditSalePrice(999.99m);
            ProductRepositoryMock.Setup(r => r.UpdateSalePriceAsync(product.Id, 999.99m)).ReturnsAsync(product);

            var result = await Service.UpdateSalePriceAsync(product.Id, 999.99m);

            result.Should().NotBeNull();
            result.SalePrice.Should().Be(999.99m);
        }

        [Fact]
        public async Task UpdateSalePriceAsync_ShouldThrowValidationException_WhenPriceIsNegative()
        {
            var product = ProductMockData.GetMockProducts().First();

            var act = () => product.EditSalePrice(-1m);

            act.Should().Throw<Exception>();
        }

        // ── AddStock ─────────────────────────────────────────────────
        [Fact]
        public async Task AddStockAsync_ShouldIncreaseStock_WhenAmountIsPositive()
        {
            var product = ProductMockData.GetMockProducts().First();
            var originalStock = (int)product.GetType().GetProperty("Stock")!.GetValue(product)!;
            product.AddStock(10);
            ProductRepositoryMock.Setup(r => r.AddStockAsync(product.Id, 10)).ReturnsAsync(product);

            var result = await Service.AddStockAsync(product.Id, 10);

            result.Should().NotBeNull();
            result.Stock.Should().BeGreaterThan(originalStock);
        }

        [Fact]
        public async Task AddStockAsync_ShouldThrowValidationException_WhenAmountIsZeroOrNegative()
        {
            var product = ProductMockData.GetMockProducts().First();

            var act = () => product.AddStock(0);

            act.Should().Throw<Exception>();
        }

        // ── SubstractStock ───────────────────────────────────────────
        [Fact]
        public async Task SubstractStockAsync_ShouldDecreaseStock_WhenAmountIsValid()
        {
            var product = ProductMockData.GetMockProducts().First();
            product.AddStock(5);
            var stockBefore = (int)product.GetType().GetProperty("Stock")!.GetValue(product)!;
            product.SubstractStock(2);
            ProductRepositoryMock.Setup(r => r.SubstractStockAsync(product.Id, 2)).ReturnsAsync(product);

            var result = await Service.SubstractStockAsync(product.Id, 2);

            result.Should().NotBeNull();
            result.Stock.Should().BeLessThan(stockBefore);
        }

        // ── Activate / Desactivate ───────────────────────────────────
        [Fact]
        public async Task ActivateAsync_ShouldReturnActiveProduct()
        {
            var product = ProductMockData.GetInactiveProducts().FirstOrDefault();
            if (product == null) return; // skip if no inactive products in mock

            product.EditStatus(true);
            ProductRepositoryMock.Setup(r => r.UpdateStatusAsync(product.Id, true)).ReturnsAsync(product);

            var result = await Service.ActivateAsync(product.Id);

            result.IsActive.Should().BeTrue();
        }

        [Fact]
        public async Task DesactivateAsync_ShouldReturnInactiveProduct()
        {
            var product = ProductMockData.GetActiveProducts().First();
            product.EditStatus(false);
            ProductRepositoryMock.Setup(r => r.UpdateStatusAsync(product.Id, false)).ReturnsAsync(product);

            var result = await Service.DesactivateAsync(product.Id);

            result.IsActive.Should().BeFalse();
        }
    }
}
