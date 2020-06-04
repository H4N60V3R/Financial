using System;
using System.Reflection;
using Financial.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Financial.Models
{
    public class FinancialContext : IdentityDbContext<ApplicationUser>
    {
        public FinancialContext(DbContextOptions<FinancialContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Account> Account { get; set; }

        public virtual DbSet<Calendar> Calendar { get; set; }

        public virtual DbSet<CheckTransactionInfo> CheckTransactionInfo { get; set; }

        public virtual DbSet<Code> Code { get; set; }

        public virtual DbSet<CodeGroup> CodeGroup { get; set; }

        public virtual DbSet<Transaction> Transaction { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();

            base.OnModelCreating(builder);
        }
    }
}
