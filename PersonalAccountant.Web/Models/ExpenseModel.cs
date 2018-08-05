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
        public double GetTotalExpenseByAccount(Guid id)
        {
            var result = _db.ExpenseHistory.Where(x => x.AccountsID == id);

            double totalAmount = result.Sum(w => (double?)w.Amount) ?? 0;

            return totalAmount;
        }
    }
}
