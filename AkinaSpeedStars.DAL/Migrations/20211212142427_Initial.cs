using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkinaSpeedStars.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsATM = table.Column<bool>(type: "bit", nullable: false),
                    GearShiftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDriverPositionLeft = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<int>(type: "int", nullable: false),
                    AdditionalDestination = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ProductionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PartTrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelCodes_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitPartGroup",
                columns: table => new
                {
                    KitsId = table.Column<int>(type: "int", nullable: false),
                    PartGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitPartGroup", x => new { x.KitsId, x.PartGroupsId });
                    table.ForeignKey(
                        name: "FK_KitPartGroup_Kits_KitsId",
                        column: x => x.KitsId,
                        principalTable: "Kits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitPartGroup_PartGroups_PartGroupsId",
                        column: x => x.PartGroupsId,
                        principalTable: "PartGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartSubgroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSubgroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartSubgroups_PartGroups_PartGroupId",
                        column: x => x.PartGroupId,
                        principalTable: "PartGroups",
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
                name: "Schemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartSubgroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schemes_PartSubgroups_PartSubgroupId",
                        column: x => x.PartSubgroupId,
                        principalTable: "PartSubgroups",
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
                name: "IX_KitModelCode_KitsId",
                table: "KitModelCode",
                column: "KitsId");

            migrationBuilder.CreateIndex(
                name: "IX_KitPartGroup_PartGroupsId",
                table: "KitPartGroup",
                column: "PartGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCodes_CarId",
                table: "ModelCodes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_PartPartTree_PartsCode",
                table: "PartPartTree",
                column: "PartsCode");

            migrationBuilder.CreateIndex(
                name: "IX_PartSubgroups_PartGroupId",
                table: "PartSubgroups",
                column: "PartGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PartTreeScheme_SchemesId",
                table: "PartTreeScheme",
                column: "SchemesId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemes_PartSubgroupId",
                table: "Schemes",
                column: "PartSubgroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitModelCode");

            migrationBuilder.DropTable(
                name: "KitPartGroup");

            migrationBuilder.DropTable(
                name: "PartPartTree");

            migrationBuilder.DropTable(
                name: "PartTreeScheme");

            migrationBuilder.DropTable(
                name: "ModelCodes");

            migrationBuilder.DropTable(
                name: "Kits");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "PartTrees");

            migrationBuilder.DropTable(
                name: "Schemes");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "PartSubgroups");

            migrationBuilder.DropTable(
                name: "PartGroups");
        }
    }
}
