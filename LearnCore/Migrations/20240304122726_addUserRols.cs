using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearnCore.Migrations
{
    /// <inheritdoc />
    public partial class addUserRols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c666247b-dbf0-490b-af84-f3f94af78063", "50c88bc6-a322-4654-bc42-44ded6fd4f50", "Admin", "admin" },
                    { "c7ad976e-8394-4153-b64c-49b96a91107a", "c247d729-7ecd-46d3-8b91-2e1f75e237ef", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c666247b-dbf0-490b-af84-f3f94af78063");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ad976e-8394-4153-b64c-49b96a91107a");
        }
    }
}
