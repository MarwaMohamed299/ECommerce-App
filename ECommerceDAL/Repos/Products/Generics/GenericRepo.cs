using ECommerceDAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDAL.Repos.Products.Generics
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ECommerceContext _ecommerceContext;

        public GenericRepo(ECommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<IEnumerable<T>> GetAllProperties()
        {
            return await _ecommerceContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _ecommerceContext.Set<T>().FindAsync(id);
        }
        public async void Add(T item)
        {
            await _ecommerceContext.Set<T>().AddAsync(item);
        }
        public void Update(T item)
        {
            _ecommerceContext?.Set<T>().Update(item);
        }
        public void Delete(T item)
        {
            _ecommerceContext.Set<T>().Remove(item);
        }

        Task<IEnumerable<T>> IGenericRepo<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepo<T>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
