using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class EditingEFModelsForOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcersizeMetas_WorkoutSessions_WorkoutSessionId",
                table: "ExcersizeMetas");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutWeeks_WorkoutId",
                table: "WorkoutSessions",
                column: "WorkoutId",
                principalTable: "WorkoutWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcersizeMetas_WorkoutSessions_WorkoutId",
                table: "ExcersizeMetas");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutWeeks_WorkoutWeekId",
                table: "WorkoutSessions",
                column: "WorkoutWeekId",
                principalTable: "WorkoutWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
