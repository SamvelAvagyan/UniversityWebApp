using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        // GET: TeacherController
        public async Task<ActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewBag.IdSortParm = sortOrder == "Id" ? "Id" : "Id";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name" : "Name";
            var teachers = await teacherRepository.GetActivesAsync();

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(t => t.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    teachers = teachers.OrderBy(t => t.Name);
                    break;
                case "Id":
                    teachers = teachers.OrderBy(t => t.Id);
                    break;
                default:
                    teachers = teachers.OrderBy(t => t.Surname);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Teacher>.CreateAsync(teachers.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: TeacherController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await teacherRepository.GetByIdAsync(id));
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, Teacher t)
        {
            try
            {
                await teacherRepository.AddAsync(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await teacherRepository.GetByIdAsync(id));
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Teacher teacher, IFormCollection collection)
        {
            try
            {
                await teacherRepository.UpdateAsync(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await teacherRepository.GetByIdAsync(id));
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await teacherRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
