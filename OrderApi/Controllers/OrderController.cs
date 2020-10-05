using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.Models.DTO;
using OrderApi.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [Route("Order")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly OrdersService _ordersService;
        public OrderController(OrdersService OrdersService)
        {
            _ordersService = OrdersService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderCreateDTO create)
        {
            if (ModelState.IsValid)
            {
                var order = await _ordersService.Create(create);
                if (order != null)
                    return Created(nameof(order), null);
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
            var order = await _ordersService.Delete(Id);
            if (order)
                return Ok();
            return NotFound();
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update(OrderUpdateDTO update)
        {
            var order = await _ordersService.Update(update);
            if (order)
                return Ok();
            return NotFound();
        }
        [HttpGet("Orders")]
        public async Task<IEnumerable<Orders>> Get() =>
           await _ordersService.Get();
        [HttpGet("OrderCustomerId")]
        public async Task<Orders> GetOrderCustomerId(string CustomerId) =>
           await _ordersService.GetOrderCustomerId(CustomerId);
        [HttpGet("OrderId")]
        public async Task<Orders> GetOrdersId(string Id) =>
          await _ordersService.GetOrdersId(Id);
        [HttpPut("ChangeStatus")]
        public async Task<ActionResult> ChangeStatus(string newStatus, string Id)
        {
            var order = await _ordersService.ChangeStatus(newStatus, Id);
            if (order)
                return Ok();
            return NotFound();
        }
    }
}
