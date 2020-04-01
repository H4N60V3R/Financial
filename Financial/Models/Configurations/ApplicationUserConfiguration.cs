﻿using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            //entity.Property(e => e.Address)
            //    .IsRequired();

            //entity.Property(e => e.CreationDate)
            //    .HasDefaultValueSql("(getdate())");

            //entity.Property(e => e.FirstName)
            //    .IsRequired()
            //    .HasMaxLength(128);

            //entity.Property(e => e.LastName)
            //    .IsRequired()
            //    .HasMaxLength(128);

            //entity.Property(e => e.ModifiedDate)
            //    .HasDefaultValueSql("(getdate())");

            //entity.Property(e => e.NationalCode)
            //    .IsRequired()
            //    .HasMaxLength(128);

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(e => e.Guid);

            //    entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.Address).IsRequired();

            //    entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.FirstName)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.LastName)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.NationalCode)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.Password)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.PhoneNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);
            //});
        }
    }
}