using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class AddingisCompleteBooleanToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCompletedWorkoutWeek",
                table: "WorkoutWeeks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isCompletedWorkoutSession",
                table: "WorkoutSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isCompletedWorkoutPlan",
                table: "WorkoutPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isCompletedExcersizeMeta",
                table: "ExcersizeMetas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompletedWorkoutWeek",
                table: "WorkoutWeeks");

            migrationBuilder.DropColumn(
                name: "isCompletedWorkoutSession",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "isCompletedWorkoutPlan",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "isCompletedExcersizeMeta",
                table: "ExcersizeMetas");
        }
    }
}
