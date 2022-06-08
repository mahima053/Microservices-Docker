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

        public async Task DeleteCustomer(Task<Customer> customer)
        {
            _customerContext.Customers.Remove(await customer);
            await _customerContext.SaveChangesAsync();
        }

        public async Task<Customer> EditCustomer(Customer customer)
        {
            var existingCustomer = _customerContext.Customers.Find(customer.Id);
            if (existingCustomer != null)
            {

                _customerContext.Customers.Update(existingCustomer);
                await _customerContext.SaveChangesAsync();

            }
            return (customer);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerContext.Customers.ToListAsync();

        }

       

        public async Task<Customer> GetAllCustomers(Guid id)
        {
            var customer = await _customerContext.Customers.FindAsync(id);
            return customer;
        }
    }
}

