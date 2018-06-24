using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.PAEntity
{
    public class ExpenseCategory : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
