using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakkerijShop.Models
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> Categories { get; }

        void AddCategorie(Categorie categorie);
        void UpdateCategorie(Categorie categorie);
        void DeleteCategorie(Categorie categorie);
    }

    public class CategorieRepository : ICategorieRepository
    {
        private DataContext context;

        public CategorieRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Categorie> Categories => context.Categories;

        public void AddCategorie(Categorie categorie)
        {
            context.Categories.Add(categorie);
            context.SaveChanges();
        }

        public void UpdateCategorie(Categorie categorie)
        {
            context.Categories.Update(categorie);
            context.SaveChanges();
        }

        public void DeleteCategorie(Categorie categorie)
        {
            context.Categories.Remove(categorie);
            context.SaveChanges();
        }
    }
}
