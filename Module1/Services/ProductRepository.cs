using Module1.Data;
using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Services
{
    public class ProductRepository : IProduct
    {
        private ProductBDContext productBDContext;

        public ProductRepository(ProductBDContext _productBDContext)
        {
            productBDContext = _productBDContext;
        }

        public void DeleteProduct(int id)
        {
            var product = productBDContext.Products.Find(id);
            if(product != null) productBDContext.Products.Remove(product);
            productBDContext.SaveChanges(true);
        }

        public Product GetProduct(int id)
        {
            var product = productBDContext.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productBDContext.Products; //rr informaticos jueves 9:30 //centura - 
        }

        public void PostProduct(Product product)
        {
            productBDContext.Products.Add(product);
            productBDContext.SaveChanges(true);
        }

        public void UpdateProduct(Product product)
        {
            productBDContext.Products.Update(product);
            productBDContext.SaveChanges(true);
        }
    }
}
