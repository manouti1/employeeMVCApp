using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDemoApp.Data.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("0d122cec-9922-43ec-bc4c-c99922a14ba4"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("aba14f55-dcd9-497f-b901-05992da00abd"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("f7c17e0d-9631-43b0-bcc9-f8655004694c"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("83a4ffba-800e-49f3-ab00-5d38fb666a61"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("8bf68fb5-302f-4439-a28c-a891197b6cf7"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("ae716d3d-d1c2-4226-8dc1-4a47be651615"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("d285a2ae-ec0c-4f76-aaf3-f59174ef6ab2"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0d122cec-9922-43ec-bc4c-c99922a14ba4"), "HR", "HR" },
                    { new Guid("f7c17e0d-9631-43b0-bcc9-f8655004694c"), "ADMIN", "Administration" },
                    { new Guid("aba14f55-dcd9-497f-b901-05992da00abd"), "DEV", "Software Development" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ae716d3d-d1c2-4226-8dc1-4a47be651615"), "HR" },
                    { new Guid("83a4ffba-800e-49f3-ab00-5d38fb666a61"), "Administrator" },
                    { new Guid("8bf68fb5-302f-4439-a28c-a891197b6cf7"), "Web Developer" },
                    { new Guid("d285a2ae-ec0c-4f76-aaf3-f59174ef6ab2"), "Manager" }
                });
        }
    }
}
