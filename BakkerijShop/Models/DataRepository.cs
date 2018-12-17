using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakkerijShop.Models
{
    public class DataRepository : IRepository
    {
        private DataContext context;

        public DataRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Product> Products => context.Products
            .Include(p => p.Categorie).ToArray();

        public Product GetProduct(long key) => context.Products
            .Include(p => p.Categorie).First(p => p.Id == key);

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product p = context.Products.Find(product.Id);
            p.Naam = product.Naam;
            //p.Category = product.Category;
            p.Prijs = product.Prijs;
            p.CategorieId = product.CategorieId;
            context.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            //context.Products.UpdateRange(products);

            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline =
                context.Products.Where(p => data.Keys.Contains(p.Id));

            foreach (Product databaseProduct in baseline)
            {
                Product requestProduct = data[databaseProduct.Id];
                databaseProduct.Naam = requestProduct.Naam;
                databaseProduct.Categorie = requestProduct.Categorie;
                databaseProduct.Prijs = requestProduct.Prijs;
            }
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

    }
}
