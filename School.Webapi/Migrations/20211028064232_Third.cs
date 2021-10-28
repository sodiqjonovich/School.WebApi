using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Webapi.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1070b118-0397-4ad4-9ae2-7c31e341dcbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e0b5068-c53f-4cd7-8ea3-000853746e4c");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Pupils",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Employees",
                newName: "ImageName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a6e5aca-ee08-44be-8462-f3e3c7f27b29", "df509c31-bb15-4d6a-be58-47c84391faf7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37d4e524-8643-423b-b9ac-49c38a8c2689", "1355c38e-ebe8-46c6-8cea-585ce6b6c10b", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ImageName",
                table: "Pupils",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Employees",
                newName: "ImagePath");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1070b118-0397-4ad4-9ae2-7c31e341dcbd", "bfcd2f96-f107-4f70-ae6b-e13a3e95f358", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e0b5068-c53f-4cd7-8ea3-000853746e4c", "cd711c5c-dde6-4ed5-b988-81bddb66ecb0", "User", "USER" });
        }
    }
}
