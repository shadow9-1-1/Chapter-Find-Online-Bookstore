using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chapter_Find_Online_Bookstore.Migrations
{
    /// <inheritdoc />
    public partial class RolesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02ad55ad-6c39-45f3-a428-a340277e35dc", null, "customers", "customers" },
                    { "45b97dc4-0529-42ff-8a78-56cc41f77055", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02ad55ad-6c39-45f3-a428-a340277e35dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45b97dc4-0529-42ff-8a78-56cc41f77055");
        }
    }
}
