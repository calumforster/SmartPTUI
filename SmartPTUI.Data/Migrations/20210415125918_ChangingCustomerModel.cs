using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class ChangingCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a1633eb-e087-4cbe-a6c4-2df20f470f28", 0, "c53601bd-884e-48d5-a439-3e141589cec3", null, false, false, null, null, null, null, null, false, "c7dd5426-23fa-4ec5-965a-e2a5d92e3d1b", false, null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CurrentHealth", "DOB", "FirstName", "Gender", "Height", "LastName", "UserId" },
                values: new object[] { 20000, 2, new DateTime(2021, 4, 15, 13, 59, 17, 938, DateTimeKind.Local).AddTicks(7379), "Admin", 0, 170, "Test", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a1633eb-e087-4cbe-a6c4-2df20f470f28");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20000);
        }
    }
}
