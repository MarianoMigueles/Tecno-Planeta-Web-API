using AutoMapper;
using BLL.Automapper;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace ServiceLayerTests.CustomerTests
{
    public class CustomerTestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
        protected readonly Mock<ICustomerRepository> CustomerRepositoryMock;
        protected readonly IMapper Mapper;
        protected readonly CustomerService Service;

        protected CustomerTestBase()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            CustomerRepositoryMock = new Mock<ICustomerRepository>();
            UnitOfWorkMock.Setup(u => u.CustomerRepository).Returns(CustomerRepositoryMock.Object);
            UnitOfWorkMock.Setup(u => u.Save()).ReturnsAsync(1);
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>()).CreateMapper();
            Service = new CustomerService(UnitOfWorkMock.Object, Mapper);
        }
    }
}
