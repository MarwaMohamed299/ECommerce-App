using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDAL.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        [StringLength(20,MinimumLength =2)]
        public string DisplayName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string City { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one digit.")]

        public string Password { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime LastLogin { get; set; }

        //NavProps
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
