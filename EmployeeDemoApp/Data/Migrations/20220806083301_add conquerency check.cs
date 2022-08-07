using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDemoApp.Data.Migrations
{
    public partial class addconquerencycheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("26d507f4-0ffb-492a-8ad4-38dc1695bff0"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("be1117af-05e5-4ec4-b598-e8bb8439f4ee"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ea95e931-5caa-4a21-ac6b-951e8e6af218"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("0ccd6b42-57a5-448a-a7e6-bd0c34147b2a"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("77c09d03-90d4-48d6-a603-ebf7a47d3a72"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("87dc05ef-0a97-4fd8-a5c9-76d80e0b83f8"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("9cdd792e-fe28-4c4e-8ac2-4be3892c98a3"));

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("62bc5b7b-427a-49b0-a656-9f614c931840"), "HR", "HR" },
                    { new Guid("1ac9fda4-d181-48d5-b2f6-b3a476a58da9"), "ADMIN", "Administration" },
                    { new Guid("39c33e8e-9369-4232-a665-aff0f4174d9c"), "DEV", "Software Development" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("386481dd-1a17-48e6-b1ae-fed8b5224f13"), "HR" },
                    { new Guid("a99f9ae0-9efa-4fcf-b48c-dfc5d5bef9bc"), "Administrator" },
                    { new Guid("aff81119-070a-4190-9b82-9dea9daaa41e"), "Web Developer" },
                    { new Guid("776558f7-7237-46d3-ac5f-0ccf93c729e4"), "Manager" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("1ac9fda4-d181-48d5-b2f6-b3a476a58da9"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("39c33e8e-9369-4232-a665-aff0f4174d9c"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("62bc5b7b-427a-49b0-a656-9f614c931840"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("386481dd-1a17-48e6-b1ae-fed8b5224f13"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("776558f7-7237-46d3-ac5f-0ccf93c729e4"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("a99f9ae0-9efa-4fcf-b48c-dfc5d5bef9bc"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("aff81119-070a-4190-9b82-9dea9daaa41e"));

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("be1117af-05e5-4ec4-b598-e8bb8439f4ee"), "HR", "HR" },
                    { new Guid("ea95e931-5caa-4a21-ac6b-951e8e6af218"), "ADMIN", "Administration" },
                    { new Guid("26d507f4-0ffb-492a-8ad4-38dc1695bff0"), "DEV", "Software Development" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ccd6b42-57a5-448a-a7e6-bd0c34147b2a"), "HR" },
                    { new Guid("87dc05ef-0a97-4fd8-a5c9-76d80e0b83f8"), "Administrator" },
                    { new Guid("77c09d03-90d4-48d6-a603-ebf7a47d3a72"), "Web Developer" },
                    { new Guid("9cdd792e-fe28-4c4e-8ac2-4be3892c98a3"), "Manager" }
                });
        }
    }
}
