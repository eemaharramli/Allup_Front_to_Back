using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetPractise.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}