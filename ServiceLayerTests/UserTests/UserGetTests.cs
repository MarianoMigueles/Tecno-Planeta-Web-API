using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.UserTests
{
    public class UserGetTests
    {
        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByRolAsync -------------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetAllByRolAsync_ShouldReturnUsers_WhenRolExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByRolAsync_ShouldReturnEmptyList_WhenNoUsersMatchRol()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetAllBySectorAsync ----------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllBySectorAsync_ShouldReturnUsers_WhenSectorExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllBySectorAsync_ShouldReturnEmptyList_WhenNoUsersMatchSector()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByNameAsync ---------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByNameAsync_ShouldReturnUser_WhenNameExists()
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

    }
}
