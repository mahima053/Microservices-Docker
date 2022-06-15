using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApplication1.MediatR
{
    public class DeleteCustomerRequest : IRequest
    {
        public Guid Id { get; set; }
    }
        public class DeleteEmployeeHandler : IRequestHandler<DeleteCustomerRequest, Unit>
        {
            private readonly ICustomerRepository _cusRepo;
            public DeleteEmployeeHandler(ICustomerRepository customerRepository)
            {
                _cusRepo = customerRepository;
            }
            public async Task<Unit> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
            {
                var customer = _cusRepo.GetAllCustomers(request.Id);
                if(customer != null)
                {
                    await _cusRepo.DeleteCustomer(customer);
                }
                return Unit.Value;
            }
        }
}
