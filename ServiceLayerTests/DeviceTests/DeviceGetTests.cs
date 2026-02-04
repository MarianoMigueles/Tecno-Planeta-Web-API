using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.DeviceTests
{
    public class DeviceGetTests
    {
        //--------------------------------------------------------------------------------------
        //------------------------- GetByCustomerName ------------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnDevices_WhenCustomerExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnEmptyList_WhenCustomerHasNoDevices()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldThrowException_WhenCustomerNameIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByType -----------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllByTypeAsync_ShouldReturnDevices_WhenTypeExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByTypeAsync_ShouldReturnEmptyList_WhenNoDevicesMatchType()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByTypeAsync_ShouldThrowException_WhenTypeIsInvalid()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByModel ----------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllByModelAsync_ShouldReturnDevices_WhenModelExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByModelAsync_ShouldReturnEmptyList_WhenModelDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByModelAsync_ShouldThrowException_WhenModelIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByBrand ----------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllByBrandAsync_ShouldReturnDevices_WhenBrandExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByBrandAsync_ShouldReturnEmptyList_WhenBrandDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByBrandAsync_ShouldThrowException_WhenBrandIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }

    }
}
