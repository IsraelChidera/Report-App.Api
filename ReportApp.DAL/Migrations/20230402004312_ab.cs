using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class ab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f65b64a-64dc-46ca-87d7-9ea6ecdaabff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83396850-c817-41bc-9fcb-032af542323f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc747b9-ed9f-4e4a-9c7c-57bcd0726772");

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
                values: new object[] { "2eaed375-e724-4623-8988-25aca08628dc", "44a6ebe4-99c0-4bf4-a42a-8633756a4a4e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73fcaa88-a183-4d3c-bf6c-466b74c23cd1", "ed20d424-e27d-46ff-b0ff-343777c88404", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9bdb733-edba-4640-9669-6082bb679d49", "d72e4591-b95a-49ba-bd4b-f8241eb955b9", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eaed375-e724-4623-8988-25aca08628dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73fcaa88-a183-4d3c-bf6c-466b74c23cd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9bdb733-edba-4640-9669-6082bb679d49");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f65b64a-64dc-46ca-87d7-9ea6ecdaabff", "310694ed-5250-411f-965e-08d9ae8f4682", "Customer", "CUSTOMER" },
                    { "83396850-c817-41bc-9fcb-032af542323f", "6c1109f0-9001-4e68-8a85-0d99eb9d30dc", "Vendor", "VENDOR" },
                    { "acc747b9-ed9f-4e4a-9c7c-57bcd0726772", "37209d2d-4055-4e0e-8e08-58f7d81bc506", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "AdditionalInfo", "HazardDescription", "HazardRating", "Location", "PreventiveMeasure", "ResourceAtRisk", "RiskImpact", "RiskProbability", "UserId" },
                values: new object[,]
                {
                    { new Guid("10bc62a1-e8a6-476f-8fc2-743c1f46b8d8"), "Jo ..", "Baking is ...", 0, "Nsukka, Enugu", "Cakes and cakes materials ...", "Environment", 1, 1, null },
                    { new Guid("5f5ca5c5-3b5e-40a3-9a9e-9fa9b7d04d51"), "Jo ..", "Fashion world is ...", 0, "Agbelekale, Laos", "Remains of clothes ...", "Environment", 1, 1, null },
                    { new Guid("8c90bb06-13e5-4d8f-a14f-5461b9d2703a"), "Jo ..", "Environment is ...", 0, "Enugu, Enugu", "Eradixcated the use of pumps", "Environment", 1, 1, null },
                    { new Guid("a99b6593-2497-4baf-8568-15aa1c2f2e22"), "Jo ..", "Environment is ...", 0, "Enugu, Enugu", "Eradixcated the use of pumps", "Environment", 1, 1, null },
                    { new Guid("d4d1554e-4a96-4a34-bc71-c1f9b3ceba06"), "Jo ..", "Environment is ...", 0, "Ikeja, Lagos", "To ... ...", "Environment", 1, 1, null }
                });
        }
    }
}
