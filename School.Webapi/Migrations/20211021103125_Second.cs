using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Webapi.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a9e9dcc-41a3-4424-ab18-b64c35110842");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b44b24a1-fca7-491d-8543-8156d3d3b395");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "531d7727-16aa-4303-97c0-28c54b702b82", "2cd7332f-272d-4f7b-a24e-df5c85da5c58", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87a927a0-847b-47b7-bf77-514af1468bab", "79e19538-8f7a-431b-8018-9385942fe19c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "531d7727-16aa-4303-97c0-28c54b702b82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87a927a0-847b-47b7-bf77-514af1468bab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b44b24a1-fca7-491d-8543-8156d3d3b395", "860be2e9-794f-4c7a-bfaf-26838b8e5639", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a9e9dcc-41a3-4424-ab18-b64c35110842", "4bbdf5db-bdd4-43f5-87f1-a3078257e017", "User", "USER" });
        }
    }
}
