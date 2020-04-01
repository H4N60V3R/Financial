using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.HasKey(e => e.Guid);

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.AccountName)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.AccountNumber)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.BankName)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.CardNumber)
                .HasMaxLength(128);

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.UserSt)
                .WithMany(p => p.Account)
                .HasForeignKey(d => d.UserString)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAccount_User");
        }
    }
}
