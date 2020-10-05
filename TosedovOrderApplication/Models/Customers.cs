using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TosedovOrderApplication.Models
{
    public class Customers
    {
        
       
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
