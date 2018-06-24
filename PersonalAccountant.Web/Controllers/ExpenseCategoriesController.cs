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
    public class ExpenseCategoriesController : Controller
    {
        private readonly PADatabaseContext _context;

        public ExpenseCategoriesController(PADatabaseContext context)
        {
            _context = context;
        }

        // GET: ExpenseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseCategory.ToListAsync());
        }

        // GET: ExpenseCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = await _context.ExpenseCategory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ID")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                expenseCategory.ID = Guid.NewGuid();
                _context.Add(expenseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = await _context.ExpenseCategory.SingleOrDefaultAsync(m => m.ID == id);
            if (expenseCategory == null)
            {
                return NotFound();
            }
            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,ID")] ExpenseCategory expenseCategory)
        {
            if (id != expenseCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseCategoryExists(expenseCategory.ID))
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
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseCategory = await _context.ExpenseCategory
                .SingleOrDefaultAsync(m => m.ID == id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var expenseCategory = await _context.ExpenseCategory.SingleOrDefaultAsync(m => m.ID == id);
            _context.ExpenseCategory.Remove(expenseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseCategoryExists(Guid id)
        {
            return _context.ExpenseCategory.Any(e => e.ID == id);
        }
    }
}
