using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    public partial class AddUseColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10b75448-9498-4732-afba-d672d75ec4d3", "c9f7390c-449c-4d65-a2e7-9017be114683", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "42c8f83c-8807-47e8-ab47-495a8eba29fe", "5c20e9af-4b97-43f3-83c8-00bdb0210841", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c1b3927-6d30-4b4a-b2b2-369baf4c5a07", "978e7698-fe21-4d38-9e64-edd1d7ea52c7", "Vendor", "VENDOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10b75448-9498-4732-afba-d672d75ec4d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42c8f83c-8807-47e8-ab47-495a8eba29fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c1b3927-6d30-4b4a-b2b2-369baf4c5a07");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
    }
}
