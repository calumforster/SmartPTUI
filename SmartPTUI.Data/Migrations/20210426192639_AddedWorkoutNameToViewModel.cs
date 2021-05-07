using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class AddedWorkoutNameToViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkoutName",
                table: "WorkoutQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutName",
                table: "WorkoutQuestions");
        }
    }
}
