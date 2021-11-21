using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UnivercityWebApp.Data;
using UnivercityWebApp.Models;

namespace UnivercityWebApp.Controllers
{
    [Authorize(Roles = "teacher")]
    public class StudyItemController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private Teacher _teacher;

        public StudyItemController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Manage()
        {
            SetTeacher();
            ViewBag.StudyItems = _dbContext.StudyItems.Where(si => si.Teacher.Id == _teacher.Id);

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var types = new Dictionary<int, string>();
            foreach (var type in Enum.GetValues(typeof(StudyType)))
            {
                types.Add((int)type, type.ToString());
            }
            ViewBag.StudyItemTypes = types;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudyItem item)
        {
            SetTeacher();
            item.TeacherId = _teacher.Id;
            await _dbContext.StudyItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Manage");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var item = await _dbContext.StudyItems.FirstOrDefaultAsync(si => si.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var types = new Dictionary<int, string>();
                foreach (var type in Enum.GetValues(typeof(StudyType)))
                {
                    types.Add((int)type, type.ToString());
                }
                ViewBag.StudyItemTypes = types;
                StudyItem item = await _dbContext.StudyItems.FirstOrDefaultAsync(si => si.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudyItem item)
        {
            SetTeacher();
            item.TeacherId = _teacher.Id;
            _dbContext.StudyItems.Update(item);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Manage");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                StudyItem item = await _dbContext.StudyItems.FirstOrDefaultAsync(si => si.Id == id);
                if (item != null)
                    return View(item);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var item = await _dbContext.StudyItems.FirstOrDefaultAsync(si => si.Id == id);
                if (item != null)
                {
                    _dbContext.StudyItems.Remove(item);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Manage");
                }
            }
            return NotFound();
        }

        private void SetTeacher()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _teacher = _dbContext.Teachers.FirstOrDefault(t => t.ApplicationUserId == id);
        }
    }
}
