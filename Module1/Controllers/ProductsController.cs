using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Data;
using Module1.Models;

namespace Module1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductBDContext productBDContext;

        public ProductsController(ProductBDContext _productBDContext)
        {
            productBDContext = _productBDContext;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get(string sortPrice)
        {
            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = productBDContext.Products.OrderByDescending(p => p.Price);
                    break;
                case "asc":
                    products = productBDContext.Products.OrderBy(p => p.Price);
                    break;
                default:
                    products = productBDContext.Products;
                    break;
            }
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = productBDContext.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("No record found");
            }
            return Ok(product);
        }


        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productBDContext.Products.Add(product);
            productBDContext.SaveChanges(true);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.Id)
            {
                return BadRequest();
            }
            try
            {
                productBDContext.Products.Update(product);
                productBDContext.SaveChanges(true);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound("Product Id doesn't exist");
            }
            
            return Ok("Product Updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = productBDContext.Products.SingleOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound("No record Found");
            }
            productBDContext.Products.Remove(product);
            productBDContext.SaveChanges(true);
            return Ok("Record deleted");
        }
    }
}
