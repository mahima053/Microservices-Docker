using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApplication1.MediatR
{
    public class UpdateCustomerRequest : Customer, IRequest<Guid>
    {
    }

    public class UpdateEmployeeHandler : IRequestHandler<UpdateCustomerRequest, Guid>
    {
        private ICustomerRepository _cusRepo;

        public UpdateEmployeeHandler(ICustomerRepository customerRepository)
        {
            _cusRepo = customerRepository;
        }

        public async Task<Guid> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var Customer = await _cusRepo.GetAllCustomers(request.Id);
            {
                Customer.FirstName = request.FirstName;
                Customer.LastName = request.LastName;
                Customer.EmailAddress = request.EmailAddress;

                await _cusRepo.EditCustomer(Customer);
                return Customer.Id;
            }
        }

    }
}
