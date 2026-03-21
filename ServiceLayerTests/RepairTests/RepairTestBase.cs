using AutoMapper;
using BLL.Automapper;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace ServiceLayerTests.RepairTests
{
    public class RepairTestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
        protected readonly Mock<IRepairRepository> RepairRepositoryMock;
        protected readonly IMapper Mapper;
        protected readonly RepairService Service;

        protected RepairTestBase()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            RepairRepositoryMock = new Mock<IRepairRepository>();
            UnitOfWorkMock.Setup(u => u.RepairRepository).Returns(RepairRepositoryMock.Object);
            UnitOfWorkMock.Setup(u => u.Save()).ReturnsAsync(1);
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>()).CreateMapper();
            Service = new RepairService(UnitOfWorkMock.Object, Mapper);
        }
    }
}
