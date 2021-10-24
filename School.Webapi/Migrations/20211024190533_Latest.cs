using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Webapi.Migrations
{
    public partial class Latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c45d89e-64ce-4c87-b9e4-ce84a31db3a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3dca58d-8258-4828-b4fb-e6b08fb3bbcf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45ec2d3c-4879-4b7d-b089-b7cdc2686cc4", "021ad35a-a42f-4110-9e63-8ad579665936", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9370247f-4d3c-4d64-8a56-c43be8899e85", "60af4ebb-fccc-48cd-aff7-55b579a14ea2", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45ec2d3c-4879-4b7d-b089-b7cdc2686cc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9370247f-4d3c-4d64-8a56-c43be8899e85");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3dca58d-8258-4828-b4fb-e6b08fb3bbcf", "feef11b6-1cdb-4d49-93ad-b5059387fa8f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c45d89e-64ce-4c87-b9e4-ce84a31db3a6", "c1d7414f-a803-45e2-9e8a-357d2fa508c0", "User", "USER" });
        }
    }
}
