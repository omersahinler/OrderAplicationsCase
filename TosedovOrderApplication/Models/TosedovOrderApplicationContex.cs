using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TosedovOrderApplication.Models
{
    public class TosedovOrderApplicationContex: DbContext
    {
        public TosedovOrderApplicationContex(DbContextOptions<TosedovOrderApplicationContex> options) : base(options) { }
        
        public DbSet<Customers> Customers { get; set; }
    }
}
