using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.PAEntity
{
    public class LoanInfo : Entity
    {
        [Required]
        public string PersonName { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
    }
}
