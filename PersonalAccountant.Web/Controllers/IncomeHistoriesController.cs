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
    public class IncomeHistoriesController : Controller
    {
        private readonly PADatabaseContext _context;

        public IncomeHistoriesController(PADatabaseContext context)
        {
            _context = context;
        }

        // GET: IncomeHistories
        public async Task<IActionResult> Index()
        {
            var pADatabaseContext = _context.IncomeHistory.Include(i => i.Accounts).Include(i => i.IncomeCategory);
            return View(await pADatabaseContext.ToListAsync());
        }

        // GET: IncomeHistories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeHistory = await _context.IncomeHistory
                .Include(i => i.Accounts)
                .Include(i => i.IncomeCategory)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomeHistory == null)
            {
                return NotFound();
            }

            return View(incomeHistory);
        }

        // GET: IncomeHistories/Create
        public IActionResult Create()
        {
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName");
            ViewData["IncomeCategoryID"] = new SelectList(_context.IncomeCategory, "ID", "Name");
            return View();
        }

        // POST: IncomeHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncomeCategoryID,AccountsID,Amount,Date,Remarks,ID")] IncomeHistory incomeHistory)
        {
            if (ModelState.IsValid)
            {
                incomeHistory.ID = Guid.NewGuid();
                _context.Add(incomeHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName", incomeHistory.AccountsID);
            ViewData["IncomeCategoryID"] = new SelectList(_context.IncomeCategory, "ID", "Name", incomeHistory.IncomeCategoryID);
            return View(incomeHistory);
        }

        // GET: IncomeHistories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeHistory = await _context.IncomeHistory.SingleOrDefaultAsync(m => m.ID == id);
            if (incomeHistory == null)
            {
                return NotFound();
            }
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName", incomeHistory.AccountsID);
            ViewData["IncomeCategoryID"] = new SelectList(_context.IncomeCategory, "ID", "Name", incomeHistory.IncomeCategoryID);
            return View(incomeHistory);
        }

        // POST: IncomeHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IncomeCategoryID,AccountsID,Amount,Date,Remarks,ID")] IncomeHistory incomeHistory)
        {
            if (id != incomeHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeHistoryExists(incomeHistory.ID))
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
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "ID", "AccountName", incomeHistory.AccountsID);
            ViewData["IncomeCategoryID"] = new SelectList(_context.IncomeCategory, "ID", "Name", incomeHistory.IncomeCategoryID);
            return View(incomeHistory);
        }

        // GET: IncomeHistories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeHistory = await _context.IncomeHistory
                .Include(i => i.Accounts)
                .Include(i => i.IncomeCategory)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomeHistory == null)
            {
                return NotFound();
            }

            return View(incomeHistory);
        }

        // POST: IncomeHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var incomeHistory = await _context.IncomeHistory.SingleOrDefaultAsync(m => m.ID == id);
            _context.IncomeHistory.Remove(incomeHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeHistoryExists(Guid id)
        {
            return _context.IncomeHistory.Any(e => e.ID == id);
        }
    }
}
