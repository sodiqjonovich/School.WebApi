using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Webapi.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b44b24a1-fca7-491d-8543-8156d3d3b395", "860be2e9-794f-4c7a-bfaf-26838b8e5639", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a9e9dcc-41a3-4424-ab18-b64c35110842", "4bbdf5db-bdd4-43f5-87f1-a3078257e017", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a9e9dcc-41a3-4424-ab18-b64c35110842");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b44b24a1-fca7-491d-8543-8156d3d3b395");
        }
    }
}
