using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaFabriqueaBriques.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Legos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Legos_UserId",
                table: "Legos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Legos_Users_UserId",
                table: "Legos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legos_Users_UserId",
                table: "Legos");

            migrationBuilder.DropIndex(
                name: "IX_Legos_UserId",
                table: "Legos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Legos");
        }
    }
}
