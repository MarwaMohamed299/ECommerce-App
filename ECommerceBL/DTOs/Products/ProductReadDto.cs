using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBL.DTOs.Products
{
    public class ProductReadDto
    {
        public  string Category { get; set; } = string.Empty;
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Price { get; set; }
        public string MinimumQuality { get; set; } = string.Empty;
        public decimal DiscountRate { get; set; }
        public Guid UserId { get; set; }

    }
}
