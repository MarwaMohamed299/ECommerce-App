using ECommerceBL.DTOs.Products;
using ECommerceBL.Managers.Product;
using ECommerceDAL.Repos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBL.Managers.Products
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo _productRepo;

        public ProductManager(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public IEnumerable<ProductReadDto> GetAll()
        {
            IEnumerable<ECommerceDAL.Data.Models.Product> productFromDb = _productRepo.GetAll();
            return productFromDb.Select(A => new ProductReadDto
            {
                Category= A.Category,
                Image = A.Image,
                DiscountRate = A.DiscountRate,
                Price= A.Price,
                Name=A.Name,
                Id=A.Id,
                MinimumQuality=A.MinimumQuality
                
            });
        }


        public ProductReadDto? GetProductById(Guid id)
        {
            ECommerceDAL.Data.Models.Product? ProductFromDb = _productRepo.GetProductById(id);
            if (ProductFromDb == null)
            {
                return null;
            }
            return new ProductReadDto
            {
                Id = ProductFromDb.Id,
                Image = ProductFromDb.Image,
                Name = ProductFromDb.Name,
                MinimumQuality = ProductFromDb.MinimumQuality,
                Category = ProductFromDb.Category,
                DiscountRate = ProductFromDb.DiscountRate,
                Price = ProductFromDb.Price
            };
        }
        public Guid Add(ProductAddDto ProductFromRequest)
        {
            ECommerceDAL.Data.Models.Product product = new ECommerceDAL.Data.Models.Product
            {
                Name = ProductFromRequest.Name,
                Image = ProductFromRequest.Image,
                Category = ProductFromRequest.Category,
                DiscountRate = ProductFromRequest.DiscountRate,
                MinimumQuality = ProductFromRequest.MinimumQuality,
                Price = ProductFromRequest.Price,
                
            };
            _productRepo.Add(product);
            _productRepo.SaveChanges();
            return product.Id;


        }
        public bool Update(ProductUpdateDto productFromRequest)
        {
            ECommerceDAL.Data.Models.Product product = _productRepo.GetProductById(productFromRequest.Id);
            if (productFromRequest == null)
            {
                return false;
            }
            productFromRequest.Image = product.Image;
            productFromRequest.Name = product.Name;
            _productRepo.Update(product);
            _productRepo.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            ECommerceDAL.Data.Models.Product? product= _productRepo.GetProductById(Id);
            if (product == null)
            {
                return false;
            }
            _productRepo.Delete(product);

            _productRepo.SaveChanges();
            return true;
        }

      
    }
}
