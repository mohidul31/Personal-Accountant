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
    public class LoanInfoesController : Controller
    {
        private readonly PADatabaseContext _context;

        public LoanInfoesController(PADatabaseContext context)
        {
            _context = context;
        }

        // GET: LoanInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoanInfo.ToListAsync());
        }

        // GET: LoanInfoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanInfo = await _context.LoanInfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (loanInfo == null)
            {
                return NotFound();
            }

            return View(loanInfo);
        }

        // GET: LoanInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoanInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonName,Amount,Remarks,ID")] LoanInfo loanInfo)
        {
            if (ModelState.IsValid)
            {
                loanInfo.ID = Guid.NewGuid();
                _context.Add(loanInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loanInfo);
        }

        // GET: LoanInfoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanInfo = await _context.LoanInfo.SingleOrDefaultAsync(m => m.ID == id);
            if (loanInfo == null)
            {
                return NotFound();
            }
            return View(loanInfo);
        }

        // POST: LoanInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonName,Amount,Remarks,ID")] LoanInfo loanInfo)
        {
            if (id != loanInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanInfoExists(loanInfo.ID))
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
            return View(loanInfo);
        }

        // GET: LoanInfoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanInfo = await _context.LoanInfo
                .SingleOrDefaultAsync(m => m.ID == id);
            if (loanInfo == null)
            {
                return NotFound();
            }

            return View(loanInfo);
        }

        // POST: LoanInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var loanInfo = await _context.LoanInfo.SingleOrDefaultAsync(m => m.ID == id);
            _context.LoanInfo.Remove(loanInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanInfoExists(Guid id)
        {
            return _context.LoanInfo.Any(e => e.ID == id);
        }
    }
}
