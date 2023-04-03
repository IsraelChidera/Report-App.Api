using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bb826e5-ce8d-484d-8ed2-d9f4dadf701b", "cfdec8fa-8efa-49d0-ac95-0af4ec191f34", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54c6dd8c-0745-49d7-858b-621f4600097f", "06392790-607d-451f-a903-6611fe7a97ae", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6182487b-0997-4df5-8d88-6baf8af53706", "ccb6a434-5c68-4b1e-bea4-68ebd4f5a181", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bb826e5-ce8d-484d-8ed2-d9f4dadf701b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54c6dd8c-0745-49d7-858b-621f4600097f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6182487b-0997-4df5-8d88-6baf8af53706");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6db8afdd-531d-4cba-bf13-5d5d503961eb", "17dcafb5-ea69-4154-beb3-839d4e95016b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "833b14a0-8354-4741-a602-2d3a03439070", "dbf349f7-88eb-40f1-9de5-28899c68e3e8", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be19b707-94f2-458c-8e31-8f7447ad81ed", "743c8da3-e372-4734-b7f0-34d94582ff57", "Customer", "CUSTOMER" });
        }
    }
}
