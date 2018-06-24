using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.PAEntity
{
    public class Entity
    {
        public Entity()
        {
            ID = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
        [Key]
        public Guid ID { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedAt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedAt { get; set; }
    }
}
