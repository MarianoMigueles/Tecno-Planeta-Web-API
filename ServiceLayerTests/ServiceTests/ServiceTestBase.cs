using AutoMapper;
using BLL.Automapper;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace ServiceLayerTests.ServiceTests
{
    public class ServiceTestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
        protected readonly Mock<IServiceRepository> ServiceRepositoryMock;
        protected readonly IMapper Mapper;
        protected readonly ServiceService Service;

        protected ServiceTestBase()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            ServiceRepositoryMock = new Mock<IServiceRepository>();
            UnitOfWorkMock.Setup(u => u.ServiceRepository).Returns(ServiceRepositoryMock.Object);
            UnitOfWorkMock.Setup(u => u.Save()).ReturnsAsync(1);
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>()).CreateMapper();
            Service = new ServiceService(UnitOfWorkMock.Object, Mapper);
        }
    }
}
