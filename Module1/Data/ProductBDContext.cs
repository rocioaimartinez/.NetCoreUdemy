using Microsoft.EntityFrameworkCore;
using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Data
{
    public class ProductBDContext : DbContext
    {
        public ProductBDContext(DbContextOptions<ProductBDContext>options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
