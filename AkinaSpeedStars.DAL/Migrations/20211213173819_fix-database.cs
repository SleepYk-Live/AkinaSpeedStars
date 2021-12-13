using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkinaSpeedStars.DAL.Migrations
{
    public partial class fixdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitModelCode");

            migrationBuilder.DropTable(
                name: "PartPartTree");

            migrationBuilder.DropTable(
                name: "PartTreeScheme");

            migrationBuilder.DropIndex(
                name: "IX_Schemes_PartSubgroupId",
                table: "Schemes");

            migrationBuilder.AddColumn<int>(
                name: "SchemeId",
                table: "PartTrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartTreeId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelCodeId",
                table: "Kits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Kits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Kits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Schemes_PartSubgroupId",
                table: "Schemes",
                column: "PartSubgroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartTrees_SchemeId",
                table: "PartTrees",
                column: "SchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartTreeId",
                table: "Parts",
                column: "PartTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kits_ModelCodeId",
                table: "Kits",
                column: "ModelCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kits_ModelCodes_ModelCodeId",
                table: "Kits",
                column: "ModelCodeId",
                principalTable: "ModelCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartTrees_PartTreeId",
                table: "Parts",
                column: "PartTreeId",
                principalTable: "PartTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartTrees_Schemes_SchemeId",
                table: "PartTrees",
                column: "SchemeId",
                principalTable: "Schemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kits_ModelCodes_ModelCodeId",
                table: "Kits");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartTrees_PartTreeId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTrees_Schemes_SchemeId",
                table: "PartTrees");

            migrationBuilder.DropIndex(
                name: "IX_Schemes_PartSubgroupId",
                table: "Schemes");

            migrationBuilder.DropIndex(
                name: "IX_PartTrees_SchemeId",
                table: "PartTrees");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartTreeId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Kits_ModelCodeId",
                table: "Kits");

            migrationBuilder.DropColumn(
                name: "SchemeId",
                table: "PartTrees");

            migrationBuilder.DropColumn(
                name: "PartTreeId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ModelCodeId",
                table: "Kits");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Kits");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Kits");

            migrationBuilder.CreateTable(
                name: "KitModelCode",
                columns: table => new
                {
                    CodesId = table.Column<int>(type: "int", nullable: false),
                    KitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitModelCode", x => new { x.CodesId, x.KitsId });
                    table.ForeignKey(
                        name: "FK_KitModelCode_Kits_KitsId",
                        column: x => x.KitsId,
                        principalTable: "Kits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitModelCode_ModelCodes_CodesId",
                        column: x => x.CodesId,
                        principalTable: "ModelCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartPartTree",
                columns: table => new
                {
                    PartTreesId = table.Column<int>(type: "int", nullable: false),
                    PartsCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartPartTree", x => new { x.PartTreesId, x.PartsCode });
                    table.ForeignKey(
                        name: "FK_PartPartTree_Parts_PartsCode",
                        column: x => x.PartsCode,
                        principalTable: "Parts",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartPartTree_PartTrees_PartTreesId",
                        column: x => x.PartTreesId,
                        principalTable: "PartTrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartTreeScheme",
                columns: table => new
                {
                    PartTreesId = table.Column<int>(type: "int", nullable: false),
                    SchemesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTreeScheme", x => new { x.PartTreesId, x.SchemesId });
                    table.ForeignKey(
                        name: "FK_PartTreeScheme_PartTrees_PartTreesId",
                        column: x => x.PartTreesId,
                        principalTable: "PartTrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartTreeScheme_Schemes_SchemesId",
                        column: x => x.SchemesId,
                        principalTable: "Schemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schemes_PartSubgroupId",
                table: "Schemes",
                column: "PartSubgroupId");

            migrationBuilder.CreateIndex(
                name: "IX_KitModelCode_KitsId",
                table: "KitModelCode",
                column: "KitsId");

            migrationBuilder.CreateIndex(
                name: "IX_PartPartTree_PartsCode",
                table: "PartPartTree",
                column: "PartsCode");

            migrationBuilder.CreateIndex(
                name: "IX_PartTreeScheme_SchemesId",
                table: "PartTreeScheme",
                column: "SchemesId");
        }
    }
}
