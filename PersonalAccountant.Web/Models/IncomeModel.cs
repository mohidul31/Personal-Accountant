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
        public double GetTotalIncomeByAccount(Guid? id)
        {
            IQueryable<IncomeHistory> result = _db.IncomeHistory;

            if (id.HasValue)
            {
                 result = result.Where(x => x.AccountsID == id.Value);
            }
            

            double totalAmount = result.Sum(w => (double?)w.Amount) ?? 0;

            return totalAmount;
        }

        public double GetTotalIncomeByMonth(int month=0,int year=0)
        {
            IQueryable<IncomeHistory> result = _db.IncomeHistory;

            if (month !=0 )
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
