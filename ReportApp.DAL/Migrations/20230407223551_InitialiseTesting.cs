using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class InitialiseTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2afc60d7-431c-40eb-95ad-8f6440205f6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ad411cf-c9c7-4fb0-9ab2-5ba5222c33e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f938da8d-5d5f-4cb3-b642-6014d9512952");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b354ec1-bc0a-4de6-9146-3e2f59fa2997", "7a4b391d-2147-4a7c-a5bb-756f01f09224", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59c938c7-da48-4d17-9957-9b61225d0646", "6dea63b3-6638-4362-a3f1-5cc4d0cc3bd1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df65a36a-9743-40a1-a3de-046e338fb09e", "b0c71b3d-7ad3-4346-83f9-19cfaf3e80ee", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b354ec1-bc0a-4de6-9146-3e2f59fa2997");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59c938c7-da48-4d17-9957-9b61225d0646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df65a36a-9743-40a1-a3de-046e338fb09e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2afc60d7-431c-40eb-95ad-8f6440205f6e", "1d51ef2d-af0f-4fef-8362-300f3d6c3183", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ad411cf-c9c7-4fb0-9ab2-5ba5222c33e9", "219d97f9-82cf-4e2d-bc7d-395da0507f8e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f938da8d-5d5f-4cb3-b642-6014d9512952", "3ca41bd9-0d27-4483-81d6-67905bca33c1", "Customer", "CUSTOMER" });
        }
    }
}
