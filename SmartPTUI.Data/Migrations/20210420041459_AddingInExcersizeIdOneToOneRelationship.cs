using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class AddingInExcersizeIdOneToOneRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcersizeMetas_ExcersizeStore_ExcersizeTypeId",
                table: "ExcersizeMetas");

            migrationBuilder.DropIndex(
                name: "IX_ExcersizeMetas_ExcersizeTypeId",
                table: "ExcersizeMetas");

            migrationBuilder.DropColumn(
                name: "ExcersizeTypeId",
                table: "ExcersizeMetas");

            migrationBuilder.AddColumn<int>(
                name: "ExcersizeId",
                table: "ExcersizeMetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExcersizeMetas_ExcersizeId",
                table: "ExcersizeMetas",
                column: "ExcersizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcersizeMetas_ExcersizeStore_ExcersizeId",
                table: "ExcersizeMetas",
                column: "ExcersizeId",
                principalTable: "ExcersizeStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcersizeMetas_ExcersizeStore_ExcersizeId",
                table: "ExcersizeMetas");

            migrationBuilder.DropIndex(
                name: "IX_ExcersizeMetas_ExcersizeId",
                table: "ExcersizeMetas");

            migrationBuilder.DropColumn(
                name: "ExcersizeId",
                table: "ExcersizeMetas");

            migrationBuilder.AddColumn<int>(
                name: "ExcersizeTypeId",
                table: "ExcersizeMetas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExcersizeMetas_ExcersizeTypeId",
                table: "ExcersizeMetas",
                column: "ExcersizeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcersizeMetas_ExcersizeStore_ExcersizeTypeId",
                table: "ExcersizeMetas",
                column: "ExcersizeTypeId",
                principalTable: "ExcersizeStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
