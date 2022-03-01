using System.Linq;
using System.Threading.Tasks;
using AspNetPractise.DataAccessLayer;
using AspNetPractise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetPractise.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;
        // GET
        public CategoryController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedCategory = await this._dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (selectedCategory == null)
            {
                return NotFound();
            }

            var categories =
                await this._dbContext.Categories
                    .Where(x => x.IsDeleted == false && x.IsMain)
                    .Include(x=>x.Children.Where(y=>y.IsDeleted == false))
                    .ToListAsync();
            if (categories == null)
            {
                return NotFound();
            }
            
            return View(new CategoryViewModel
            {
                SelectedCategory = selectedCategory,
                Categories = categories
            });
        }
    }
}