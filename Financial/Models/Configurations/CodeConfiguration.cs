using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Configurations
{
    public class CodeConfiguration : IEntityTypeConfiguration<Code>
    {
        public void Configure(EntityTypeBuilder<Code> entity)
        {
            entity.HasKey(e => e.Guid);

            entity.Property(e => e.Guid)
                .ValueGeneratedNever();

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.CodeGroupGu)
                .WithMany(p => p.Code)
                .HasForeignKey(d => d.CodeGroupGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Code_CodeGroup");
        }
    }
}
