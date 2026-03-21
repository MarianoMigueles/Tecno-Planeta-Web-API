using AutoMapper;
using BLL.Automapper;
using BLL.Services;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace ServiceLayerTests.InvoiceTests
{
    public class InvoiceTestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
        protected readonly Mock<IInvoiceRepository> InvoiceRepositoryMock;
        protected readonly IMapper Mapper;
        protected readonly InvoiceService Service;

        protected InvoiceTestBase()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            InvoiceRepositoryMock = new Mock<IInvoiceRepository>();
            UnitOfWorkMock.Setup(u => u.InvoiceRepository).Returns(InvoiceRepositoryMock.Object);
            UnitOfWorkMock.Setup(u => u.Save()).ReturnsAsync(1);
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>()).CreateMapper();
            Service = new InvoiceService(UnitOfWorkMock.Object, Mapper);
        }
    }
}
