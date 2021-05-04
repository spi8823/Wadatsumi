using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadatsumi.Migrations
{
    public partial class AddTheory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TheoryDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    KamiID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoryDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TheoryDbSet_KamiDbSet_KamiID",
                        column: x => x.KamiID,
                        principalTable: "KamiDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheoryRelationDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TheoryID = table.Column<int>(type: "INTEGER", nullable: true),
                    JinjaID = table.Column<int>(type: "INTEGER", nullable: true),
                    KamiID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoryRelationDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TheoryRelationDbSet_JinjaDbSet_JinjaID",
                        column: x => x.JinjaID,
                        principalTable: "JinjaDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheoryRelationDbSet_KamiDbSet_KamiID",
                        column: x => x.KamiID,
                        principalTable: "KamiDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheoryRelationDbSet_TheoryDbSet_TheoryID",
                        column: x => x.TheoryID,
                        principalTable: "TheoryDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheoryDbSet_KamiID",
                table: "TheoryDbSet",
                column: "KamiID");

            migrationBuilder.CreateIndex(
                name: "IX_TheoryRelationDbSet_JinjaID",
                table: "TheoryRelationDbSet",
                column: "JinjaID");

            migrationBuilder.CreateIndex(
                name: "IX_TheoryRelationDbSet_KamiID",
                table: "TheoryRelationDbSet",
                column: "KamiID");

            migrationBuilder.CreateIndex(
                name: "IX_TheoryRelationDbSet_TheoryID",
                table: "TheoryRelationDbSet",
                column: "TheoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheoryRelationDbSet");

            migrationBuilder.DropTable(
                name: "TheoryDbSet");
        }
    }
}
