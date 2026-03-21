using BLL.DTO.Product;
using Entities.Elements.ProductFolder;
using Exeptions;
using FluentAssertions;
using Moq;
using BLL.DTO;

namespace ServiceLayerTests.ProductTests
{
    public class ProductCreateTests : ProductServiceTestBase
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnProductResponseDTO_WhenDataIsValid()
        {
            var dto = new ProductCreateDTO
            {
                Name = "Nuevo Producto",
                SalePrice = 100m,
                CategoryDescription = "Componentes",
                DetailsDescription = "Descripcion test",
                BarCode = "TEST001",
                PurchasePrice = 60m
            };
            ProductRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var result = await Service.CreateAsync(dto);

            result.Should().NotBeNull();
            result.Should().BeOfType<ProductResponseDTO>();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallSaveChanges_WhenCreationSucceeds()
        {
            var dto = new ProductCreateDTO { Name = "Test", SalePrice = 10m, CategoryDescription = "Cat", DetailsDescription = "Desc", BarCode = "BC001" };
            ProductRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            await Service.CreateAsync(dto);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenRepositoryFails()
        {
            var dto = new ProductCreateDTO { Name = "Test", SalePrice = 10m, CategoryDescription = "Cat", DetailsDescription = "Desc", BarCode = "BC001" };
            ProductRepositoryMock.Setup(r => r.CreateAsync(It.IsAny<Product>()))
                .ThrowsAsync(new DatabaseOperationException("DB error"));

            var act = async () => await Service.CreateAsync(dto);

            await act.Should().ThrowAsync<DatabaseOperationException>();
        }
    }
}
