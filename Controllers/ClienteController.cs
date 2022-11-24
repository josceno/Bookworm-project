using Bookworm.Data;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationtDbContext _db;

        public ClienteController(ApplicationtDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> objClienteList = _db.Cliente;
            return View(objClienteList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            _db.Cliente.Add(cliente);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
