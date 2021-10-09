using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TvShowsApp.Data;
using TvShowsApp.Models;

namespace TvShowsApp.Controllers
{
    public class TvShowsController : Controller
    {
        private readonly TvShowsAppContext _context;

        public TvShowsController(TvShowsAppContext context)
        {
            _context = context;
        }

        // GET: TvShows
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvShowModel.ToListAsync());
        }

        // GET: TvShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShowModel = await _context.TvShowModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvShowModel == null)
            {
                return NotFound();
            }

            return View(tvShowModel);
        }

        // GET: TvShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] TvShowModel tvShowModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvShowModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvShowModel);
        }

        // GET: TvShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShowModel = await _context.TvShowModel.FindAsync(id);
            if (tvShowModel == null)
            {
                return NotFound();
            }
            return View(tvShowModel);
        }

        // POST: TvShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Rating,ImdbUrl,ImageUrl")] TvShowModel tvShowModel)
        {
            if (id != tvShowModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvShowModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvShowModelExists(tvShowModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tvShowModel);
        }

        // GET: TvShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShowModel = await _context.TvShowModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvShowModel == null)
            {
                return NotFound();
            }

            return View(tvShowModel);
        }

        // POST: TvShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvShowModel = await _context.TvShowModel.FindAsync(id);
            _context.TvShowModel.Remove(tvShowModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvShowModelExists(int id)
        {
            return _context.TvShowModel.Any(e => e.Id == id);
        }
    }
}
