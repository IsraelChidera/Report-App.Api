using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a88f736-4681-4522-9d18-e4029fa54de5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95c13901-7432-43f2-a8f4-7faad3478345");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5b4b930-4147-4f62-9481-ff4770b2d41c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6db8afdd-531d-4cba-bf13-5d5d503961eb", "17dcafb5-ea69-4154-beb3-839d4e95016b", "Admin", "ADMIN" },
                    { "833b14a0-8354-4741-a602-2d3a03439070", "dbf349f7-88eb-40f1-9de5-28899c68e3e8", "Vendor", "VENDOR" },
                    { "be19b707-94f2-458c-8e31-8f7447ad81ed", "743c8da3-e372-4734-b7f0-34d94582ff57", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "AdditionalInfo", "HazardDescription", "HazardRating", "Location", "PreventiveMeasure", "ResourceAtRisk", "RiskImpact", "RiskProbability", "UserId", "UserId1" },
                values: new object[,]
                {
                    { new Guid("10bc62a1-e8a6-476f-8fc2-743c1f46b8d8"), "Jo ..", "Baking is ...", 0, "Nsukka, Enugu", "Cakes and cakes materials ...", "Environment", 1, 1, new Guid("6c8a9db9-93a4-4d7b-8b8f-7e41aa1d52a7"), null },
                    { new Guid("5f5ca5c5-3b5e-40a3-9a9e-9fa9b7d04d51"), "Jo ..", "Fashion world is ...", 0, "Agbelekale, Laos", "Remains of clothes ...", "Environment", 1, 1, new Guid("d0b8c61b-7720-49f1-95c8-42e2b98d67e9"), null },
                    { new Guid("8c90bb06-13e5-4d8f-a14f-5461b9d2703a"), "Jo ..", "Environment is ...", 0, "Enugu, Enugu", "Eradixcated the use of pumps", "Environment", 1, 1, new Guid("9a6a288c-df87-476d-8c13-15e008c84d71"), null },
                    { new Guid("a99b6593-2497-4baf-8568-15aa1c2f2e22"), "Jo ..", "Environment is ...", 0, "Enugu, Enugu", "Eradixcated the use of pumps", "Environment", 1, 1, new Guid("a8b6c9d0-22e5-45f1-a3c5-6e5b46d201c6"), null },
                    { new Guid("d4d1554e-4a96-4a34-bc71-c1f9b3ceba06"), "Jo ..", "Environment is ...", 0, "Ikeja, Lagos", "To ... ...", "Environment", 1, 1, new Guid("19f907bf-4633-4b75-8f53-35ce78eb97f2"), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6db8afdd-531d-4cba-bf13-5d5d503961eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833b14a0-8354-4741-a602-2d3a03439070");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be19b707-94f2-458c-8e31-8f7447ad81ed");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("10bc62a1-e8a6-476f-8fc2-743c1f46b8d8"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("5f5ca5c5-3b5e-40a3-9a9e-9fa9b7d04d51"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("8c90bb06-13e5-4d8f-a14f-5461b9d2703a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("a99b6593-2497-4baf-8568-15aa1c2f2e22"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: new Guid("d4d1554e-4a96-4a34-bc71-c1f9b3ceba06"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a88f736-4681-4522-9d18-e4029fa54de5", "9d410ab3-4a2f-436d-9dbc-0df89535fac9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95c13901-7432-43f2-a8f4-7faad3478345", "7c6d4ff1-8641-417b-a92d-979164b7c594", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5b4b930-4147-4f62-9481-ff4770b2d41c", "7f748fba-9a87-446f-b51e-400a83c61a0b", "Vendor", "VENDOR" });
        }
    }
}
