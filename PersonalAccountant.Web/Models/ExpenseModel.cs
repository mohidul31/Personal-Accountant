using PersonalAccountant.Web.PAEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.Models
{
    public class ExpenseModel
    {
        private readonly PADatabaseContext _db;
        public ExpenseModel()
        {
            _db = new PADatabaseContext();
        }
        public double GetTotalExpenseByExpenseCategory(Guid id)
        {
            var result = _db.ExpenseHistory.Where(x => x.ExpenseCategoryID == id);

            double totalAmount = result.Sum(w => (double?)w.Amount) ?? 0;

            return totalAmount;
        }
        public double GetTotalExpenseByAccount(Guid? id)
        {
            IQueryable<ExpenseHistory> result = _db.ExpenseHistory;

            if (id.HasValue)
            {
                 result = result.Where(x => x.AccountsID == id.Value);
            }
            double totalAmount = result.Sum(w => (double?)w.Amount) ?? 0;

            return totalAmount;
        }

        public double GetTotalExpenseByMonth(int month = 0, int year = 0)
        {
            IQueryable<ExpenseHistory> result = _db.ExpenseHistory;

            if (month != 0)
            {
                result = result.Where(x => x.Date.Month == month);
            }

            if (year != 0)
            {
                result = result.Where(x => x.Date.Year == year);
            }


            double totalAmount = result.Sum(w => (double?)w.Amount) ?? 0;

            return totalAmount;
        }
    }
}
