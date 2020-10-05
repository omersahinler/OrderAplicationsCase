using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models;
using OrderApi.Models.DTO;
using OrderApi.Servises.Intarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Servises
{
    public class OrdersService : IOrderServices
    {
        private readonly DbSet<Orders> _order;
        private readonly OrderContext _contex;
        private readonly IMapper _mapper;
        public OrdersService(OrderContext contex, IMapper mapper)
        {
            _mapper = mapper;
            _contex = contex;
            _order = _contex.Orders;
        }
        public async Task<string> Create(OrderCreateDTO create)
        {
            var ordr = await _order.AnyAsync(x => x.Id == create.Id);
            if (ordr)
                return "The same id cannot be registered.";
            var order = _mapper.Map<Orders>(create);
            await _order.AddAsync(order);
            await _contex.SaveChangesAsync();
            return "order created.";
        }
        public async Task<bool> Update(OrderUpdateDTO update)
        {
            var order = await _order.SingleOrDefaultAsync(x => x.Id == update.Id);
            if (order == null)
                return false;
            order.CustomerId = update.CustomerId;
            order.ImageUrl = update.ImageUrl;
            order.UpdatedAt = update.UpdatedAt;
            order.Price = update.Price;
            order.Status = update.Status;
            order.Quantity = update.Quantity;
            return await _contex.SaveChangesAsync() > 0;
        }
        public async Task<bool> Delete(string Id)
        {
            var customer = await _order.SingleOrDefaultAsync(x => x.Id == Id);
            _order.Remove(customer);
            return await _contex.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Orders>> Get()
        {
            return await _order.Select(x => x)
                 .OrderBy(x => x.CreatedAt)
                 .ToListAsync();
        }
        public async Task<Orders> GetOrderCustomerId(string CustomerId)
        {
            return await _order.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
        }
        public async Task<Orders> GetOrdersId(string Id)
        {
            return await _order.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<bool> ChangeStatus(string newStatus, string Id)
        {
            var status = await _order.FirstOrDefaultAsync(x => x.Id == Id);
            if (status == null)
                return false;
            status.Status = newStatus;
            return await _contex.SaveChangesAsync() > 0;
        }

    }
}
