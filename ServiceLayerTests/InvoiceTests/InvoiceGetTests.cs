using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.InvoiceTests
{
    public class InvoiceGetTests
    {

        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByIssueDateAsync -------------------------------------
        //--------------------------------------------------------------------------------------
        [Fact]
        public async Task GetAllByIssueDateAsync_ShouldReturnInvoices_WhenDateMatches()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByIssueDateAsync_ShouldReturnEmptyList_WhenNoInvoicesMatchDate()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByOperationTypeAsync ---------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllByOperationTypeAsync_ShouldReturnInvoices_WhenTypeExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByOperationTypeAsync_ShouldReturnEmptyList_WhenNoInvoicesMatchType()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetAllByStatusAsync ----------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetAllByStatusAsync_ShouldReturnInvoices_WhenStatusExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetAllByStatusAsync_ShouldReturnEmptyList_WhenNoInvoicesMatchStatus()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByCustomerNameAsync -------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnInvoice_WhenCustomerExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldReturnNull_WhenCustomerDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByCustomerNameAsync_ShouldThrowException_WhenNameIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetByNumberAsync -------------------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetByNumberAsync_ShouldReturnInvoice_WhenNumberExists()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByNumberAsync_ShouldReturnNull_WhenNumberDoesNotExist()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetByNumberAsync_ShouldThrowException_WhenNumberIsInvalid()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetContainsProductIdAsync ----------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetContainsProductIdAsync_ShouldReturnInvoices_WhenProductIdsMatch()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetContainsProductIdAsync_ShouldReturnEmptyList_WhenNoInvoicesContainProducts()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetContainsProductIdAsync_ShouldThrowException_WhenIdsListIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------
        //------------------------- GetContainsServiceIdAsync ----------------------------------
        //--------------------------------------------------------------------------------------

        [Fact]
        public async Task GetContainsServiceIdAsync_ShouldReturnInvoices_WhenServiceIdsMatch()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetContainsServiceIdAsync_ShouldReturnEmptyList_WhenNoInvoicesContainServices()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task GetContainsServiceIdAsync_ShouldThrowException_WhenIdsListIsNullOrEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
