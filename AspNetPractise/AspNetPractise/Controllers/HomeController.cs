using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetPractise.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetPractise.Models;
using AspNetPractise.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetPractise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await this._dbContext.Categories.Where(x=>x.IsDeleted == false && x.IsMain == true).ToListAsync();
            
            return View(new HomeViewModel
            {
                Categories = categories
            });
        }
    }
}