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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor autor)
        {
            if (autor.nameAutor == autor.LocalNascimento.ToString())
            {
                ModelState.AddModelError("CumstomError", "Caixas com o mesmo nome ");
            }
            if (ModelState.IsValid)
            {
                _db.Autor.Add(autor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var AutorFromDb = _db.Autor.FirstOrDefault(u => u.Id_Autor == id);

            Console.WriteLine(id);
            Console.WriteLine(AutorFromDb);
            if (AutorFromDb == null)
            {
                return NotFound();
            }
            return View(AutorFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Autor autor)
        {
            if (autor.nameAutor == autor.LocalNascimento.ToString())
            {
                ModelState.AddModelError("CumstomError", "Caixas com o mesmo nome");
            }
            if (ModelState.IsValid)
            {
                _db.Autor.Update(autor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var AutorFromDb = _db.Autor.Find(id);
            Console.WriteLine(id);
            Console.WriteLine(AutorFromDb);
            if (AutorFromDb == null)
            {
                return NotFound();
            }
            return View(AutorFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Autor.Find(id);
            if (obj == null) { return NotFound(); }
            _db.Autor.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
