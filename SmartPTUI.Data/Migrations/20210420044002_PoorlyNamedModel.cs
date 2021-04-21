using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class PoorlyNamedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_WorkoutWeeks_WorkoutId",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "WorkoutSessions",
                newName: "WorkoutWeekId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSessions_WorkoutId",
                table: "WorkoutSessions",
                newName: "IX_WorkoutSessions_WorkoutWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutWeeks_WorkoutWeekId",
                table: "WorkoutSessions",
                column: "WorkoutWeekId",
                principalTable: "WorkoutWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_WorkoutWeeks_WorkoutWeekId",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "WorkoutWeekId",
                table: "WorkoutSessions",
                newName: "WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutSessions_WorkoutWeekId",
                table: "WorkoutSessions",
                newName: "IX_WorkoutSessions_WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutWeeks_WorkoutId",
                table: "WorkoutSessions",
                column: "WorkoutId",
                principalTable: "WorkoutWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
