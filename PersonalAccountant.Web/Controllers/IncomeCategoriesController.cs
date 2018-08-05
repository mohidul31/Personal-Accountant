using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalAccountant.Web.PAEntity;

namespace PersonalAccountant.Web.Controllers
{
    public class IncomeCategoriesController : Controller
    {
        private readonly PADatabaseContext _context;

        public IncomeCategoriesController(PADatabaseContext context)
        {
            _context = context;
        }

        // GET: IncomeCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncomeCategory.OrderBy(x => x.Name).ToListAsync());
        }

        // GET: IncomeCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategory = await _context.IncomeCategory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomeCategory == null)
            {
                return NotFound();
            }

            return View(incomeCategory);
        }

        // GET: IncomeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ID")] IncomeCategory incomeCategory)
        {
            if (ModelState.IsValid)
            {
                incomeCategory.ID = Guid.NewGuid();
                _context.Add(incomeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeCategory);
        }

        // GET: IncomeCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategory = await _context.IncomeCategory.SingleOrDefaultAsync(m => m.ID == id);
            if (incomeCategory == null)
            {
                return NotFound();
            }
            return View(incomeCategory);
        }

        // POST: IncomeCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,ID")] IncomeCategory incomeCategory)
        {
            if (id != incomeCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeCategoryExists(incomeCategory.ID))
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
            return View(incomeCategory);
        }

        // GET: IncomeCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategory = await _context.IncomeCategory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomeCategory == null)
            {
                return NotFound();
            }

            return View(incomeCategory);
        }

        // POST: IncomeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var incomeCategory = await _context.IncomeCategory.SingleOrDefaultAsync(m => m.ID == id);
            _context.IncomeCategory.Remove(incomeCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeCategoryExists(Guid id)
        {
            return _context.IncomeCategory.Any(e => e.ID == id);
        }
    }
}
