using System;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Services.Service.Interfaces;

namespace OnlineBookstore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Authors
        public IActionResult Index()
        {
            var authors = _authorService.GetAuthors();
            return View(authors);
        }

        // GET: Authors/Details/5
        public IActionResult Details(int id)
        {
            var author = _authorService.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }


        [HttpPost]
        public JsonResult CreateAuthorAJAX(string name, string shortDescription)
        {
            var author = new Author();
            if (name != "" || name != null && shortDescription !=""|| shortDescription !=null)
            {
                author.Name = name;
                author.ShortDescription = shortDescription;
                _authorService.Add(author);
            }
            return Json(author);

        }

        // GET: Authors/Edit/5
        public IActionResult Edit(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.Edit(author);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public IActionResult Delete(int id)
        {
            var author = _authorService.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }
            return View(author);

        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _authorService.GetAuthorById(id);
            _authorService.Delete(author);

            return RedirectToAction(nameof(Index));
        }

    }
}
