using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            this.universityRepository = universityRepository;
        }

        // GET: UniversityController
        public async Task<ActionResult> Index()
        {
            return View(await universityRepository.GetActivesAsync());
        }

        // GET: UniversityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UniversityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UniversityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
