using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.PAEntity
{
    public class ExpenseHistory : Entity
    {
        public Guid ExpenseCategoryID{ get; set; }
        [ForeignKey("ExpenseCategoryID")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }

        public Guid AccountsID { get; set; }
        [ForeignKey("AccountsID")]
        public virtual Accounts Accounts { get; set; }

        public double Amount { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }
    }
}
