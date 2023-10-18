using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBL.DTOs.Products
{
      public class ProductUpdateDto
    {
        public required string Category { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Image { get; set; } = string.Empty;
        public required int Price { get; set; }
        public required string MinimumQuality { get; set; } = string.Empty;
        public required decimal DiscountRate { get; set; }
    }
}
