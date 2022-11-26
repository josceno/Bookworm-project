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
            if (cliente.NomeCliente == cliente.edereco.ToString())
            {
                ModelState.AddModelError("CumstomError", "Caixas com o mesmo nome ");
            }
            if (ModelState.IsValid)
            {
                _db.Cliente.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Edit(string? id)
        {

            if (id == null || id == "")
            {
                return NotFound();
            }

            var ClienteFromDb = _db.Cliente.FirstOrDefault(u => u.cpf == id);

            Console.WriteLine(id);
            Console.WriteLine(ClienteFromDb);
            if (ClienteFromDb == null)
            {
                return NotFound();
            }
            return View(ClienteFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (cliente.NomeCliente == cliente.edereco.ToString())
            {
                ModelState.AddModelError("CumstomError", "Caixas com o mesmo nome");
            }
            if (ModelState.IsValid)
            {
                _db.Cliente.Update(cliente);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        public IActionResult Delete(string? id)
        {

            if (id == null || id == "")
            {
                return NotFound();
            }
            var ClienteFromDb = _db.Cliente.Find(id);
            Console.WriteLine(id);
            Console.WriteLine(ClienteFromDb);
            if (ClienteFromDb == null)
            {
                return NotFound();
            }
            return View(ClienteFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string? id)
        {
            var obj = _db.Cliente.Find(id);
            if (obj == null) { return NotFound(); }
            _db.Cliente.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
