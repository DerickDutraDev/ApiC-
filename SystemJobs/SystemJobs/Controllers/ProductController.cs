using Microsoft.AspNetCore.Mvc;
using SystemJobs.Models;
using System.Collections.Generic;
using System.Linq;


namespace SystemJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "MacBook", Price = 1800.00m },
            new Product { Id = 2, Name = "iPhone", Price = 999.99m },
            new Product { Id = 3, Name = "iPad", Price = 799.99m }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            
            if (id != product.Id)
            {
                return BadRequest("O ID da URL não corresponde ao ID do produto fornecido.");
            }

            
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                
                return NotFound("Produto não encontrado.");
            }

            
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducts(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);
            return NoContent();
        }

    }
}
