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
    }
}
