using Entities.Services;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.RepairTests
{
    public class RepairDeleteTests : RepairTestBase
    {
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenRepairExists()
        {
            var repair = SharedMockData.GetSingleRepair();
            RepairRepositoryMock.Setup(r => r.GetByIdAsync(repair.Id)).ReturnsAsync(repair);
            RepairRepositoryMock.Setup(r => r.Delete(It.IsAny<Repair>()));

            var result = await Service.DeleteAsync(repair.Id);

            result.Should().BeTrue();
            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowEntityNotFoundException_WhenRepairDoesNotExist()
        {
            RepairRepositoryMock.Setup(r => r.GetByIdAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Repair not found"));

            var act = async () => await Service.DeleteAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallSaveChanges_WhenDeletionSucceeds()
        {
            var repair = SharedMockData.GetSingleRepair();
            RepairRepositoryMock.Setup(r => r.GetByIdAsync(repair.Id)).ReturnsAsync(repair);
            RepairRepositoryMock.Setup(r => r.Delete(It.IsAny<Repair>()));

            await Service.DeleteAsync(repair.Id);

            UnitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }
    }
}
