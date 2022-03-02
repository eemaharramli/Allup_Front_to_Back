// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using AspNetPractise.DataAccessLayer;
// using Microsoft.EntityFrameworkCore;
//
// namespace AspNetPractise.Areas.AdminPanel.Controllers
// {
//     [Area("AdminPanel")]
//     public class Category : Controller
//     {
//         private readonly AppDbContext _dbContext;
//
//         public Category(AppDbContext dbContext)
//         {
//             this._dbContext = dbContext;
//         }
//         
//         // GET
//         public async Task<IActionResult> Index()
//         {
//             var categories = await this._dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
//             
//             return View(categories);
//         }
//         
//         //GET
//         public async Task<IActionResult> Create()
//         {
//             var parentCategories = await this._dbContext.Categories.
//                     Where(x => x.IsDeleted == false && x.IsMain).ToListAsync();
//             
//             ViewBag.ParentCategories = parentCategories;
//             
//             return View();
//         }
//         
//         //POST
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create(Category category, int parentCategoryId)
//         {
//             var parentCategories = await this._dbContext.Categories.
//                 Where(x => x.IsDeleted == false && x.IsMain).ToListAsync();
//             
//             ViewBag.ParentCategories = parentCategories;
//             
//             if (!ModelState.IsValid)
//             {
//                 return PartialView("_InternalErrorPartial");
//             }
//             
//
//
//             return RedirectToAction(nameof(Index));
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetPractise.DataAccessLayer;
using AspNetPractise.Models;
using System.Linq;
using System.Threading.Tasks;
using Fiorella.Areas.AdminPanel.Data;

namespace P320Practise.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false)
                .ToListAsync();

            return View(categories);
        }

        //GET
        public async Task<IActionResult> Create()
        {
            var parentCategories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false && x.IsMain).ToListAsync();
            ViewBag.ParentCategories = parentCategories;

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, int parentCategoryId)
        {
            var parentCategories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false && x.IsMain).ToListAsync();
            ViewBag.ParentCategories = parentCategories;

            if (!ModelState.IsValid)
                return View();

            if (category.IsMain)
            {
                if (category.Photo == null)
                {
                    ModelState.AddModelError("", "Please choose an image");
                    return View();
                }

                if (!category.Photo.IsImage())
                {
                    ModelState.AddModelError("", "The type of input must be an image");
                    return View();
                }

                if (!category.Photo.IsAllowedSize(2))
                {
                    ModelState.AddModelError("", "The image size must be less than 2 mb");
                    return View();
                }

                var fileName = await category.Photo.GenerateFile(Constants.ImageFolderPath);

                category.Image = fileName;
            }
            else
            {
                if (parentCategoryId == 0)
                {
                    ModelState.AddModelError("", "Choose the parent category");
                    return View();
                }

                var existParentCategory = await _dbContext.Categories
                    .Include(x => x.Children.Where(y => y.IsDeleted == false))
                    .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == parentCategoryId);
                if (existParentCategory == null)
                    return NotFound();

                var existChildCategory = existParentCategory.Children
                    .Any(x => x.Name.ToLower() == category.Name.ToLower());
                if (existChildCategory)
                {
                    ModelState.AddModelError("", $"There is a category with name {category.Name}");
                    return View();
                }

                category.Parent = existParentCategory;
            }

            category.IsDeleted = false;
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _dbContext.Categories
                .Where(x => x.Id == id && x.IsDeleted == false)
                .Include(x => x.Parent)
                .Include(x => x.Children.Where(y => y.IsDeleted == false))
                .FirstOrDefaultAsync();
            if (category == null)
                return NotFound();

            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _dbContext.Categories
                .Where(x => x.Id == id && x.IsDeleted == false)
                .Include(x => x.Children.Where(y => y.IsDeleted == false))
                .FirstOrDefaultAsync();
            if (category == null)
                return NotFound();

            category.IsDeleted = true;
            if (category.IsMain)
            {
                foreach (var item in category.Children)
                {
                    item.IsDeleted = true;
                }
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //GET
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return PartialView("_NotFoundPartial");
            }

            var category = await this._dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return PartialView("_NotFoundPartial");
            }
            
            return View(category);
        }
        
        //POST
        public async Task<IActionResult> Update(int? id ,Category category)
        {
            if (id == null)
            {
                return PartialView("_NotFoundPartial");
            }

            if (id != category.Id)
            {
                return PartialView("_NotFoundPartial");
            }
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
            }

            var existCategory = await this._dbContext.Categories.FindAsync(id);
            if (existCategory == null)
            {
                return PartialView("_NotFoundPartial");
            }

            var isExist = await this._dbContext.Categories.Where(x => x.IsDeleted == false).AnyAsync(x =>
                x.Name.Trim().ToLower() == category.Name.Trim().ToLower() && x.Id != id);

            if (isExist)
            {
                ModelState.AddModelError("Name", $"There is already Category with the name - {category.Name}");
                return View();
            }

            existCategory.Name = category.Name;
            existCategory.IsMain = category.IsMain;
            existCategory.IsDeleted = category.IsDeleted;

            await this._dbContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return PartialView("_InternalErrorPartial");
            }

            var category = await this._dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return PartialView("_NotFoundPartial");
            }

            return View(category);
        }
    }
}
