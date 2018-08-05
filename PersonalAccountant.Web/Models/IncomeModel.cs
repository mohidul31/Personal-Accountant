using PersonalAccountant.Web.PAEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.Models
{
    public class IncomeModel
    {
        private readonly PADatabaseContext _db;
        public IncomeModel()
        {
            _db = new PADatabaseContext();
        }
        public double GetTotalIncomeByIncomeCategory(Guid id)
        {
            var result=_db.IncomeHistory.Where(x => x.IncomeCategoryID==id);

            double totalAmount = result.Sum(w => (double?)w.Amount) ?? 0;

            return totalAmount;
        }
        public double GetTotalIncomeByAccount(Guid id)
        {
            var result = _db.IncomeHistory.Where(x => x.AccountsID == id);

            double totalAmount = result.Sum(w => (double?)w.Amount) ?? 0;

            return totalAmount;
        }
    }
}
