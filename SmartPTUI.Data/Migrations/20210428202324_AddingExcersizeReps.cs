using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class AddingExcersizeReps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepsAchieved",
                table: "ExcersizeMetas");

            migrationBuilder.DropColumn(
                name: "SetsAchieved",
                table: "ExcersizeMetas");

            migrationBuilder.DropColumn(
                name: "WeightAchieved",
                table: "ExcersizeMetas");

            migrationBuilder.CreateTable(
                name: "ExcersizeSets",
                columns: table => new
                {
                    ExcersizeSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepsAchieved = table.Column<int>(type: "int", nullable: false),
                    WeightAchieved = table.Column<int>(type: "int", nullable: false),
                    RepsInReserve = table.Column<int>(type: "int", nullable: false),
                    ExcersizeMetaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcersizeSets", x => x.ExcersizeSetId);
                    table.ForeignKey(
                        name: "FK_ExcersizeSets_ExcersizeMetas_ExcersizeMetaId",
                        column: x => x.ExcersizeMetaId,
                        principalTable: "ExcersizeMetas",
                        principalColumn: "ExcersizeMetaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcersizeSets_ExcersizeMetaId",
                table: "ExcersizeSets",
                column: "ExcersizeMetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcersizeSets");

            migrationBuilder.AddColumn<int>(
                name: "RepsAchieved",
                table: "ExcersizeMetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SetsAchieved",
                table: "ExcersizeMetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightAchieved",
                table: "ExcersizeMetas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
