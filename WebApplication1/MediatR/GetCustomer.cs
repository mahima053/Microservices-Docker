using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApplication1.MediatR
{
    public class GetCustomerRequest : IRequest<IEnumerable<Customer>> { }

    public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _cusRepo;
        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _cusRepo = customerRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            return await _cusRepo.GetAllCustomers();
        }
    }
}
