using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.ProductTests
{
    public class ProductPatchTests : ProductServiceTestBase
    {
        [Fact]
        public async Task UpdateAsync_ShouldUpdateProduct_WhenProductExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenProductDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenProductIsNull()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenRepositoryFails()
        {
            throw new NotImplementedException();
        }

    }
}
