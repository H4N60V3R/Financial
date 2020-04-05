using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Configurations
{
    public class CheckTransactionInfoConfiguration : IEntityTypeConfiguration<CheckTransactionInfo>
    {
        public void Configure(EntityTypeBuilder<CheckTransactionInfo> entity)
        {
            entity.HasKey(e => e.Guid)
                .HasName("PK_CheckTransactionInfo");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.IssueDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Serial)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.Code)
                .WithMany(p => p.CheckTransactionInfo)
                .HasForeignKey(d => d.StateCodeGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckTransactionInfo_Code");

            entity.HasOne(d => d.Transaction)
                .WithMany(p => p.CheckTransactionInfo)
                .HasForeignKey(d => d.TransactionGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckTransactionInfo_Transaction");
        }
    }
}
