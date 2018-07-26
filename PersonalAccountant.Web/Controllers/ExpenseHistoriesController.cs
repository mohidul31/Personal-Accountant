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
    public class ExpenseHistoriesController : Controller
    {
        private readonly PADatabaseContext _context;

        public ExpenseHistoriesController(PADatabaseContext context)
        {
            _context = context;
        }

        // GET: ExpenseHistories
        public async Task<IActionResult> Index()
        {
            var pADatabaseContext = _context.ExpenseHistory.Include(e => e.Accounts).Include(e => e.ExpenseCategory);
            return View(await pADatabaseContext.ToListAsync());
        }

        // GET: ExpenseHistories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseHistory = await _context.ExpenseHistory
                .Include(e => e.Accounts)
                .Include(e => e.ExpenseCategory)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (expenseHistory == null)
            {
                return NotFound();
            }

            return View(expenseHistory);
        }

        // GET: ExpenseHistories/Create
        public IActionResult Create()
        {
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName");
            ViewData["ExpenseCategoryID"] = new SelectList(_context.ExpenseCategory, "ID", "Name");
            return View();
        }

        // POST: ExpenseHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseCategoryID,AccountsID,Amount,Date,Remarks,ID")] ExpenseHistory expenseHistory)
        {
            if (ModelState.IsValid)
            {
                expenseHistory.ID = Guid.NewGuid();
                _context.Add(expenseHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName", expenseHistory.AccountsID);
            ViewData["ExpenseCategoryID"] = new SelectList(_context.ExpenseCategory, "ID", "Name", expenseHistory.ExpenseCategoryID);
            return View(expenseHistory);
        }

        // GET: ExpenseHistories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseHistory = await _context.ExpenseHistory.SingleOrDefaultAsync(m => m.ID == id);
            if (expenseHistory == null)
            {
                return NotFound();
            }
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName", expenseHistory.AccountsID);
            ViewData["ExpenseCategoryID"] = new SelectList(_context.ExpenseCategory, "ID", "Name", expenseHistory.ExpenseCategoryID);
            return View(expenseHistory);
        }

        // POST: ExpenseHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ExpenseCategoryID,AccountsID,Amount,Date,Remarks,ID")] ExpenseHistory expenseHistory)
        {
            if (id != expenseHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseHistoryExists(expenseHistory.ID))
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
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName", expenseHistory.AccountsID);
            ViewData["ExpenseCategoryID"] = new SelectList(_context.ExpenseCategory, "ID", "Name", expenseHistory.ExpenseCategoryID);
            return View(expenseHistory);
        }

        // GET: ExpenseHistories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseHistory = await _context.ExpenseHistory
                .Include(e => e.Accounts)
                .Include(e => e.ExpenseCategory)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (expenseHistory == null)
            {
                return NotFound();
            }

            return View(expenseHistory);
        }

        // POST: ExpenseHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var expenseHistory = await _context.ExpenseHistory.SingleOrDefaultAsync(m => m.ID == id);
            _context.ExpenseHistory.Remove(expenseHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseHistoryExists(Guid id)
        {
            return _context.ExpenseHistory.Any(e => e.ID == id);
        }
    }
}
