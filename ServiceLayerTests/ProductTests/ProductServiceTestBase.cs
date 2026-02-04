using AutoMapper;
using BLL.Automapper;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.ProductTests
{
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
                cfg.AddProfile<AutomapperProfile>(); // tu AutoMapper Profile real
            });

            Mapper = mapperConfig.CreateMapper();

            Service = new ProductService(UnitOfWorkMock.Object, Mapper);
        }
    }
}
