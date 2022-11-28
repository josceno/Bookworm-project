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
            IEnumerable<Editora> objEditoraList = _db.Editora;  
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
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var LivroFromDb = _db.Livro.FirstOrDefault(u => u.id_livro == id);

            Console.WriteLine(id);
            Console.WriteLine(LivroFromDb);
            if (LivroFromDb == null)
            {
                return NotFound();
            }
            return View(LivroFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Livro livro)
        {
           
                _db.Livro.Update(livro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public IActionResult Editor(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var LivroFromDb = _db.Editora.FirstOrDefault(u => u.IdEditora == id);

            Console.WriteLine(id);
            Console.WriteLine(LivroFromDb);
            if (LivroFromDb == null)
            {
                return NotFound();
            }
            return View(LivroFromDb);
        }

       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editor(Editora livro)
        {

            _db.Livro.Update(livro);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }*/
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var LivroFromDb = _db.Livro.Find(id);
            Console.WriteLine(id);
            Console.WriteLine(LivroFromDb);
            if (LivroFromDb == null)
            {
                return NotFound();
            }
            return View(LivroFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Livro.Find(id);
            if (obj == null) { return NotFound(); }
            _db.Livro.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}

