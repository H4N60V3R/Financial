using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {
            entity.HasKey(e => e.Guid)
                .HasName("PK_Transaction");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.AccountSide)
                 .IsRequired()
                 .HasMaxLength(128);

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Transaction)
                .HasForeignKey(d => d.AccountGuid)
                .HasConstraintName("FK_Transaction_Account");

            entity.HasOne(d => d.TypeCode)
                .WithMany(p => p.TypeTransaction)
                .HasForeignKey(d => d.TypeCodeGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TypeTransaction_TypeCode");

            entity.HasOne(d => d.StateCode)
                .WithMany(p => p.StateTransaction)
                .HasForeignKey(d => d.StateCodeGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StateTransaction_StateCode");
        }
    }
}
