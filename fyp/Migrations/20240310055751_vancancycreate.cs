using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyp.Migrations
{
    /// <inheritdoc />
    public partial class vancancycreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccancy",
                columns: table => new
                {
                    VaccancyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vaccancytype = table.Column<int>(type: "int", nullable: false),
                    VaccancyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccancy", x => x.VaccancyID);
                    table.ForeignKey(
                        name: "FK_Vaccancy_Category_vaccancytype",
                        column: x => x.vaccancytype,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccancy_vaccancytype",
                table: "Vaccancy",
                column: "vaccancytype");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccancy");
        }
    }
}
