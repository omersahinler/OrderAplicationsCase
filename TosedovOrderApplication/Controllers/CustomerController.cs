using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TosedovOrderApplication.Models;
using TosedovOrderApplication.Models.DTO;
using TosedovOrderApplication.Services;


namespace TosedovOrderApplication.Controllers
{
    [Route("Customer")]
    [ApiController]
   
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Create")]

        public async Task<IActionResult> Create(CustomerCreateDTO create)
        {
             if (ModelState.IsValid)
            {
                var customer = await _customerService.Create(create);
                if (customer != null)
                    return Created(customer, null);
                else
                    return BadRequest();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string Id)
        {
            var Custumer = await _customerService.Delete(Id);
            if (Custumer)
                return Ok();
            return NotFound();
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update(CustomerUpdateDTO update)
        {
            var Custumer = await _customerService.Update(update);
            if (Custumer)
                return Ok();
            return NotFound();
        }
        [HttpGet("Customers")]
        public async Task<IEnumerable<Customers>> Get() =>
           await _customerService.Get();
        [HttpGet("CustomerId")]
        public async Task<Customers> GetId(string id) =>
           await _customerService.GetId(id);
        [HttpGet("Validate")]
        public async Task<bool> Validate(string email) =>
          await _customerService.Validate(email);
    }
}
