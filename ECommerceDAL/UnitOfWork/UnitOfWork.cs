using ECommerceDAL.Data.Context;
using ECommerceDAL.Repos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDAL.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        public IProductRepo ProductRepo { get; }
      
        private readonly ECommerceContext _ecommerceContext;

        public UnitOfWork
            (
                ECommerceContext ecommerceContext,
                IProductRepo productRepo
                
            )
        {
            _ecommerceContext = ecommerceContext;
            ProductRepo = productRepo;
     
        }
        public async Task<int> save() => await _ecommerceContext.SaveChangesAsync();
    }
}
