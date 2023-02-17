using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZippersMvc.Data;
using ZippersMvc.Models;

namespace ZippersMvc.Controllers
{
    public class ZippersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZippersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zippers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zippers.ToListAsync());
        }

        // GET: Zippers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zippers = await _context.Zippers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zippers == null)
            {
                return NotFound();
            }

            return View(zippers);
        }

        // GET: Zippers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zippers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Price,Durability,WaterResistance,Strength,Flexibility,Rating")] Zippers zippers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zippers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zippers);
        }

        // GET: Zippers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zippers = await _context.Zippers.FindAsync(id);
            if (zippers == null)
            {
                return NotFound();
            }
            return View(zippers);
        }

        // POST: Zippers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Price,Durability,WaterResistance,Strength,Flexibility")] Zippers zippers)
        {
            if (id != zippers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zippers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZippersExists(zippers.Id))
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
            return View(zippers);
        }

        // GET: Zippers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zippers = await _context.Zippers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zippers == null)
            {
                return NotFound();
            }

            return View(zippers);
        }

        // POST: Zippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zippers = await _context.Zippers.FindAsync(id);
            _context.Zippers.Remove(zippers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZippersExists(int id)
        {
            return _context.Zippers.Any(e => e.Id == id);
        }
    }
}
