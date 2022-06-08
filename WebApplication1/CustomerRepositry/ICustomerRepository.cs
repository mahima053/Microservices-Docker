using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
   public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetAllCustomers(Guid id);
        Task<Customer> AddCustomer(Customer customer);

        Task DeleteCustomer(Task<Customer> customer);

        Task<Customer> EditCustomer(Customer customer);
      
    }
}
