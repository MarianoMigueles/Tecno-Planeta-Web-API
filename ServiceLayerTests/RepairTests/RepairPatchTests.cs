using Entities.Services;
using Entities.Services.Enums;
using Exeptions;
using FluentAssertions;
using Moq;

namespace ServiceLayerTests.RepairTests
{
    public class RepairPatchTests : RepairTestBase
    {
        // ── CancelRepair ─────────────────────────────────────────────
        [Fact]
        public async Task CancelRepairAsync_ShouldReturnCancelledRepair_WhenRepairExists()
        {
            var repair = SharedMockData.GetSingleRepair();
            RepairRepositoryMock.Setup(r => r.CancelRepairAsync(repair.Id)).ReturnsAsync(repair);

            var result = await Service.CancelRepairAsync(repair.Id);

            result.Should().NotBeNull();
            RepairRepositoryMock.Verify(r => r.CancelRepairAsync(repair.Id), Times.Once);
        }

        [Fact]
        public async Task CancelRepairAsync_ShouldThrowEntityNotFoundException_WhenRepairDoesNotExist()
        {
            RepairRepositoryMock.Setup(r => r.CancelRepairAsync(999))
                .ThrowsAsync(new EntityNotFoundException("Repair not found"));

            var act = async () => await Service.CancelRepairAsync(999);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        // ── UpdateCost ───────────────────────────────────────────────
        [Fact]
        public async Task UpdateCostAsync_ShouldReturnUpdatedRepair_WhenRepairExists()
        {
            var repair = SharedMockData.GetSingleRepair();
            RepairRepositoryMock.Setup(r => r.UpdateCostAsync(repair.Id, 250m)).ReturnsAsync(repair);

            var result = await Service.UpdateCostAsync(repair.Id, 250m);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateCostAsync_ShouldThrowEntityNotFoundException_WhenRepairDoesNotExist()
        {
            RepairRepositoryMock.Setup(r => r.UpdateCostAsync(999, 100m))
                .ThrowsAsync(new EntityNotFoundException("Repair not found"));

            var act = async () => await Service.UpdateCostAsync(999, 100m);

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Fact]
        public async Task UpdateCostAsync_ShouldThrowValidationException_WhenCostIsNegative()
        {
            var repair = SharedMockData.GetSingleRepair();

            var act = () => repair.UpdateCost(-1m);

            act.Should().Throw<Exception>();
        }

        // ── UpdateNote ───────────────────────────────────────────────
        [Fact]
        public async Task UpdateNoteAsync_ShouldReturnUpdatedRepair_WhenRepairExists()
        {
            var repair = SharedMockData.GetSingleRepair();
            RepairRepositoryMock.Setup(r => r.UpdateNoteAsync(repair.Id, "Nueva nota")).ReturnsAsync(repair);

            var result = await Service.UpdateNoteAsync(repair.Id, "Nueva nota");

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateNoteAsync_ShouldThrowEntityNotFoundException_WhenRepairDoesNotExist()
        {
            RepairRepositoryMock.Setup(r => r.UpdateNoteAsync(999, "nota"))
                .ThrowsAsync(new EntityNotFoundException("Repair not found"));

            var act = async () => await Service.UpdateNoteAsync(999, "nota");

            await act.Should().ThrowAsync<EntityNotFoundException>();
        }

        // ── UpdateStatus ─────────────────────────────────────────────
        [Fact]
        public async Task UpdateStatusAsync_ShouldReturnUpdatedRepair_WhenRepairExists()
        {
            var repair = SharedMockData.GetSingleRepair();
            RepairRepositoryMock.Setup(r => r.UpdateStatusAsync(repair.Id, ERepairStatus.IN_PROGRESS)).ReturnsAsync(repair);

            var result = await Service.UpdateStatusAsync(repair.Id, ERepairStatus.IN_PROGRESS);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowValidationException_WhenStatusAlreadyComplete()
        {
            var repair = SharedMockData.GetSingleRepair();
            // Llevar al estado COMPLETE manualmente
            repair.ChangeRepairStatus(ERepairStatus.IN_PROGRESS);
            repair.ChangeRepairStatus(ERepairStatus.COMPLETE);

            var act = () => repair.ChangeRepairStatus(ERepairStatus.PENDING);

            act.Should().Throw<Exception>();
        }
    }
}
