using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_menza_projekt.Migrations
{
    /// <inheritdoc />
    public partial class harmadik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_napietkezesek_vendegek_vendegId",
                table: "napietkezesek");

            migrationBuilder.DropIndex(
                name: "IX_napietkezesek_vendegId",
                table: "napietkezesek");

            migrationBuilder.DropColumn(
                name: "vendegId",
                table: "napietkezesek");

            migrationBuilder.CreateTable(
                name: "vendegnapietkezesek",
                columns: table => new
                {
                    vendegid = table.Column<int>(type: "int", nullable: false),
                    napietkezesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendegnapietkezesek", x => new { x.vendegid, x.napietkezesid });
                    table.ForeignKey(
                        name: "FK_vendegnapietkezesek_napietkezesek_napietkezesid",
                        column: x => x.napietkezesid,
                        principalTable: "napietkezesek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendegnapietkezesek_vendegek_vendegid",
                        column: x => x.vendegid,
                        principalTable: "vendegek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_vendegnapietkezesek_napietkezesid",
                table: "vendegnapietkezesek",
                column: "napietkezesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vendegnapietkezesek");

            migrationBuilder.AddColumn<int>(
                name: "vendegId",
                table: "napietkezesek",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_napietkezesek_vendegId",
                table: "napietkezesek",
                column: "vendegId");

            migrationBuilder.AddForeignKey(
                name: "FK_napietkezesek_vendegek_vendegId",
                table: "napietkezesek",
                column: "vendegId",
                principalTable: "vendegek",
                principalColumn: "Id");
        }
    }
}
