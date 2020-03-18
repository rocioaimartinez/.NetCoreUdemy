using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Services
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void PostProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
