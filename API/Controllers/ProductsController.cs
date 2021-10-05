using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IService<Product> _productService;
        public ProductsController()
        {
            _productService = new ProductManager();
        }

        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products); //200 + data
        }
        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Route("getProductById/{id}")] => api/products/getProductById/2
        public IActionResult Get(int id)
        {
            var products = _productService.GetById(id);
            return Ok(products); //200 + data
            
            
        }
        /// <summary>
        /// Create a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var createdProduct = _productService.Create(product);
            return CreatedAtAction("Get", new { id = createdProduct.ProductId }, createdProduct); //201 + data

        }
        /// <summary>
        /// Update the Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (_productService.GetById(product.ProductId) != null)
            {
                return Ok(_productService.Update(product));
            }
            return NotFound("Başarısız!!!!");

        }
        /// <summary>
        /// Delete the Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_productService.GetById(id) != null)
            {
                _productService.Delete(id);
                return Ok("Ürün silme işlemi başarılı..");
            }
            return NotFound("Böyle bir ürün bulunamadı!!!");

        }

    }
}
