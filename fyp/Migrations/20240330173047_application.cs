using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyp.Migrations
{
    /// <inheritdoc />
    public partial class application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentid",
                table: "ApplicationModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationModel_studentid",
                table: "ApplicationModel",
                column: "studentid");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationModel_StudentModel_studentid",
                table: "ApplicationModel",
                column: "studentid",
                principalTable: "StudentModel",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationModel_StudentModel_studentid",
                table: "ApplicationModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationModel_studentid",
                table: "ApplicationModel");

            migrationBuilder.DropColumn(
                name: "studentid",
                table: "ApplicationModel");
        }
    }
}
