using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDAL.Data.Models
{
    public class Product
    {

        public string Category { get; set; } = string.Empty;
        [Range(1,100)]
        public Guid Id { get; set; }
        [StringLength(20,MinimumLength=3)]
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Range(1,100000)]
        public int Price { get; set; }
        public string MinimumQuality { get; set; } = string.Empty;
        public decimal DiscountRate { get; set; }

        //NavProps
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
