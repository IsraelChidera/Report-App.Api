using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class SeedReportData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_customers_CustomerId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_vendors_VendorId",
                table: "Report");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fdb591c-926a-4cac-8a64-9f551ac0361d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9270909d-3c87-4031-8c2e-e2362dabd411");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d543a22e-cad4-4182-b3d2-38deaba3be12");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Report");

            migrationBuilder.AlterColumn<Guid>(
                name: "VendorId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "285685f2-a931-482b-9fab-20228d42eae4", "6fa1a9f9-dd69-452b-a1b8-032fc2fdcbb2", "Customer", "CUSTOMER" },
                    { "5531a992-4c4b-4854-862c-c1d6cddb7bc3", "846f6c5f-5479-4d8e-9821-4a8a3492169a", "Admin", "ADMIN" },
                    { "d8a949d1-68b2-401f-b5b5-19fbc8d8dd97", "a0c9ef95-e950-4792-b469-0cd32f4209a6", "Vendor", "VENDOR" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "AdminId", "Address", "FullName" },
                values: new object[,]
                {
                    { new Guid("b4216dbf-f4c1-4b4a-a418-75f4efbc54f4"), "Greenwood, Canada", "Ramsey Icee" },
                    { new Guid("dbdcefb9-7e1f-4699-aa6b-d1636c601f6b"), "Ondo,Delta", "Lumueus Fadeyi" },
                    { new Guid("e87c3a3f-8e56-49c3-9d48-61833e7a1a13"), "Ugwuaji, Enugu", "Israel Chidera" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "CustomerId", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("02a3d3b1-9b57-4c81-b99e-af54041bda38"), "1A, Ohiala, New Market Rd., Enugu", "Emmanuel Ogbodo", "09087762534" },
                    { new Guid("8a8c1f05-3255-4f9d-80d8-00c2d17221bf"), "5A, Riverdale street, L.A", "Emeka Anslem", "09112783833" },
                    { new Guid("ab873ce9-f1f1-45c2-a925-bf24e0c3a3a7"), null, "Chioma Chukwuka", "08115627788" }
                });

            migrationBuilder.InsertData(
                table: "vendors",
                columns: new[] { "VendorId", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("a58b932a-562f-4c4a-8724-4c7dfc4b8d12"), "Captain bus stop, Agbele, Lagos", "Joy Lobo", "0906234566" },
                    { new Guid("c580a7b9-1431-4df1-ba4b-347e4c4fbba8"), "Akara junction, Nsukka", "Glory Chinonye", "08146255234" },
                    { new Guid("ee3d9db9-0a70-4c81-a1a1-2c152b2d0ca7"), "Genesis estate, Alagbado, Lagos", "Darlington Obinna", "0906234566" }
                });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "ReportId", "AdditionalInfo", "CustomerId", "HazardDescription", "HazardRating", "Location", "PreventiveMeasure", "ResourceAtRisk", "RiskImpact", "RiskProbability", "VendorId" },
                values: new object[,]
                {
                    { new Guid("10bc62a1-e8a6-476f-8fc2-743c1f46b8d8"), "Jo ..", null, "Baking is ...", 0, "Nsukka, Enugu", "Cakes and cakes materials ...", "Environment", 1, 1, new Guid("c580a7b9-1431-4df1-ba4b-347e4c4fbba8") },
                    { new Guid("5f5ca5c5-3b5e-40a3-9a9e-9fa9b7d04d51"), "Jo ..", null, "Fashion world is ...", 0, "Agbelekale, Laos", "Remains of clothes ...", "Environment", 1, 1, new Guid("a58b932a-562f-4c4a-8724-4c7dfc4b8d12") },
                    { new Guid("8c90bb06-13e5-4d8f-a14f-5461b9d2703a"), "Jo ..", new Guid("02a3d3b1-9b57-4c81-b99e-af54041bda38"), "Environment is ...", 0, "Enugu, Enugu", "Eradixcated the use of pumps", "Environment", 1, 1, null },
                    { new Guid("a99b6593-2497-4baf-8568-15aa1c2f2e22"), "Jo ..", new Guid("ab873ce9-f1f1-45c2-a925-bf24e0c3a3a7"), "Environment is ...", 0, "Enugu, Enugu", "Eradixcated the use of pumps", "Environment", 1, 1, null },
                    { new Guid("d4d1554e-4a96-4a34-bc71-c1f9b3ceba06"), "Jo ..", new Guid("02a3d3b1-9b57-4c81-b99e-af54041bda38"), "Environment is ...", 0, "Ikeja, Lagos", "To ... ...", "Environment", 1, 1, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Report_customers_CustomerId",
                table: "Report",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_vendors_VendorId",
                table: "Report",
                column: "VendorId",
                principalTable: "vendors",
                principalColumn: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_customers_CustomerId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_vendors_VendorId",
                table: "Report");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "285685f2-a931-482b-9fab-20228d42eae4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5531a992-4c4b-4854-862c-c1d6cddb7bc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a949d1-68b2-401f-b5b5-19fbc8d8dd97");

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: new Guid("10bc62a1-e8a6-476f-8fc2-743c1f46b8d8"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: new Guid("5f5ca5c5-3b5e-40a3-9a9e-9fa9b7d04d51"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: new Guid("8c90bb06-13e5-4d8f-a14f-5461b9d2703a"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: new Guid("a99b6593-2497-4baf-8568-15aa1c2f2e22"));

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "ReportId",
                keyValue: new Guid("d4d1554e-4a96-4a34-bc71-c1f9b3ceba06"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "AdminId",
                keyValue: new Guid("b4216dbf-f4c1-4b4a-a418-75f4efbc54f4"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "AdminId",
                keyValue: new Guid("dbdcefb9-7e1f-4699-aa6b-d1636c601f6b"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "AdminId",
                keyValue: new Guid("e87c3a3f-8e56-49c3-9d48-61833e7a1a13"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("8a8c1f05-3255-4f9d-80d8-00c2d17221bf"));

            migrationBuilder.DeleteData(
                table: "vendors",
                keyColumn: "VendorId",
                keyValue: new Guid("ee3d9db9-0a70-4c81-a1a1-2c152b2d0ca7"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("02a3d3b1-9b57-4c81-b99e-af54041bda38"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("ab873ce9-f1f1-45c2-a925-bf24e0c3a3a7"));

            migrationBuilder.DeleteData(
                table: "vendors",
                keyColumn: "VendorId",
                keyValue: new Guid("a58b932a-562f-4c4a-8724-4c7dfc4b8d12"));

            migrationBuilder.DeleteData(
                table: "vendors",
                keyColumn: "VendorId",
                keyValue: new Guid("c580a7b9-1431-4df1-ba4b-347e4c4fbba8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "VendorId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3fdb591c-926a-4cac-8a64-9f551ac0361d", "956129d3-5586-4311-9832-029c81595f0b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9270909d-3c87-4031-8c2e-e2362dabd411", "9fda7508-e000-462f-8178-94aafc6941d5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d543a22e-cad4-4182-b3d2-38deaba3be12", "bb53c3e6-2e03-4afe-9681-6e2f430fdd66", "Vendor", "VENDOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Report_customers_CustomerId",
                table: "Report",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_vendors_VendorId",
                table: "Report",
                column: "VendorId",
                principalTable: "vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
