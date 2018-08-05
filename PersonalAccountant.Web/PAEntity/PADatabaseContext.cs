using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public PADatabaseContext()
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<IncomeCategory> IncomeCategory { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<IncomeHistory> IncomeHistory { get; set; }
        public virtual DbSet<ExpenseHistory> ExpenseHistory { get; set; }
        public virtual DbSet<LoanInfo> LoanInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Remove Cascade Delete
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetForeignKeys())
                            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=PersonalAccountantDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
