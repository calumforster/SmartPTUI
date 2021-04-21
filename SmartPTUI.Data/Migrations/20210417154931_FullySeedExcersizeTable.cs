using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartPTUI.Migrations
{
    public partial class FullySeedExcersizeTable : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var SeedExcersize = new List<Tuple<int, string, string, int>>();
            SeedExcersize.Add(Tuple.Create(4, "Barbell Bench Press", "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.", 0));

            //Chest
            SeedExcersize.Add(Tuple.Create(4, "Bench Press", "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Chest Flys", "The dumbbell chest fly is an upper body exercise that can help to strengthen the chest and shoulders", 0));
            SeedExcersize.Add(Tuple.Create(8, "Peck Deck", "A pec deck is a machine designed to increase strength and muscle mass in the chest", 0));
            SeedExcersize.Add(Tuple.Create(4, "Push ups", "Traditional pushups are beneficial for building upper body strength. They work the triceps, pectoral muscles, and shoulders.", 0));
            SeedExcersize.Add(Tuple.Create(4, "Inclined dumbbell flies", "The incline dumbbell fly is an isolated strength exercise that targets the upper chest muscle.", 0));


            //Back
            SeedExcersize.Add(Tuple.Create(8, "Deadlift", "Deadlifting can increase core strength, core stability and improve your posture. Deadlifting trains most of the muscles in the legs, lower back and core", 1));
            SeedExcersize.Add(Tuple.Create(10, "Bent Over Row", "A bent-over row (or barbell row) is a weight training exercise that targets a variety of back muscles", 1));
            SeedExcersize.Add(Tuple.Create(4, "Lat Pulldown", "The pulldown exercise works the back muscles, especially the latissimus dorsi or the lats.", 1));
            SeedExcersize.Add(Tuple.Create(6, "Pull Up", "A pullup is a challenging upper body exercise where you grip an overhead bar and lift your body until your chin is above that bar.", 1));
            SeedExcersize.Add(Tuple.Create(6, "Seated Cable Row", "The seated cable row is a pulling exercise that works the back muscles in general, particularly the latissimus dorsi.", 1));

            //Shoulders

            SeedExcersize.Add(Tuple.Create(8, "Overhead Press", "A barbell overhead shoulder press (aka barbell standing shoulder press) works not just your shoulders, but most of your body. ", 2));
            SeedExcersize.Add(Tuple.Create(6, "Seated Dumbbell Shoulder Press", "A proper deltoid workout simply isn’t complete without the seated dumbbell shoulder press. ", 2));
            SeedExcersize.Add(Tuple.Create(8, "Dumbbell Lateral Raise", "This wildly effective shoulder exercise targets your middle deltoids, though it also builds upon your overall physique.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Barbell Shrugs", "Save this neck and shoulder exercise for the end of your overall routine. Keeping your feet even with your shoulders, bend your knees and pick up the barbell, bringing it to waist level.", 2));
            SeedExcersize.Add(Tuple.Create(6, "Pec Deck Rear Fly", "This really isolates the rear of your deltoids, so you won’t need to go too heavy here.", 2));



            //Legs

            SeedExcersize.Add(Tuple.Create(8, "Barbell Squat", "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Glute Bridge", "Lie face up on the floor, with your knees bent and feet flat on the ground. Lift your hips off the ground until your knees, hips and shoulders form a straight line.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Leg Curl", "Performed on the Leg Curl Machine", 3));
            SeedExcersize.Add(Tuple.Create(4, "Leg Extension", "Performed on the Leg extension machine", 3));
            SeedExcersize.Add(Tuple.Create(6, "Leg Press", "Performed on the leg press machine", 3));



            foreach (var excersize in SeedExcersize) 
            {
                migrationBuilder.InsertData(
                    table: "ExcersizeStore",
                    columns: new[] { "TimePerRep", "WorkoutName", "WorkoutDescription", "CoreArea" },
                    values: new object[]
                    {
                        excersize.Item1 ,
                        excersize.Item2,
                        excersize.Item3,
                        excersize.Item4});
            }




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
