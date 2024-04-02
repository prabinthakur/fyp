using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyp.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "corporations",
                columns: table => new
                {
                    CorporationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporationLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corporations", x => x.CorporationId);
                });

            migrationBuilder.CreateTable(
                name: "StudentModel",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModel", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Deadline = table.Column<DateOnly>(type: "date", nullable: false),
                    Categoryid = table.Column<int>(type: "int", nullable: false),
                    CorporationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_jobs_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobs_corporations_CorporationId",
                        column: x => x.CorporationId,
                        principalTable: "corporations",
                        principalColumn: "CorporationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualificationModel",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionYear = table.Column<DateOnly>(type: "date", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationModel", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_QualificationModel_StudentModel_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentModel",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationModel",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppliedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JosbId = table.Column<int>(type: "int", nullable: false),
                    JobsJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationModel", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_ApplicationModel_jobs_JobsJobId",
                        column: x => x.JobsJobId,
                        principalTable: "jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillsModel",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsModel", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_SkillsModel_jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationModel_JobsJobId",
                table: "ApplicationModel",
                column: "JobsJobId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_Categoryid",
                table: "jobs",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CorporationId",
                table: "jobs",
                column: "CorporationId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationModel_StudentId",
                table: "QualificationModel",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsModel_JobsId",
                table: "SkillsModel",
                column: "JobsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationModel");

            migrationBuilder.DropTable(
                name: "QualificationModel");

            migrationBuilder.DropTable(
                name: "SkillsModel");

            migrationBuilder.DropTable(
                name: "StudentModel");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "corporations");
        }
    }
}
