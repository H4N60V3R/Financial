using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Financial.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    NationalCode = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeGroup",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Key = table.Column<string>(maxLength: 128, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeGroup", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    UserGuid = table.Column<string>(nullable: false),
                    BankName = table.Column<string>(maxLength: 128, nullable: true),
                    AccountName = table.Column<string>(maxLength: 128, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 128, nullable: false),
                    CardNumber = table.Column<string>(maxLength: 128, nullable: true),
                    Credit = table.Column<long>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Account_User",
                        column: x => x.UserGuid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CodeGroupGuid = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayValue = table.Column<string>(maxLength: 128, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Code_CodeGroup",
                        column: x => x.CodeGroupGuid,
                        principalTable: "CodeGroup",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    AccountGuid = table.Column<Guid>(nullable: true),
                    TypeCodeGuid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    Cost = table.Column<long>(nullable: false),
                    AccountSide = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ReceiptDate = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Transaction_Account",
                        column: x => x.AccountGuid,
                        principalTable: "Account",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Code",
                        column: x => x.TypeCodeGuid,
                        principalTable: "Code",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckTransactionInfo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    TransactionGuid = table.Column<Guid>(nullable: false),
                    StateCodeGuid = table.Column<Guid>(nullable: false),
                    Serial = table.Column<string>(maxLength: 128, nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckTransactionInfo", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CheckTransactionInfo_Code",
                        column: x => x.StateCodeGuid,
                        principalTable: "Code",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckTransactionInfo_Transaction",
                        column: x => x.TransactionGuid,
                        principalTable: "Transaction",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreationDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NationalCode", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e8b24df-cf91-4a8a-a3dd-89c37b8ee4f9", 0, "تهران - لواسان", "3485e6d6-6bb4-49ea-a522-8f810f10b9b5", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), null, false, "سید مهدی", "رودکی", true, null, new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "0440675014", null, "H4N60V3R", "AQAAAAEAACcQAAAAEPYzk6lUm9l1Iq+mwvjUx7DtRDKN2uEw6bFp4ZJ+d4KfPH+APxsjZa4W8ln0rQlgPQ==", null, false, "645UFGOLF7LIMLIQ6TVG7IUJ2SJ62CWM", false, "h4n60v3r" });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "Guid", "CreationDate", "Key", "ModifiedDate" },
                values: new object[] { new Guid("b7a903f3-2c65-49ef-997b-03966578a4c0"), new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "TransactionState", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "Guid", "CreationDate", "Key", "ModifiedDate" },
                values: new object[] { new Guid("8d9375da-33d4-41f0-b589-d91c96af8eb5"), new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "TransactionType", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "Guid", "CodeGroupGuid", "CreationDate", "DisplayValue", "ModifiedDate", "Value" },
                values: new object[,]
                {
                    { new Guid("13fa198e-a566-4d08-b9eb-165b0be539dd"), new Guid("b7a903f3-2c65-49ef-997b-03966578a4c0"), new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "پاس شده", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "Passed" },
                    { new Guid("1b635c1e-3b1f-4d3d-99c6-c586adc1d0d4"), new Guid("b7a903f3-2c65-49ef-997b-03966578a4c0"), new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "برگشت خورده", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "NotPassed" },
                    { new Guid("eb876363-3caa-4ed9-8f16-2387e473416e"), new Guid("b7a903f3-2c65-49ef-997b-03966578a4c0"), new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "در انتظار وصول", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "Waiting" },
                    { new Guid("c45846b9-c78b-41b4-aa27-3055b554248d"), new Guid("8d9375da-33d4-41f0-b589-d91c96af8eb5"), new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "بستانکار", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "Creditor" },
                    { new Guid("88a77fb6-896a-4d74-96ed-9565d5a53ee1"), new Guid("8d9375da-33d4-41f0-b589-d91c96af8eb5"), new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "بدهکار", new DateTime(2020, 4, 4, 20, 12, 48, 648, DateTimeKind.Local).AddTicks(1635), "Debtor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserGuid",
                table: "Account",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CheckTransactionInfo_StateCodeGuid",
                table: "CheckTransactionInfo",
                column: "StateCodeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CheckTransactionInfo_TransactionGuid",
                table: "CheckTransactionInfo",
                column: "TransactionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Code_CodeGroupGuid",
                table: "Code",
                column: "CodeGroupGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountGuid",
                table: "Transaction",
                column: "AccountGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TypeCodeGuid",
                table: "Transaction",
                column: "TypeCodeGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CheckTransactionInfo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CodeGroup");
        }
    }
}
