using ECommerceDAL.Repos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDAL.UnitOfWork
{
    public interface IUnitOfWork 
    {
        public IProductRepo ProductRepo { get; }
        Task<int> save();


    }
}
