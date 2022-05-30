using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
   public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomers();

        Task<Customer> AddCustomer(Customer customer);

    }
}
