using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TosedovOrderApplication.Models;
using TosedovOrderApplication.Models.DTO;

namespace TosedovOrderApplication.Services.Interfaces
{
    public interface ICustomerServices
    {
        Task<string> Create(CustomerCreateDTO create);
        Task<bool> Update(CustomerUpdateDTO update);
        Task<bool> Delete(string Id);
        Task<IEnumerable<Customers>> Get();
        Task<Customers> GetId(string id);



    }
}
