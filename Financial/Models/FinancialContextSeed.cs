using Financial.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models
{
    public static class FinancialContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            DateTime now = DateTime.Now;

            modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id = "1e8b24df-cf91-4a8a-a3dd-89c37b8ee4f9",
                        UserName = "h4n60v3r",
                        NormalizedUserName = "H4N60V3R",
                        Email = null,
                        NormalizedEmail = null,
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAEPYzk6lUm9l1Iq+mwvjUx7DtRDKN2uEw6bFp4ZJ+d4KfPH+APxsjZa4W8ln0rQlgPQ==",
                        SecurityStamp = "645UFGOLF7LIMLIQ6TVG7IUJ2SJ62CWM",
                        ConcurrencyStamp = "3485e6d6-6bb4-49ea-a522-8f810f10b9b5",
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        FirstName = "سید مهدی",
                        LastName = "رودکی",
                        NationalCode = "0440675014",
                        Address = "تهران - لواسان",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    }
                );

            modelBuilder.Entity<CodeGroup>().HasData(
                    new CodeGroup
                    {
                        Guid = Guid.Parse("b7a903f3-2c65-49ef-997b-03966578a4c0"),
                        Key = "TransactionState",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    },
                    new CodeGroup
                    {
                        Guid = Guid.Parse("8d9375da-33d4-41f0-b589-d91c96af8eb5"),
                        Key = "TransactionType",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    }
                );

            modelBuilder.Entity<Code>().HasData(
                    new Code
                    {
                        Guid = Guid.Parse("d1605abf-8a46-4f2e-8e22-194298b9fd33"),
                        CodeGroupGuid = Guid.Parse("8d9375da-33d4-41f0-b589-d91c96af8eb5"),
                        Value = "Creditor",
                        DisplayValue = "دریافتی",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    },
                    new Code
                    {
                        Guid = Guid.Parse("749d242b-55f7-4361-bf1b-42c139411c49"),
                        CodeGroupGuid = Guid.Parse("8d9375da-33d4-41f0-b589-d91c96af8eb5"),
                        Value = "Debtor",
                        DisplayValue = "پرداختی",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    },
                    new Code
                    {
                        Guid = Guid.Parse("b508bd08-5534-4d26-9ed4-c36575c8d90a"),
                        CodeGroupGuid = Guid.Parse("b7a903f3-2c65-49ef-997b-03966578a4c0"),
                        Value = "Passed",
                        DisplayValue = "وصول شده",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    },
                    new Code
                    {
                        Guid = Guid.Parse("3d905312-ae57-498c-a733-f5cbaf114940"),
                        CodeGroupGuid = Guid.Parse("b7a903f3-2c65-49ef-997b-03966578a4c0"),
                        Value = "NotPassed",
                        DisplayValue = "وصول نشده",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    },
                    new Code
                    {
                        Guid = Guid.Parse("fe92b8f8-f206-4273-8ca8-f1ecf70a8197"),
                        CodeGroupGuid = Guid.Parse("b7a903f3-2c65-49ef-997b-03966578a4c0"),
                        Value = "Waiting",
                        DisplayValue = "در انتظار وصول",
                        CreationDate = now,
                        ModifiedDate = now,
                        IsDelete = false
                    }
                );
        }
    }
}
