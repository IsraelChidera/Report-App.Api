using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class AddPaymentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "54a0d771-2f11-418b-ab3b-bfa36f7547f7", "bec4255a-5a1a-4ff7-b8d6-30d0e6fd491f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3ffa685-3cfc-4991-ab49-644064da6edf", "389cd9d6-01fb-4a5d-ad87-97ba18eee725", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc2fca85-ad39-44f8-8af4-58ddb819cf86", "182707ac-9736-48a2-b44c-34c73f602ede", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54a0d771-2f11-418b-ab3b-bfa36f7547f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ffa685-3cfc-4991-ab49-644064da6edf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc2fca85-ad39-44f8-8af4-58ddb819cf86");

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
    }
}
