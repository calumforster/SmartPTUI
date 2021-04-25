using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class AddingWorkoutFeedbackToExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_WorkoutFeedbacks_FeedbackId",
                table: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "WorkoutFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_FeedbackId",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "WorkoutSessions");

            migrationBuilder.AddColumn<int>(
                name: "ExcersizeFeedbackRating",
                table: "ExcersizeMetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FurtherNotes",
                table: "ExcersizeMetas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcersizeFeedbackRating",
                table: "ExcersizeMetas");

            migrationBuilder.DropColumn(
                name: "FurtherNotes",
                table: "ExcersizeMetas");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "WorkoutSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkoutFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_FeedbackId",
                table: "WorkoutSessions",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutFeedbacks_FeedbackId",
                table: "WorkoutSessions",
                column: "FeedbackId",
                principalTable: "WorkoutFeedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
