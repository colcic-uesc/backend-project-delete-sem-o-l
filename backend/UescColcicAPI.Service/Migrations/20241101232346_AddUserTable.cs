using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID_FK",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID_FK",
                table: "Professors",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Rules = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID_FK",
                table: "Students",
                column: "UserID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professors_UserID_FK",
                table: "Professors",
                column: "UserID_FK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Users_UserID_FK",
                table: "Professors",
                column: "UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserID_FK",
                table: "Students",
                column: "UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Users_UserID_FK",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserID_FK",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserID_FK",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Professors_UserID_FK",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "UserID_FK",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserID_FK",
                table: "Professors");
        }
    }
}
