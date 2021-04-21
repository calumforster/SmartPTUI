using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPTUI.Migrations
{
    public partial class SeedExcersizeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Sql("INSERT INTO MyNewTable(NyColumnName) Values('Test')");
            migrationBuilder.InsertData(
                table: "ExcersizeStore",
                columns: new[] { "TimePerRep" ,  "WorkoutName" , "WorkoutDescription" ,  "CoreArea" },
                values: new object[]
                {
                 4 ,
                "Barbell Bench Press",
                "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.",
                 0 
                }
                ) ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
