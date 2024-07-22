using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnCore.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationaddImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                schema: "HR",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagePath",
                schema: "HR",
                table: "Items");
        }
    }
}
