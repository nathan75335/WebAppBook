using Microsoft.AspNetCore.Mvc;
using WebAppBookList.Data;
using WebAppBookList.Models;

namespace WebAppBookList.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Book> objectBookList = _db.Books;
            return View(objectBookList);
        }
        //Get method
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book obj)
        {
            if(obj.Name == obj.Title)
            {
                ModelState.AddModelError("Name", "The Name can not match the Title");
            }
            if (ModelState.IsValid)
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "A Book Has been successfully created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();  
            }

            var book = _db.Books.Find(id); 

            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book obj)
        {
            if (obj.Name == obj.Title)
            {
                ModelState.AddModelError("Name", "The Name can not match the Title");
            }
            if (ModelState.IsValid)
            {
                _db.Books.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Book Has been successfully updated";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Books.Find(id);
            
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Book obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Book Has been successfully Deleted";
            return RedirectToAction("Index");
        
        }

    }
}
