using Bookworm.Data;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers
{
    public class AutorController : Controller
    {

        private readonly ApplicationtDbContext _db;

        public AutorController(ApplicationtDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Autor> objAutorList = _db.Autor;
            return View(objAutorList);  
        }
    }
}
