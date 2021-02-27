using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using Repository.Models;
using System;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IUniversityRepository universityRepository;

        public StudentController(IStudentRepository studentRepository, IUniversityRepository universityRepository)
        {
            this.studentRepository = studentRepository;
            this.universityRepository = universityRepository;
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            return View(await studentRepository.GetActivesAsync());
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await studentRepository.GetByIdAsync(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.Universities = new SelectList(universityRepository.GetActives(), "Id", "Name");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, Student student)
        {
            try
            {
                await studentRepository.AddAsync(student);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await studentRepository.GetByIdAsync(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Student st, IFormCollection collection)
        {
            try
            {
                await studentRepository.UpdateAsync(st);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await studentRepository.GetByIdAsync(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await studentRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
