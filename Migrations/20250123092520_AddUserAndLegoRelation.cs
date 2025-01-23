using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaFabriqueaBriques.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndLegoRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nbPiece",
                table: "Legos",
                newName: "NbPiece");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Legos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Legos_UserId",
                table: "Legos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Legos_Users_UserId",
                table: "Legos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legos_Users_UserId",
                table: "Legos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Legos_UserId",
                table: "Legos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Legos");

            migrationBuilder.RenameColumn(
                name: "NbPiece",
                table: "Legos",
                newName: "nbPiece");
        }
    }
}
