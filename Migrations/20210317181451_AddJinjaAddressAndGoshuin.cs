using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadatsumi.Migrations
{
    public partial class AddJinjaAddressAndGoshuin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "JinjaDbSet",
                type: "TEXT",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_GoshuinDbSet_JinjaID",
                table: "GoshuinDbSet",
                column: "JinjaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoshuinDbSet");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "JinjaDbSet");
        }
    }
}
