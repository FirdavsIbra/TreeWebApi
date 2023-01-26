using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tree.DBCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class migrationqissasi12323 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeSorts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeightInMetre = table.Column<double>(type: "float", nullable: false),
                    Square = table.Column<double>(type: "float", nullable: false),
                    BeginingOfTheHarvestInY = table.Column<double>(type: "float", nullable: false),
                    TreeTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeSorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeSorts_TreeTypes_TreeTypeId",
                        column: x => x.TreeTypeId,
                        principalTable: "TreeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreeSortId = table.Column<long>(type: "bigint", nullable: false),
                    PlotId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trees_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trees_TreeSorts_TreeSortId",
                        column: x => x.TreeSortId,
                        principalTable: "TreeSorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trees_PlotId",
                table: "Trees",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_TreeSortId",
                table: "Trees",
                column: "TreeSortId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeSorts_TreeTypeId",
                table: "TreeSorts",
                column: "TreeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "TreeSorts");

            migrationBuilder.DropTable(
                name: "TreeTypes");
        }
    }
}
