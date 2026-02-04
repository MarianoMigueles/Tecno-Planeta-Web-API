using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.AuthTests
{
    public class AuthPutTests
    {
        [Fact]
        public async Task RegisterAsync_ShouldCreateUser_WhenDataIsValid()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task RegisterAsync_ShouldReturnUserResponseDTO_WhenRegisterSucceeds()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task RegisterAsync_ShouldHashPassword_BeforeSavingUser()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task RegisterAsync_ShouldCallUnitOfWorkSave_WhenUserIsCreated()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task RegisterAsync_ShouldThrowException_WhenRequestIsNull()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task RegisterAsync_ShouldThrowException_WhenPasswordIsEmpty()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task RegisterAsync_ShouldThrowException_WhenRepositoryFails()
        {
            throw new NotImplementedException();
        }

    }
}
