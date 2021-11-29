using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UnivercityWebApp.Models;
using Microsoft.AspNetCore.Identity;
using UnivercityWebApp.ViewModels;
using UnivercityWebApp.Data;

namespace UnivercityWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(UserManager<ApplicationUser> userManager, 
            ILogger<HomeController> logger,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            string id = _userManager.GetUserId(User);
            if (User != null && User.IsInRole("admin"))
            {
                //
            }
            else if (User != null && User.IsInRole("teacher"))
            {
                return RedirectToAction("Manage", "StudyItem");
            }
            else if (User != null && User.IsInRole("student"))
            {
                //
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
