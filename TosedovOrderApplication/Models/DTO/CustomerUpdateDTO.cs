using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TosedovOrderApplication.Models.DTO
{
    public class CustomerUpdateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime UpdatedAt = DateTime.Now;
    }
}
