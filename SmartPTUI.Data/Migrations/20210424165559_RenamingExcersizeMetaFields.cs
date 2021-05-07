using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class RenamingExcersizeMetaFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightGoalAchieved",
                table: "ExcersizeMetas",
                newName: "WeightAchieved");

            migrationBuilder.RenameColumn(
                name: "RepsGoalAchieved",
                table: "ExcersizeMetas",
                newName: "RepsAchieved");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightAchieved",
                table: "ExcersizeMetas",
                newName: "WeightGoalAchieved");

            migrationBuilder.RenameColumn(
                name: "RepsAchieved",
                table: "ExcersizeMetas",
                newName: "RepsGoalAchieved");
        }
    }
}
