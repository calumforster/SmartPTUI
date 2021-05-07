using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class AddingGoalFieldsForExcersizeMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "ExcersizeMetas",
                newName: "WeightGoalAchieved");

            migrationBuilder.RenameColumn(
                name: "Sets",
                table: "ExcersizeMetas",
                newName: "WeightGoal");

            migrationBuilder.RenameColumn(
                name: "Reps",
                table: "ExcersizeMetas",
                newName: "SetsGoal");

            migrationBuilder.AddColumn<int>(
                name: "RepsGoal",
                table: "ExcersizeMetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepsGoalAchieved",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepsGoal",
                table: "ExcersizeMetas");

            migrationBuilder.DropColumn(
                name: "RepsGoalAchieved",
                table: "ExcersizeMetas");

            migrationBuilder.DropColumn(
                name: "SetsAchieved",
                table: "ExcersizeMetas");

            migrationBuilder.RenameColumn(
                name: "WeightGoalAchieved",
                table: "ExcersizeMetas",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "WeightGoal",
                table: "ExcersizeMetas",
                newName: "Sets");

            migrationBuilder.RenameColumn(
                name: "SetsGoal",
                table: "ExcersizeMetas",
                newName: "Reps");
        }
    }
}
