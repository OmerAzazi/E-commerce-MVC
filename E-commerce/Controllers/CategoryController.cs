using E_commerce.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        // We already have the method in program.cs so we just call it 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }


        // For Create we have both getter and setter action method.
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Bz of the form
        public IActionResult Create(Category obj)
        // obj is the data that we get form the website 
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        // Edit Section
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost] //Bz of the form
        public IActionResult Edit(Category obj)
        // obj is the data that we get form the website 
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        // End of Edit Section
        // Delete Section
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    // End of Delete Section
}
