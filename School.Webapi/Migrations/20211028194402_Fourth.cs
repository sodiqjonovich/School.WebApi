using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Webapi.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37d4e524-8643-423b-b9ac-49c38a8c2689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a6e5aca-ee08-44be-8462-f3e3c7f27b29");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "News",
                newName: "ImageName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82bddbfe-382c-4f49-bfbe-7265a8f0af4d", "67c1656a-a490-4570-9c15-da74e3c4744d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf4792b6-7c91-4a55-9bd3-9f64e3c17ea3", "a16d55d5-5860-44b6-bcd3-5aabf04d28a3", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82bddbfe-382c-4f49-bfbe-7265a8f0af4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf4792b6-7c91-4a55-9bd3-9f64e3c17ea3");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "News",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a6e5aca-ee08-44be-8462-f3e3c7f27b29", "df509c31-bb15-4d6a-be58-47c84391faf7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37d4e524-8643-423b-b9ac-49c38a8c2689", "1355c38e-ebe8-46c6-8cea-585ce6b6c10b", "User", "USER" });
        }
    }
}
