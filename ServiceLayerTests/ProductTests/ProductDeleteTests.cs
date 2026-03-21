using Entities.Elements.ProductFolder;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.ProductTests
{
    public class ProductDeleteTests : ProductServiceTestBase
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenProductExists()
        {
            var product = ProductMockData.GetMockProducts().First();
            ProductRepositoryMock.Setup(r => r.GetByIdAsync(product.Id)).ReturnsAsync(product);
            ProductRepositoryMock.Setup(r => r.Delete(It.IsAny<Product>()));

            var result = await Service.DeleteAsync(product.Id);

            result.Should().BeTrue();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenProductDoesNotExist()
        {
            ProductRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Product not found"));

            var act = async () => await Service.DeleteAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallSaveChanges_WhenDeletionSucceeds()
        {
            var product = ProductMockData.GetMockProducts().First();
            ProductRepositoryMock.Setup(r => r.GetByIdAsync(product.Id)).ReturnsAsync(product);
            ProductRepositoryMock.Setup(r => r.Delete(It.IsAny<Product>()));

            await Service.DeleteAsync(product.Id);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
