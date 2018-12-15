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

        public IEnumerable<Product> Products => context.Products.ToArray();

        public Product GetProduct(long key) => context.Products.Find(key);

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            p.Naam = product.Naam;
            p.Categorie = product.Categorie;
            p.Prijs = product.Prijs;
            //context.Products.Update(product);
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
