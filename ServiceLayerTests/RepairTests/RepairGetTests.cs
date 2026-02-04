using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.RepairTests
{
    public class RepairGetTests
    {
        //--------------------------------------------------------------------------------------
        //------------------------- GetByCustomerNameAsync -------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnRepairs_WhenCustomerExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnEmptyList_WhenCustomerHasNoRepairs()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldThrowException_WhenNameIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByEntryDateAsync ----------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByEntryDateAsync_ShouldReturnRepairs_WhenDateMatches()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByEntryDateAsync_ShouldReturnEmptyList_WhenNoRepairsMatchDate()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByPeriodOfEntryDateAsync --------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByPeriodOfEntryDateAsync_ShouldReturnRepairs_WhenDatesAreValid()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPeriodOfEntryDateAsync_ShouldReturnEmptyList_WhenNoRepairsInRange()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPeriodOfEntryDateAsync_ShouldThrowException_WhenMinDateIsGreaterThanMaxDate()
        {
            throw new NotImplementedException();
        }
    }
}
