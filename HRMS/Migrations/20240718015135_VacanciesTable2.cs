using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class VacanciesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comm_Vacancies",
                columns: table => new
                {
                    Pk_VacanciesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_DesignationId = table.Column<int>(type: "int", nullable: false),
                    Fk_ExperienceId = table.Column<int>(type: "int", nullable: false),
                    TotalPost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technology = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comm_Vacancies", x => x.Pk_VacanciesID);
                    table.ForeignKey(
                        name: "FK_Comm_Vacancies_Designations_Fk_DesignationId",
                        column: x => x.Fk_DesignationId,
                        principalTable: "Designations",
                        principalColumn: "PK_DesignationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comm_Vacancies_Fk_DesignationId",
                table: "Comm_Vacancies",
                column: "Fk_DesignationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comm_Vacancies");
        }
    }
}
