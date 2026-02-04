using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.AuthTests
{
    public class AuthGetTests
    {
        [Fact]
        public async Task LoginAsync_ShouldReturnJwtToken_WhenCredentialsAreValid()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenUserDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenPasswordIsIncorrect()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenEmailIsEmpty()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowException_WhenPasswordIsEmpty()
        {
            throw new NotImplementedException();
        }

    }
}
