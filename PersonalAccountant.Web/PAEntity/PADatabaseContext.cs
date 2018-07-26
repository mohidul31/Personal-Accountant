using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccountant.Web.PAEntity
{
    public class PADatabaseContext : DbContext
    {
        public PADatabaseContext(DbContextOptions<PADatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<IncomeCategory> IncomeCategory { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<IncomeHistory> IncomeHistory { get; set; }
        public virtual DbSet<ExpenseHistory> ExpenseHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
