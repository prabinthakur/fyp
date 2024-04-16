using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyp.Migrations
{
    /// <inheritdoc />
    public partial class imageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "StudentModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImamgeUrl",
                table: "corporations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "StudentModel");

            migrationBuilder.DropColumn(
                name: "ImamgeUrl",
                table: "corporations");
        }
    }
}
