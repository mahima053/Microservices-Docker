using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApplication1.MediatR
{
    public class AddCustomerRequest : Customer, IRequest<Guid> { }
    
    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, Guid>
    {
        private readonly ICustomerRepository _cusRepo;
        public AddCustomerHandler(ICustomerRepository customerRepository)
        {
            _cusRepo = customerRepository;
        }

        public async Task<Guid> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            var cus = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress
            };
            await _cusRepo.AddCustomer(cus);

            return cus.Id;
        }
    }

    
}
