using Microsoft.AspNetCore.Mvc;
using BakkerijShop.Models;

namespace BakkerijShop.Controllers
{

    public class CategoriesController : Controller
    {
        private ICategorieRepository repository;

        public CategoriesController(ICategorieRepository repo) => repository = repo;

        public IActionResult Index() => View(repository.Categories);

        [HttpPost]
        public IActionResult AddCategorie(Categorie categorie)
        {
            repository.AddCategorie(categorie);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCategorie(long id)
        {
            ViewBag.EditId = id;
            return View("Index", repository.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategorie(Categorie categorie)
        {
            repository.UpdateCategorie(categorie);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteCategorie(Categorie categorie)
        {
            repository.DeleteCategorie(categorie);
            return RedirectToAction(nameof(Index));
        }
    }
}