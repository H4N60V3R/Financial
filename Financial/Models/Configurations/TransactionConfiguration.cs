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
                .HasName("PK_UserAccountTransaction");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Description)
                .IsRequired();

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.AccountGu)
                .WithMany(p => p.Transaction)
                .HasForeignKey(d => d.AccountGuid)
                .HasConstraintName("FK_Transaction_Account");
        }
    }
}
