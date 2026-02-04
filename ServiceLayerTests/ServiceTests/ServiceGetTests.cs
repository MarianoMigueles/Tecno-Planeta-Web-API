using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.ServiceTests
{
    public class ServiceGetTests
    {
        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByPriceRangeAsync ------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetAllByPriceRangeAsync_ShouldReturnServices_WhenPricesAreInRange()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByPriceRangeAsync_ShouldReturnEmptyList_WhenNoServicesInRange()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByPriceRangeAsync_ShouldThrowException_WhenMinIsGreaterThanMax()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByNameAsync ---------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByNameAsync_ShouldReturnService_WhenNameExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByNameAsync_ShouldReturnNull_WhenNameDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByNameAsync_ShouldThrowException_WhenNameIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByPeriotOfEstimatedTimeAsync ----------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByPeriotOfEstimatedTimeAsync_ShouldReturnServices_WhenTimeIsInRange()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPeriotOfEstimatedTimeAsync_ShouldReturnEmptyList_WhenNoServicesInRange()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPeriotOfEstimatedTimeAsync_ShouldThrowException_WhenMinIsGreaterThanMax()
        {
            throw new NotImplementedException();
        }


    }
}
