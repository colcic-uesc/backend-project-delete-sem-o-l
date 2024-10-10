using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class Projetonulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Projects_FK",
                table: "Professors");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProfessorId",
                table: "Projects",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Professors_ProfessorId",
                table: "Projects",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Professors_ProfessorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProfessorId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Projects_FK",
                table: "Professors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
