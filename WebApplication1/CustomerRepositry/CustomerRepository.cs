using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContex;

namespace WebApplication1
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext _customerContext;
        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
           customer.Id = Guid.NewGuid();
            await _customerContext.Customers.AddAsync(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerContext.Customers.ToListAsync();

        }
    
    }
}

