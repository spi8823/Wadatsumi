using System;
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
                name: "PrefectureDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefectureDbSet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RegionDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionDbSet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShinmeiDbSet",
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
                    table.PrimaryKey("PK_ShinmeiDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShinmeiDbSet_KamiDbSet_KamiID",
                        column: x => x.KamiID,
                        principalTable: "KamiDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MunicipalityDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrefectureID = table.Column<int>(type: "INTEGER", nullable: true),
                    MuniCd = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalityDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MunicipalityDbSet_PrefectureDbSet_PrefectureID",
                        column: x => x.PrefectureID,
                        principalTable: "PrefectureDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RyouseikokuDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RegionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RyouseikokuDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RyouseikokuDbSet_RegionDbSet_RegionID",
                        column: x => x.RegionID,
                        principalTable: "RegionDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    PrefectureID = table.Column<int>(type: "INTEGER", nullable: true),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LocationDbSet_MunicipalityDbSet_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "MunicipalityDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationDbSet_PrefectureDbSet_PrefectureID",
                        column: x => x.PrefectureID,
                        principalTable: "PrefectureDbSet",
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
                    LocationID = table.Column<int>(type: "INTEGER", nullable: true),
                    RyouseikokuID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JinjaDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JinjaDbSet_LocationDbSet_LocationID",
                        column: x => x.LocationID,
                        principalTable: "LocationDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JinjaDbSet_RyouseikokuDbSet_RyouseikokuID",
                        column: x => x.RyouseikokuID,
                        principalTable: "RyouseikokuDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoshuinDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JinjaID = table.Column<int>(type: "INTEGER", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoshuinDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GoshuinDbSet_JinjaDbSet_JinjaID",
                        column: x => x.JinjaID,
                        principalTable: "JinjaDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaijinDbSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JinjaID = table.Column<int>(type: "INTEGER", nullable: true),
                    KamiID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaijinDbSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaijinDbSet_JinjaDbSet_JinjaID",
                        column: x => x.JinjaID,
                        principalTable: "JinjaDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaijinDbSet_KamiDbSet_KamiID",
                        column: x => x.KamiID,
                        principalTable: "KamiDbSet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoshuinDbSet_JinjaID",
                table: "GoshuinDbSet",
                column: "JinjaID");

            migrationBuilder.CreateIndex(
                name: "IX_JinjaDbSet_LocationID",
                table: "JinjaDbSet",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_JinjaDbSet_RyouseikokuID",
                table: "JinjaDbSet",
                column: "RyouseikokuID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationDbSet_MunicipalityID",
                table: "LocationDbSet",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationDbSet_PrefectureID",
                table: "LocationDbSet",
                column: "PrefectureID");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityDbSet_PrefectureID",
                table: "MunicipalityDbSet",
                column: "PrefectureID");

            migrationBuilder.CreateIndex(
                name: "IX_RyouseikokuDbSet_RegionID",
                table: "RyouseikokuDbSet",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_SaijinDbSet_JinjaID",
                table: "SaijinDbSet",
                column: "JinjaID");

            migrationBuilder.CreateIndex(
                name: "IX_SaijinDbSet_KamiID",
                table: "SaijinDbSet",
                column: "KamiID");

            migrationBuilder.CreateIndex(
                name: "IX_ShinmeiDbSet_KamiID",
                table: "ShinmeiDbSet",
                column: "KamiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoshuinDbSet");

            migrationBuilder.DropTable(
                name: "SaijinDbSet");

            migrationBuilder.DropTable(
                name: "ShinmeiDbSet");

            migrationBuilder.DropTable(
                name: "JinjaDbSet");

            migrationBuilder.DropTable(
                name: "KamiDbSet");

            migrationBuilder.DropTable(
                name: "LocationDbSet");

            migrationBuilder.DropTable(
                name: "RyouseikokuDbSet");

            migrationBuilder.DropTable(
                name: "MunicipalityDbSet");

            migrationBuilder.DropTable(
                name: "RegionDbSet");

            migrationBuilder.DropTable(
                name: "PrefectureDbSet");
        }
    }
}
