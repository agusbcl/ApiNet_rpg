using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNet.Migrations
{
    /// <inheritdoc />
    public partial class Add_RpgClassTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Characters",
                newName: "RpgClassId");

            migrationBuilder.CreateTable(
                name: "RpgClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RpgClassId",
                table: "Characters",
                column: "RpgClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_RpgClasses_RpgClassId",
                table: "Characters",
                column: "RpgClassId",
                principalTable: "RpgClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_RpgClasses_RpgClassId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "RpgClasses");

            migrationBuilder.DropIndex(
                name: "IX_Characters_RpgClassId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "RpgClassId",
                table: "Characters",
                newName: "Class");
        }
    }
}
