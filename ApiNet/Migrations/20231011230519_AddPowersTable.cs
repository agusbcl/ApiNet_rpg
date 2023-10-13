using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNet.Migrations
{
    /// <inheritdoc />
    public partial class AddPowersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPower",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    PowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPower", x => new { x.CharactersId, x.PowersId });
                    table.ForeignKey(
                        name: "FK_CharacterPower_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPower_Powers_PowersId",
                        column: x => x.PowersId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPower_PowersId",
                table: "CharacterPower",
                column: "PowersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterPower");

            migrationBuilder.DropTable(
                name: "Powers");
        }
    }
}
