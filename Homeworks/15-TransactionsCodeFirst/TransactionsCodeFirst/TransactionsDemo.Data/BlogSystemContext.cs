using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionsDemo.Model;

namespace TransactionsDemo.Data
{
    /// <summary>
    /// Enable-Migrations -EnableAutomaticMigrations
    /// </summary>
    public class BlogSystemContext : DbContext
    {
        public DbSet<CardAccount> CardAccounts { get; set; }
        public DbSet<TransactionInfo> TransactionInfos { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        public BlogSystemContext()
            : base("ATMMachine")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardAccount>().Property(x => x.CardNumber).IsFixedLength().HasMaxLength(10);
            modelBuilder.Entity<CardAccount>().Property(x => x.CardPin).IsFixedLength().HasMaxLength(4);
            base.OnModelCreating(modelBuilder);
        }
    }
}
