using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadatsumi.Migrations
{
    public partial class AddAllDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JinjaDbSet_Ryouseikoku_RyouseikokuID",
                table: "JinjaDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_Ryouseikoku_Region_RegionID",
                table: "Ryouseikoku");

            migrationBuilder.DropForeignKey(
                name: "FK_Saijin_JinjaDbSet_JinjaID",
                table: "Saijin");

            migrationBuilder.DropForeignKey(
                name: "FK_Saijin_KamiDbSet_KamiID",
                table: "Saijin");

            migrationBuilder.DropForeignKey(
                name: "FK_Shinmei_KamiDbSet_KamiID",
                table: "Shinmei");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shinmei",
                table: "Shinmei");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saijin",
                table: "Saijin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ryouseikoku",
                table: "Ryouseikoku");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.RenameTable(
                name: "Shinmei",
                newName: "ShinmeiDbSet");

            migrationBuilder.RenameTable(
                name: "Saijin",
                newName: "SaijinDbSet");

            migrationBuilder.RenameTable(
                name: "Ryouseikoku",
                newName: "RyouseikokuDbSet");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "RegionDbSet");

            migrationBuilder.RenameIndex(
                name: "IX_Shinmei_KamiID",
                table: "ShinmeiDbSet",
                newName: "IX_ShinmeiDbSet_KamiID");

            migrationBuilder.RenameIndex(
                name: "IX_Saijin_KamiID",
                table: "SaijinDbSet",
                newName: "IX_SaijinDbSet_KamiID");

            migrationBuilder.RenameIndex(
                name: "IX_Saijin_JinjaID",
                table: "SaijinDbSet",
                newName: "IX_SaijinDbSet_JinjaID");

            migrationBuilder.RenameIndex(
                name: "IX_Ryouseikoku_RegionID",
                table: "RyouseikokuDbSet",
                newName: "IX_RyouseikokuDbSet_RegionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShinmeiDbSet",
                table: "ShinmeiDbSet",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaijinDbSet",
                table: "SaijinDbSet",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RyouseikokuDbSet",
                table: "RyouseikokuDbSet",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegionDbSet",
                table: "RegionDbSet",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JinjaDbSet_RyouseikokuDbSet_RyouseikokuID",
                table: "JinjaDbSet",
                column: "RyouseikokuID",
                principalTable: "RyouseikokuDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RyouseikokuDbSet_RegionDbSet_RegionID",
                table: "RyouseikokuDbSet",
                column: "RegionID",
                principalTable: "RegionDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaijinDbSet_JinjaDbSet_JinjaID",
                table: "SaijinDbSet",
                column: "JinjaID",
                principalTable: "JinjaDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaijinDbSet_KamiDbSet_KamiID",
                table: "SaijinDbSet",
                column: "KamiID",
                principalTable: "KamiDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShinmeiDbSet_KamiDbSet_KamiID",
                table: "ShinmeiDbSet",
                column: "KamiID",
                principalTable: "KamiDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JinjaDbSet_RyouseikokuDbSet_RyouseikokuID",
                table: "JinjaDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_RyouseikokuDbSet_RegionDbSet_RegionID",
                table: "RyouseikokuDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SaijinDbSet_JinjaDbSet_JinjaID",
                table: "SaijinDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SaijinDbSet_KamiDbSet_KamiID",
                table: "SaijinDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_ShinmeiDbSet_KamiDbSet_KamiID",
                table: "ShinmeiDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShinmeiDbSet",
                table: "ShinmeiDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaijinDbSet",
                table: "SaijinDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RyouseikokuDbSet",
                table: "RyouseikokuDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegionDbSet",
                table: "RegionDbSet");

            migrationBuilder.RenameTable(
                name: "ShinmeiDbSet",
                newName: "Shinmei");

            migrationBuilder.RenameTable(
                name: "SaijinDbSet",
                newName: "Saijin");

            migrationBuilder.RenameTable(
                name: "RyouseikokuDbSet",
                newName: "Ryouseikoku");

            migrationBuilder.RenameTable(
                name: "RegionDbSet",
                newName: "Region");

            migrationBuilder.RenameIndex(
                name: "IX_ShinmeiDbSet_KamiID",
                table: "Shinmei",
                newName: "IX_Shinmei_KamiID");

            migrationBuilder.RenameIndex(
                name: "IX_SaijinDbSet_KamiID",
                table: "Saijin",
                newName: "IX_Saijin_KamiID");

            migrationBuilder.RenameIndex(
                name: "IX_SaijinDbSet_JinjaID",
                table: "Saijin",
                newName: "IX_Saijin_JinjaID");

            migrationBuilder.RenameIndex(
                name: "IX_RyouseikokuDbSet_RegionID",
                table: "Ryouseikoku",
                newName: "IX_Ryouseikoku_RegionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shinmei",
                table: "Shinmei",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saijin",
                table: "Saijin",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ryouseikoku",
                table: "Ryouseikoku",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JinjaDbSet_Ryouseikoku_RyouseikokuID",
                table: "JinjaDbSet",
                column: "RyouseikokuID",
                principalTable: "Ryouseikoku",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ryouseikoku_Region_RegionID",
                table: "Ryouseikoku",
                column: "RegionID",
                principalTable: "Region",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saijin_JinjaDbSet_JinjaID",
                table: "Saijin",
                column: "JinjaID",
                principalTable: "JinjaDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saijin_KamiDbSet_KamiID",
                table: "Saijin",
                column: "KamiID",
                principalTable: "KamiDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shinmei_KamiDbSet_KamiID",
                table: "Shinmei",
                column: "KamiID",
                principalTable: "KamiDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
