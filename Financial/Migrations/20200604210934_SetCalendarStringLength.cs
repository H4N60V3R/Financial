using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Financial.Migrations
{
    public partial class SetCalendarStringLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Start",
                table: "Calendar",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "End",
                table: "Calendar",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e8b24df-cf91-4a8a-a3dd-89c37b8ee4f9",
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("3d905312-ae57-498c-a733-f5cbaf114940"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("749d242b-55f7-4361-bf1b-42c139411c49"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("b508bd08-5534-4d26-9ed4-c36575c8d90a"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("d1605abf-8a46-4f2e-8e22-194298b9fd33"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("fe92b8f8-f206-4273-8ca8-f1ecf70a8197"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "CodeGroup",
                keyColumn: "Guid",
                keyValue: new Guid("8d9375da-33d4-41f0-b589-d91c96af8eb5"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "CodeGroup",
                keyColumn: "Guid",
                keyValue: new Guid("b7a903f3-2c65-49ef-997b-03966578a4c0"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013), new DateTime(2020, 6, 5, 1, 39, 34, 97, DateTimeKind.Local).AddTicks(5013) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Start",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "End",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e8b24df-cf91-4a8a-a3dd-89c37b8ee4f9",
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("3d905312-ae57-498c-a733-f5cbaf114940"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("749d242b-55f7-4361-bf1b-42c139411c49"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("b508bd08-5534-4d26-9ed4-c36575c8d90a"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("d1605abf-8a46-4f2e-8e22-194298b9fd33"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "Code",
                keyColumn: "Guid",
                keyValue: new Guid("fe92b8f8-f206-4273-8ca8-f1ecf70a8197"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "CodeGroup",
                keyColumn: "Guid",
                keyValue: new Guid("8d9375da-33d4-41f0-b589-d91c96af8eb5"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "CodeGroup",
                keyColumn: "Guid",
                keyValue: new Guid("b7a903f3-2c65-49ef-997b-03966578a4c0"),
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507), new DateTime(2020, 6, 5, 0, 53, 57, 173, DateTimeKind.Local).AddTicks(6507) });
        }
    }
}
