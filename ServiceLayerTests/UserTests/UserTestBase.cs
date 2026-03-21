using AutoMapper;
using BLL.Automapper;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace ServiceLayerTests.UserTests
{
    public class UserTestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
        protected readonly Mock<IUserRepository> UserRepositoryMock;
        protected readonly IMapper Mapper;
        protected readonly UserService Service;

        protected UserTestBase()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            UserRepositoryMock = new Mock<IUserRepository>();
            UnitOfWorkMock.Setup(u => u.UserRepository).Returns(UserRepositoryMock.Object);
            UnitOfWorkMock.Setup(u => u.Save()).ReturnsAsync(1);
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>()).CreateMapper();
            Service = new UserService(UnitOfWorkMock.Object, Mapper);
        }
    }
}
