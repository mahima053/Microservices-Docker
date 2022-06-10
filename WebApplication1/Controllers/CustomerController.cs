using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.MediatR;
//using WebApplication1.MediatR;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        
        public async Task<IEnumerable<Customer>> GetCustomer() => await _mediator.Send(new GetCustomerRequest());

        [HttpPost]

        public async Task<ActionResult> CreateCustomer([FromBody] AddCustomerRequest addCustomerRequest)
        {
            try
            {
                var createCusId = await _mediator.Send(addCustomerRequest);
                return CreatedAtAction(nameof(GetCustomer), new { id = createCusId }, null);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
 
        [HttpGet("{id}")]
        public async Task<Customer> GetCus(Guid id) => await _mediator.Send(new GetCusByIdRequest { Id = id });

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCustomerRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            await _mediator.Send(new DeleteCustomerRequest { Id = id });
            return NoContent();
}


    }
}
