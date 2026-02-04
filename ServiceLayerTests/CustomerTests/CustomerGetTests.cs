using Entities.Elements.ProductFolder;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.CustomerTests
{
    public class CustomerGetTests
    {
        //--------------------------------------------------------------------------------------
        //------------------------- GetByName --------------------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetByNameAsync_ShouldReturnCustomer_WhenNameExists()
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
        //------------------------- GetByPeriodOfTime ------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByPeriodOfTimeAsync_ShouldReturnCustomers_WhenDatesAreValid()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPeriodOfTimeAsync_ShouldReturnEmptyList_WhenNoCustomersInRange()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPeriodOfTimeAsync_ShouldThrowException_WhenMinDateIsGreaterThanMaxDate()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByPhoneAsync --------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByPhoneAsync_ShouldReturnCustomer_WhenPhoneExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPhoneAsync_ShouldReturnNull_WhenPhoneDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByPhoneAsync_ShouldThrowException_WhenPhoneIsInvalid()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByRegisterDateAsync -------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByRegisterDateAsync_ShouldReturnCustomer_WhenDateMatches()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByRegisterDateAsync_ShouldReturnNull_WhenDateDoesNotMatch()
        {
            throw new NotImplementedException();
        }

    }
}
