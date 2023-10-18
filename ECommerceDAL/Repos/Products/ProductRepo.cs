using ECommerceDAL.Data.Context;
using ECommerceDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDAL.Repos.Products
{
    public class ProductRepo : IProductRepo
    {
        private readonly ECommerceContext _ecommerceContext;

        public ProductRepo(ECommerceContext ecommerceContext)//removed base (ecommerce context)
        {
            _ecommerceContext = ecommerceContext;
        }


        public IEnumerable<Product> GetAll()
        {
            return _ecommerceContext.Set<Product>().ToList();

        }

        public Product GetProductById(Guid Id)
        {
            return _ecommerceContext.Set<Product>().Find(Id);
        }

        public int SaveChanges()
        {
            return _ecommerceContext.SaveChanges();
        }
        public void Add(Product product)
        {
            _ecommerceContext.Set<Product>().Add(product);
        }


        public void Delete(Product product)
        {
            _ecommerceContext.Set<Product>().Remove(product);
        }

        public void Update(Product product)
        {
        }

    }
}
