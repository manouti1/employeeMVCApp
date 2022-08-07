using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDemoApp.Data.Migrations
{
    public partial class updatedb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("520a16cc-754b-4415-9758-821d948165a0"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ee303ac3-5bc5-42ae-ba22-d68e2e18737a"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("f17da571-0e66-4ebb-8192-a7993a8e5628"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("42a453bb-b006-4b84-ab40-26e71a79c53a"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("8c067688-c7bb-46db-bc13-566cdaae0f85"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("c33e8c3b-9303-4d6b-b2fb-b9733c18e95a"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("f45c5f45-899d-419f-99f9-57b76f6ceeed"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("f17da571-0e66-4ebb-8192-a7993a8e5628"), "HR", "HR" },
                    { new Guid("ee303ac3-5bc5-42ae-ba22-d68e2e18737a"), "ADMIN", "Administration" },
                    { new Guid("520a16cc-754b-4415-9758-821d948165a0"), "DEV", "Software Development" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8c067688-c7bb-46db-bc13-566cdaae0f85"), "HR" },
                    { new Guid("42a453bb-b006-4b84-ab40-26e71a79c53a"), "Administrator" },
                    { new Guid("f45c5f45-899d-419f-99f9-57b76f6ceeed"), "Web Developer" },
                    { new Guid("c33e8c3b-9303-4d6b-b2fb-b9733c18e95a"), "Manager" }
                });
        }
    }
}
