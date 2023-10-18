using ECommerceBL.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBL.Managers.Product
{
    public interface IProductManager
    {
        IEnumerable<ProductReadDto> GetAll();
        ProductReadDto? GetProductById(Guid id);
        System.Guid Add(ProductAddDto product);
        bool Update(ProductUpdateDto product);
        bool Delete(Guid id);

    }
}
