using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.PAEntity
{
    public class Accounts :Entity
    {
        [Required]
        public string AccountName { get; set; }
    }
}
