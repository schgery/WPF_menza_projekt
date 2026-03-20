using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_menza_projekt.Migrations
{
    /// <inheritdoc />
    public partial class elso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "desszertek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desszertek", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "foetelek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foetelek", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "levesek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levesek", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vendelek",
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
                    table.PrimaryKey("PK_vendelek", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "napietkezesek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    datum = table.Column<DateOnly>(type: "date", nullable: false),
                    levesid = table.Column<int>(type: "int", nullable: false),
                    foetelid = table.Column<int>(type: "int", nullable: false),
                    desszertid = table.Column<int>(type: "int", nullable: true),
                    vendelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_napietkezesek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_napietkezesek_desszertek_desszertid",
                        column: x => x.desszertid,
                        principalTable: "desszertek",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_napietkezesek_foetelek_foetelid",
                        column: x => x.foetelid,
                        principalTable: "foetelek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_napietkezesek_levesek_levesid",
                        column: x => x.levesid,
                        principalTable: "levesek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_napietkezesek_vendelek_vendelId",
                        column: x => x.vendelId,
                        principalTable: "vendelek",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_napietkezesek_desszertid",
                table: "napietkezesek",
                column: "desszertid");

            migrationBuilder.CreateIndex(
                name: "IX_napietkezesek_foetelid",
                table: "napietkezesek",
                column: "foetelid");

            migrationBuilder.CreateIndex(
                name: "IX_napietkezesek_levesid",
                table: "napietkezesek",
                column: "levesid");

            migrationBuilder.CreateIndex(
                name: "IX_napietkezesek_vendelId",
                table: "napietkezesek",
                column: "vendelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "napietkezesek");

            migrationBuilder.DropTable(
                name: "desszertek");

            migrationBuilder.DropTable(
                name: "foetelek");

            migrationBuilder.DropTable(
                name: "levesek");

            migrationBuilder.DropTable(
                name: "vendelek");
        }
    }
}
