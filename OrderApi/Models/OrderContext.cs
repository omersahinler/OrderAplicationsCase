using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    
        public class OrderContext : DbContext
        {
            public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }
            public DbSet<Orders> Orders { get; set; }
           
        }
    
}
