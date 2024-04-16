using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyp.Migrations
{
    /// <inheritdoc />
    public partial class imageCorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImamgeUrl",
                table: "corporations");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "corporations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "corporations");

            migrationBuilder.AddColumn<string>(
                name: "ImamgeUrl",
                table: "corporations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
