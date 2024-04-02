using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyp.Migrations
{
    /// <inheritdoc />
    public partial class th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationModel_StudentModel_studentid",
                table: "ApplicationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationModel_jobs_JobsJobId",
                table: "ApplicationModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationModel_JobsJobId",
                table: "ApplicationModel");

            migrationBuilder.DropColumn(
                name: "JobsJobId",
                table: "ApplicationModel");

            migrationBuilder.RenameColumn(
                name: "studentid",
                table: "ApplicationModel",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "JosbId",
                table: "ApplicationModel",
                newName: "JobsId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationModel_studentid",
                table: "ApplicationModel",
                newName: "IX_ApplicationModel_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationModel_JobsId",
                table: "ApplicationModel",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationModel_StudentModel_StudentId",
                table: "ApplicationModel",
                column: "StudentId",
                principalTable: "StudentModel",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationModel_jobs_JobsId",
                table: "ApplicationModel",
                column: "JobsId",
                principalTable: "jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationModel_StudentModel_StudentId",
                table: "ApplicationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationModel_jobs_JobsId",
                table: "ApplicationModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationModel_JobsId",
                table: "ApplicationModel");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ApplicationModel",
                newName: "studentid");

            migrationBuilder.RenameColumn(
                name: "JobsId",
                table: "ApplicationModel",
                newName: "JosbId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationModel_StudentId",
                table: "ApplicationModel",
                newName: "IX_ApplicationModel_studentid");

            migrationBuilder.AddColumn<int>(
                name: "JobsJobId",
                table: "ApplicationModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationModel_JobsJobId",
                table: "ApplicationModel",
                column: "JobsJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationModel_StudentModel_studentid",
                table: "ApplicationModel",
                column: "studentid",
                principalTable: "StudentModel",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationModel_jobs_JobsJobId",
                table: "ApplicationModel",
                column: "JobsJobId",
                principalTable: "jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
