using Bookworm.Data;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers
{
    public class LivroController : Controller
    {
        private readonly ApplicationtDbContext _db;

        public LivroController(ApplicationtDbContext db){
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Livro> objLivroList = _db.Livro;
            return View(objLivroList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro)
        {
            _db.Livro.Add(livro);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
