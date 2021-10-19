using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using UnivercityWebApp.Data;
using UnivercityWebApp.Models;

namespace UnivercityWebApp.Controllers
{
    //[Authorize(Roles = "teacher")]
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private Teacher _teacher;

        public TeachersController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _teacher = _applicationDbContext.Teachers.FirstOrDefault(t => t.ApplicationUserId == id);
            return View(_applicationDbContext.StudyItems.Where(si => si.Teacher.Id == _teacher.Id));
        }
    }
}
