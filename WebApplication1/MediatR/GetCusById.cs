using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApplication1.MediatR
{
    public class GetCusByIdRequest : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }

    public class GetCusByIdHandler : IRequestHandler<GetCusByIdRequest, Customer>
    {
        private readonly ICustomerRepository _cusRepo;
        public GetCusByIdHandler(ICustomerRepository customerRepository)
        {
            _cusRepo = customerRepository;
        }
        public async Task<Customer> Handle(GetCusByIdRequest request, CancellationToken cancellationToken)
        {
            return await _cusRepo.GetAllCustomers(request.Id);

        }
    }
}
