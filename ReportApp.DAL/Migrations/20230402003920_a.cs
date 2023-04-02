using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b026870f-969e-4a11-881d-d7ab01072821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5371058-fce0-4694-b10c-2718c71c4590");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeff6a57-bd19-47da-b665-d8682c49e413");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f65b64a-64dc-46ca-87d7-9ea6ecdaabff", "310694ed-5250-411f-965e-08d9ae8f4682", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83396850-c817-41bc-9fcb-032af542323f", "6c1109f0-9001-4e68-8a85-0d99eb9d30dc", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acc747b9-ed9f-4e4a-9c7c-57bcd0726772", "37209d2d-4055-4e0e-8e08-58f7d81bc506", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b026870f-969e-4a11-881d-d7ab01072821", "94e94f5c-da19-47cc-944c-b61a3dbc1b1c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5371058-fce0-4694-b10c-2718c71c4590", "2afaba5a-3277-4d6a-81a2-6e1e18288bd8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eeff6a57-bd19-47da-b665-d8682c49e413", "40f55e7f-db0a-41c9-aabd-b5b674dcb087", "Vendor", "VENDOR" });
        }
    }
}
