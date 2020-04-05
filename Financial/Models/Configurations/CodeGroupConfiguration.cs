using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Configurations
{
    public class CodeGroupConfiguration : IEntityTypeConfiguration<CodeGroup>
    {
        public void Configure(EntityTypeBuilder<CodeGroup> entity)
        {
            entity.HasKey(e => e.Guid);

            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())");
        }
    }
}
