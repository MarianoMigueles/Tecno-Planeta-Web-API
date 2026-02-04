using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.RepairTests
{
    public class RepairPatchTests
    {
        //--------------------------------------------------------------------------------------
        //------------------------- CancelRepairAsync ------------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task CancelRepairAsync_ShouldCancelRepair_WhenRepairExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task CancelRepairAsync_ShouldThrowException_WhenRepairDoesNotExist()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- UpdateCostAsync --------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task UpdateCostAsync_ShouldUpdateCost_WhenRepairExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateCostAsync_ShouldThrowException_WhenRepairDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateCostAsync_ShouldThrowException_WhenCostIsNegative()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- UpdateNoteAsync --------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task UpdateNoteAsync_ShouldUpdateNote_WhenRepairExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateNoteAsync_ShouldThrowException_WhenRepairDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateNoteAsync_ShouldThrowException_WhenNoteIsNull()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- UpdateStatusAsync ------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task UpdateStatusAsync_ShouldUpdateStatus_WhenRepairExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowException_WhenRepairDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowException_WhenStatusIsInvalid()
        {
            throw new NotImplementedException();
        }

    }
}
