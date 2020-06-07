using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin_Panel.Models;

namespace Admin_Panel.Controllers
{
    public class ToursController : Controller
    {
        private readonly TourContext _context;

        public ToursController(TourContext context)
        {
            _context = context;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tours.ToListAsync());
        }

        

        // GET: Tours/Create
        public IActionResult CreateOREdit(int id=0)
        {
            if (id == 0)
                return View(new Tour());
            else
                return View(_context.Tours.Find(id));
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("TourId,Title,StartDate,EndDate,Categories")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                if (tour.TourId == 0)
                    _context.Add(tour);
                else
                    _context.Update(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TourId,Title,StartDate,EndDate,Categories")] Tour tour)
        {
            if (id != tour.TourId)
            {
                return NotFound();
            }


            return View(tour);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var tour = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}
