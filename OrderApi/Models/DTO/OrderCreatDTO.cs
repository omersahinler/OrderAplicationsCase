using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models.DTO
{

    public class OrderCreateDTO
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string CustomerId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public DateTime CreatedAt = DateTime.Now;

    }
}
