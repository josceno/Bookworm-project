﻿using Bookworm.Data;
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
            _db.Autor.Add(autor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
