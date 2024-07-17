using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository db)
        // We already have the method in program.cs so we just call it 
        {
            _productRepo = db;
        }

        public IActionResult Index()
        {
            // Product : name of the model
            // _productRepo = _db + Products(name of the Table)
            // GetAll().ToList() = We call the function from Repository
            List<Product> objProductList = _productRepo.GetAll().ToList();
            return View(objProductList);
        }

        // Create Section
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product obj)
            // So bz we get the data from the web we put them in (obj) and it will stored in (Product) model
        {
            if (ModelState.IsValid) // This one for Validation
            {
                // _productRepo = _db + Products(name of the table)
                // Add(obj) = We call the function Add from Repository
                // Save() = _db.SaveChanges() We called the function from the ProductRepository
                _productRepo.Add(obj);
                _productRepo.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        // End of Create Section

        // Start of Edit Section
        public IActionResult Edit(int? id) // We will get the id of product that we want to edit
        {
            if (id == null || id == 0)
            {
                return NotFound();
                // NotFound = Error Design by Entity Framework
            }
            Product ProductFromDb = _productRepo.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }

        [HttpPost] //Bz of the form
        public IActionResult Edit(Product obj)
        // obj is the data that we get form the website 
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(obj); // We call the function for ProductRepository
                _productRepo.Save(); // We call the function for ProductRepository
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // End of edit Section

        // Start of Delete Section
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product ProductFromDb = _productRepo.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }

        [HttpPost, ActionName("Delete")] //We use the action name bz we change the name of the action from Delete to DeletePost
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _productRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _productRepo.Remove(obj); // we call the function from Repository
            _productRepo.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
        // End of Delete Section
    }
}
