using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            // カスタムバリデーション
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = $"Category {category.Name} created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            //var category1 = _db.Categories.FirstOrDefault(x => x.Id == id);
            //var category2 = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = $"Category {category.Name} updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var category = _db.Categories.Find(id);
            if(category == null){
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = $"Category {category.Name} deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
