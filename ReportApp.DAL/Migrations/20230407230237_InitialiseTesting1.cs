using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class InitialiseTesting1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2a6ed3bb-0dce-4d30-81d0-baf7fed2bf96", "e07bcf49-9496-4591-834a-3739d47a828e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "519cfffd-aebc-416a-a9a0-6d2d27ade639", "79b2dc08-6e3b-43e6-bb7b-dd758c7c99fc", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c09b6c9-9c41-488c-94c1-75a3058a5bd9", "ffb0b02e-43d1-4e6d-a93e-fcb466122d6f", "Vendor", "VENDOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a6ed3bb-0dce-4d30-81d0-baf7fed2bf96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "519cfffd-aebc-416a-a9a0-6d2d27ade639");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c09b6c9-9c41-488c-94c1-75a3058a5bd9");

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
    }
}
