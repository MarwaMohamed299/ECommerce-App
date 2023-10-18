using ECommerceDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDAL.Repos.Products
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAll();
        Product GetProductById(Guid Id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        int SaveChanges();
    }
}
