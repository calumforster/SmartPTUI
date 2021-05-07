using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class ChangingModelIdNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcersizeMetas_WorkoutSessions_WorkoutId",
                table: "ExcersizeMetas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkoutWeeks",
                newName: "WorkoutWeekId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkoutSessions",
                newName: "WorkoutSessionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkoutPlans",
                newName: "WorkoutPlanId");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "ExcersizeMetas",
                newName: "WorkoutSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExcersizeMetas_WorkoutId",
                table: "ExcersizeMetas",
                newName: "IX_ExcersizeMetas_WorkoutSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcersizeMetas_WorkoutSessions_WorkoutSessionId",
                table: "ExcersizeMetas",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "WorkoutSessionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcersizeMetas_WorkoutSessions_WorkoutSessionId",
                table: "ExcersizeMetas");

            migrationBuilder.RenameColumn(
                name: "WorkoutWeekId",
                table: "WorkoutWeeks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WorkoutSessionId",
                table: "WorkoutSessions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WorkoutPlanId",
                table: "WorkoutPlans",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WorkoutSessionId",
                table: "ExcersizeMetas",
                newName: "WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_ExcersizeMetas_WorkoutSessionId",
                table: "ExcersizeMetas",
                newName: "IX_ExcersizeMetas_WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcersizeMetas_WorkoutSessions_WorkoutId",
                table: "ExcersizeMetas",
                column: "WorkoutId",
                principalTable: "WorkoutSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
