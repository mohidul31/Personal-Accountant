using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.Models
{
    public class AnalysisModel
    {
        public double GetCurrentBalance()
        {
            double income = new IncomeModel().GetTotalIncomeByAccount(null);
            double expense = new ExpenseModel().GetTotalExpenseByAccount(null);

            return income - expense;
        }

        public double GetRemainingBalanceByMonthYear(int month=0,int year=0)
        {
            month =(month==0 ? DateTime.Now.Month : month);
            year =(year==0 ? DateTime.Now.Year : year);

            double income = new IncomeModel().GetTotalIncomeByMonth(month,year);
            double expense = new ExpenseModel().GetTotalExpenseByMonth(month,year);

            return income - expense;
        }

       
    }
}
