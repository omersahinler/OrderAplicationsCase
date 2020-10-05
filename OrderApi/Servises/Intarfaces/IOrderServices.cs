using OrderApi.Models;
using OrderApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Servises.Intarfaces
{
    public interface IOrderServices
    {
        Task<string> Create(OrderCreateDTO create);
        Task<bool> Update(OrderUpdateDTO update);
        Task<bool> Delete(string Id);
        Task<IEnumerable<Orders>> Get();
        Task<Orders> GetOrderCustomerId(string CustomerId);
        Task<Orders> GetOrdersId(string Id);
        Task<bool> ChangeStatus(string newStatus, string Id);
    }
}
