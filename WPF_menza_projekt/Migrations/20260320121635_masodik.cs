using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_menza_projekt.Migrations
{
    /// <inheritdoc />
    public partial class masodik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_napietkezesek_vendelek_vendelId",
                table: "napietkezesek");

            migrationBuilder.DropTable(
                name: "vendelek");

            migrationBuilder.RenameColumn(
                name: "vendelId",
                table: "napietkezesek",
                newName: "vendegId");

            migrationBuilder.RenameIndex(
                name: "IX_napietkezesek_vendelId",
                table: "napietkezesek",
                newName: "IX_napietkezesek_vendegId");

            migrationBuilder.CreateTable(
                name: "vendegek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    diak = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendegek", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_napietkezesek_vendegek_vendegId",
                table: "napietkezesek",
                column: "vendegId",
                principalTable: "vendegek",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_napietkezesek_vendegek_vendegId",
                table: "napietkezesek");

            migrationBuilder.DropTable(
                name: "vendegek");

            migrationBuilder.RenameColumn(
                name: "vendegId",
                table: "napietkezesek",
                newName: "vendelId");

            migrationBuilder.RenameIndex(
                name: "IX_napietkezesek_vendegId",
                table: "napietkezesek",
                newName: "IX_napietkezesek_vendelId");

            migrationBuilder.CreateTable(
                name: "vendelek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    diak = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    nev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendelek", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_napietkezesek_vendelek_vendelId",
                table: "napietkezesek",
                column: "vendelId",
                principalTable: "vendelek",
                principalColumn: "Id");
        }
    }
}
