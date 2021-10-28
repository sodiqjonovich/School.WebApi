using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Webapi.Migrations
{
    public partial class EditedImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45ec2d3c-4879-4b7d-b089-b7cdc2686cc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9370247f-4d3c-4d64-8a56-c43be8899e85");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Pupils",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Image",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Employees",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45ec2d3c-4879-4b7d-b089-b7cdc2686cc4", "021ad35a-a42f-4110-9e63-8ad579665936", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9370247f-4d3c-4d64-8a56-c43be8899e85", "60af4ebb-fccc-48cd-aff7-55b579a14ea2", "User", "USER" });
        }
    }
}
