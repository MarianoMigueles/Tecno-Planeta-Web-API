using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ProductServiceTestBase
{
    [TestClass]
    public class ProductServiceTestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
        protected readonly Mock<IProductRepository> ProductRepositoryMock;
        protected readonly IMapper Mapper;
        protected readonly ProductService Service;

        protected ProductServiceTestBase()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            ProductRepositoryMock = new Mock<IProductRepository>();

            UnitOfWorkMock
                .Setup(u => u.ProductRepository)
                .Returns(ProductRepositoryMock.Object);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductProfile>(); // tu AutoMapper Profile real
            });

            Mapper = mapperConfig.CreateMapper();

            Service = new ProductService(UnitOfWorkMock.Object, Mapper);
        }

    }
}
