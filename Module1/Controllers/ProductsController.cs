using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Data;
using Module1.Models;
using Module1.Services;

namespace Module1.Controllers
{
    //[ApiVersion("1.0")]
    [Produces("application/json")]
    //[Route("api/v{version:apiVersion}/Products")]
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct productRepository;

        public ProductsController(IProduct _productRepository)
        {
            productRepository = _productRepository;
        }

        // GET: api/Productsblob:file:///51a3546f-6fd7-4686-9283-c2f71a779bc9
        [HttpGet]
        public IEnumerable<Product> Get(string searchCriteria)
        {
            //var products = productBDContext.Products.Where(p => p.ProductName.StartsWith(searchCriteria));
            return productRepository.GetProducts();
        }
        //public IEnumerable<Product> Get(int? pageNumber, int? pageSize)
        //{
        //    var products = from p in productBDContext.Products.OrderBy(a => a.Id) select p;
        //    int currentPage = pageNumber ?? 1;
        //    int currentSize = pageSize ?? 5;
        //    var items = products.Skip((currentPage - 1) * currentSize).Take(currentSize).ToList();
        //    return items;
        //}
        //public IEnumerable<Product> Get(string sortPrice)
        //{
        //    IQueryable<Product> products;
        //    switch (sortPrice)
        //    {
        //        case "desc":
        //            products = productBDContext.Products.OrderByDescending(p => p.Price);
        //            break;
        //        case "asc":
        //            products = productBDContext.Products.OrderBy(p => p.Price);
        //            break;
        //        default:
        //            products = productBDContext.Products;
        //            break;
        //    }
        //    return products;
        //}

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProduct(id);
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
            productRepository.PostProduct(product);
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
                productRepository.UpdateProduct(product);
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
            productRepository.DeleteProduct(id);
            return Ok("Record deleted");
        }
    }
}
