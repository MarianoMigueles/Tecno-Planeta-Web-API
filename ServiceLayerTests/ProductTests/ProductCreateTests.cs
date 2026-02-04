using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.ProductTests
{
    public class ProductCreateTests : ProductServiceTestBase
    {
        [Fact]
        public async Task CreateAsync_ShouldCreateProduct_WhenDataIsValid()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenProductIsNull()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenProductAlreadyExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenRepositoryFails()
        {
            throw new NotImplementedException();
        }

    }
}
