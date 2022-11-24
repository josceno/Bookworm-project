using Bookworm.Data;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers
{
    public class EditoraController : Controller
    {

        private readonly ApplicationtDbContext _db;

        public EditoraController(ApplicationtDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Editora> objEditoraList = _db.Editora;
            return View(objEditoraList);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
