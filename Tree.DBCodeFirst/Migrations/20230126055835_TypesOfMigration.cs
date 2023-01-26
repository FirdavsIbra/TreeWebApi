using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tree.DBCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class TypesOfMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginingOfTheHarvestInY",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "HeightInMetre",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "Square",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Trees");

            migrationBuilder.AddColumn<long>(
                name: "TreeSortId",
                table: "Trees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TreeTypeId",
                table: "Trees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_TreeSorts_TreeTypeId",
                table: "TreeSorts",
                column: "TreeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeSorts");

            migrationBuilder.DropTable(
                name: "TreeTypes");

            migrationBuilder.DropColumn(
                name: "TreeSortId",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "TreeTypeId",
                table: "Trees");

            migrationBuilder.AddColumn<double>(
                name: "BeginingOfTheHarvestInY",
                table: "Trees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeightInMetre",
                table: "Trees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Trees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Square",
                table: "Trees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Trees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
