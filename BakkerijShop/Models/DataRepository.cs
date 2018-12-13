using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakkerijShop.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>(); nu data-acces via context
        private DataContext context;

        public DataRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Product> Products => context.Products.ToArray();

        public void AddProduct(Product product)
        {
            this.context.Add(product);
            this.context.SaveChanges();
        }
    }
}
