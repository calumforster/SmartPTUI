using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class AddingPTTableAndLinkingCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalTrainerId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonalTrainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TitleColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgorundColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopBarColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WelcomeMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PersonalTrainerId",
                table: "Customers",
                column: "PersonalTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainer_UserId",
                table: "PersonalTrainer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PersonalTrainer_PersonalTrainerId",
                table: "Customers",
                column: "PersonalTrainerId",
                principalTable: "PersonalTrainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PersonalTrainer_PersonalTrainerId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "PersonalTrainer");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PersonalTrainerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonalTrainerId",
                table: "Customers");
        }
    }
}
