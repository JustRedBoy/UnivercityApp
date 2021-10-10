using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UnivercityWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace UnivercityWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            //var user = await _userManager.GetUserAsync(User);
            //var user = await _userManager.FindByIdAsync(userId);
            //var user = _httpContextAccessor.Context?.User; (service IHttpContextAccessor)

            //await _roleManager.CreateAsync(new IdentityRole("Student"));
            //await _roleManager.CreateAsync(new IdentityRole("Teacher"));

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
