using Bookworm.Data;
using Bookworm.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Editora editora)
        {
            if(editora.Nomefantasia == editora.Endereco.ToString())
            {
                ModelState.AddModelError("CumstomError", "O nome da editora e do endereço não podem ser o mesmo");
            }
            if (ModelState.IsValid)
            {
                _db.Editora.Add(editora);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editora);  
            
        }
        public IActionResult Edit(int? id)
        {
            
            if (id == null|| id == 0) {
                return NotFound(); 
            }
            //var EditoraFromDb = _db.Editora.Find(id);
            var EditoraFromDb = _db.Editora.FirstOrDefault(u => u.IdEditora == id);
            //var EditoraFromDb = _db.Editora.SingleOrDefault(u => u.IdEditora == id);
            Console.WriteLine(id);
            Console.WriteLine(EditoraFromDb);
            if (EditoraFromDb == null) {
                return NotFound();
            }
            return View(EditoraFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Editora editora)
        {
            if (editora.Nomefantasia == editora.Endereco.ToString())
            {
                ModelState.AddModelError("CumstomError", "O nome da editora e do endereço não podem ser o mesmo");
            }
            if (ModelState.IsValid)
            {
                _db.Editora.Update(editora);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editora);

        }
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var EditoraFromDb = _db.Editora.Find(id);
            //var EditoraFromDb = _db.Editora.FirstOrDefault(u => u.IdEditora == id);
            //var EditoraFromDb = _db.Editora.SingleOrDefault(u => u.IdEditora == id);
            Console.WriteLine(id);
            Console.WriteLine(EditoraFromDb);
            if (EditoraFromDb == null)
            {
                return NotFound();
            }
            return View(EditoraFromDb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
           var obj = _db.Editora.Find(id); 
           if (obj == null) { return NotFound(); }
           _db.Editora.Remove(obj);
           _db.SaveChanges();
           return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Editora == null)
            {
                return NotFound();
            }

            var editora = await _db.Editora
                .FirstOrDefaultAsync(m => m.IdEditora == id);
            if (editora == null)
            {
                return NotFound();
            }

            return View(editora);
        }

    }
}
