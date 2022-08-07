using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDemoApp.Data.Migrations
{
    public partial class addrowversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("2341dcea-efb8-4e51-98d6-c79a91cdd354"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("8d7e573c-bf5f-496b-bc36-615446fcc950"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("d3f5ebd8-80c1-4256-8ffa-4053fd5e06ac"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("6de6a4c4-f82e-49a7-bb1b-54f031af780b"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("b2f2054b-d856-4fd8-b80d-1074c6b7d970"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("b8afec36-8e22-4b8c-a945-efa94ca8c599"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("d9a786c4-db4b-4b6e-a935-0e6080992e58"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "UserPosition",
                rowVersion: true,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserPosition");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("2341dcea-efb8-4e51-98d6-c79a91cdd354"), "HR", "HR" },
                    { new Guid("8d7e573c-bf5f-496b-bc36-615446fcc950"), "ADMIN", "Administration" },
                    { new Guid("d3f5ebd8-80c1-4256-8ffa-4053fd5e06ac"), "DEV", "Software Development" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6de6a4c4-f82e-49a7-bb1b-54f031af780b"), "HR" },
                    { new Guid("b2f2054b-d856-4fd8-b80d-1074c6b7d970"), "Administrator" },
                    { new Guid("b8afec36-8e22-4b8c-a945-efa94ca8c599"), "Web Developer" },
                    { new Guid("d9a786c4-db4b-4b6e-a935-0e6080992e58"), "Manager" }
                });
        }
    }
}
