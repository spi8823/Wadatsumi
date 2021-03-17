using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadatsumi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KamiDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KamiDbSet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shinmei",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KamiID = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Kana = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shinmei", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shinmei_KamiDbSet_KamiID",
                        column: x => x.KamiID,
                        principalTable: "KamiDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ryouseikoku",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RegionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ryouseikoku", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ryouseikoku_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JinjaDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Kana = table.Column<string>(type: "TEXT", nullable: true),
                    RyouseikokuID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JinjaDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JinjaDbSet_Ryouseikoku_RyouseikokuID",
                        column: x => x.RyouseikokuID,
                        principalTable: "Ryouseikoku",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saijin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JinjaID = table.Column<int>(type: "INTEGER", nullable: true),
                    KamiID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saijin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Saijin_JinjaDbSet_JinjaID",
                        column: x => x.JinjaID,
                        principalTable: "JinjaDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saijin_KamiDbSet_KamiID",
                        column: x => x.KamiID,
                        principalTable: "KamiDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JinjaDbSet_RyouseikokuID",
                table: "JinjaDbSet",
                column: "RyouseikokuID");

            migrationBuilder.CreateIndex(
                name: "IX_Ryouseikoku_RegionID",
                table: "Ryouseikoku",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Saijin_JinjaID",
                table: "Saijin",
                column: "JinjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Saijin_KamiID",
                table: "Saijin",
                column: "KamiID");

            migrationBuilder.CreateIndex(
                name: "IX_Shinmei_KamiID",
                table: "Shinmei",
                column: "KamiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saijin");

            migrationBuilder.DropTable(
                name: "Shinmei");

            migrationBuilder.DropTable(
                name: "JinjaDbSet");

            migrationBuilder.DropTable(
                name: "KamiDbSet");

            migrationBuilder.DropTable(
                name: "Ryouseikoku");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
