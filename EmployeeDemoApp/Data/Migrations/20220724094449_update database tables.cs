using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDemoApp.Data.Migrations
{
    public partial class updatedatabasetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6697c565-33d0-4e84-a55d-a9f8d125cd87"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ae6ef717-fc23-4b3f-8dbf-23966c0c97cf"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("ebcef5d9-adf9-4dec-8d7b-47dbb280e1cc"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("4a5e41d2-e64d-4985-9d0e-833e5b76281b"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("6971951e-ba5e-4cc6-b14f-ec30ed147562"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("d50defcd-65dc-4d04-bfde-6c3b2617fa49"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: new Guid("f1ec9c2c-7800-406c-8f50-a7e5902f9e04"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("6697c565-33d0-4e84-a55d-a9f8d125cd87"), "HR", "HR" },
                    { new Guid("ebcef5d9-adf9-4dec-8d7b-47dbb280e1cc"), "ADMIN", "Administration" },
                    { new Guid("ae6ef717-fc23-4b3f-8dbf-23966c0c97cf"), "DEV", "Software Development" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6971951e-ba5e-4cc6-b14f-ec30ed147562"), "HR" },
                    { new Guid("f1ec9c2c-7800-406c-8f50-a7e5902f9e04"), "Administrator" },
                    { new Guid("d50defcd-65dc-4d04-bfde-6c3b2617fa49"), "Web Developer" },
                    { new Guid("4a5e41d2-e64d-4985-9d0e-833e5b76281b"), "Manager" }
                });
        }
    }
}
