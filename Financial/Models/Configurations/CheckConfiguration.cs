using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Configurations
{
    public class CheckConfiguration : IEntityTypeConfiguration<Check>
    {
        public void Configure(EntityTypeBuilder<Check> entity)
        {
            entity.HasKey(e => e.Guid)
                .HasName("PK_Check");

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Destination)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Serial)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Check)
                .HasForeignKey(d => d.AccountGuid)
                .HasConstraintName("FK_Check_Account");

            entity.HasOne(d => d.Code)
                .WithMany(p => p.Check)
                .HasForeignKey(d => d.StateCodeGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Check_Code");

            entity.HasOne(d => d.Transaction)
                .WithMany(p => p.Check)
                .HasForeignKey(d => d.TransactionGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Check_Transaction");
        }
    }
}
