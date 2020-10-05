using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TosedovOrderApplication.Models;
using TosedovOrderApplication.Models.DTO;
using TosedovOrderApplication.Services.Interfaces;

namespace TosedovOrderApplication.Services
{
    public class CustomerService : ICustomerServices
    {
        private readonly DbSet<Customers> _customer;
        private readonly TosedovOrderApplicationContex _tosedovContex;
        private readonly IMapper _mapper;
        public CustomerService(TosedovOrderApplicationContex context, IMapper mapper)
        {
            _mapper = mapper;
            _customer = context.Customers;
            _tosedovContex = context;

        }
        public async Task<string> Create(CustomerCreateDTO create)
        {
            var cstmr = await _customer.AnyAsync(x => x.Id == create.Id);
            if (cstmr)
                return "The same id cannot be registered.";
            var customer = _mapper.Map<Customers>(create);
            
            await  _tosedovContex.Customers.AddAsync(customer);
            await _tosedovContex.SaveChangesAsync();
            var str = customer.ToString();
            return "customer created.";
        }
        public async Task<bool> Update(CustomerUpdateDTO update)
        {
            var customer = await _customer.SingleOrDefaultAsync(x => x.Id == update.Id);
            if (customer == null)
                return false;
            customer.Email = update.Email;
            customer.Name = update.Name;
            customer.UpdatedAt = update.UpdatedAt;
            return await _tosedovContex.SaveChangesAsync() > 0;
        }
        public async Task<bool> Delete(string Id)
        {
            var customer = await _customer.SingleOrDefaultAsync(x => x.Id == Id);
            _customer.Remove(customer);
            return await _tosedovContex.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Customers>> Get()
        {
           return await _customer.Select(x=>x)
                .OrderBy(x=>x.CreatedAt)
                .ToListAsync();
        }
        public async Task<Customers> GetId(string id)
        {
            return await _customer.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Validate(string email)
        {
            var Email = await _customer.AnyAsync(x => x.Email == email);
            if (!Email)
                return false;
            return true; 
        }

    }

    }

