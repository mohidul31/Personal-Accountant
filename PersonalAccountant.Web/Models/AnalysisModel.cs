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

        public double GetCurrentBalanceThisMonth()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            double income = new IncomeModel().GetTotalIncomeByMonth(month,year);
            double expense = new ExpenseModel().GetTotalExpenseByMonth(month,year);

            return income - expense;
        }

        public double GetCurrentBalancePreviousMonth()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            int pmonth = (month==1 ? 12 : month-1);
            int pyear = year-1;

            double income = new IncomeModel().GetTotalIncomeByMonth(pmonth, pyear);
            double expense = new ExpenseModel().GetTotalExpenseByMonth(pmonth, pyear);

            return income - expense;
        }
    }
}
