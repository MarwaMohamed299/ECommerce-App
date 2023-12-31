﻿using ECommerceBL.DTOs.Products;
using ECommerceBL.GeneralResponse;
using ECommerceBL.Managers.Product;
using ECommerceDAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_App.Controllers.ProductsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
       // [Authorize]

        public ActionResult<List<ProductReadDto>> GetAll()
        {
            return _productManager.GetAll().ToList();
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductReadDto> GetProductById(Guid id)
        {
            ProductReadDto? Product = _productManager.GetProductById(id);
            if (Product is null)
            {
                return NotFound();
            }
            return Product;
        }

        [HttpPost]
        public ActionResult Add(ProductAddDto productDto)
        {
            var newId = _productManager.Add(productDto);

            return CreatedAtAction(nameof(GetProductById),
                new { id = newId },
                new GeneralResponse("Product Has Been Added Successfully!"));

        }

        [HttpPut]
        public ActionResult Update(ProductUpdateDto productDto)

        {
            var isFound = _productManager.Update(productDto);
            if (!isFound)
            {
                return NotFound();
            }
            return Ok("Product is Updated Successfully");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {   
            var isFound = _productManager.Delete(id);
            if (!isFound)
            {
                return NotFound();

            }
            return Ok("Product is Deleted Successfully");

        }
    }
}
