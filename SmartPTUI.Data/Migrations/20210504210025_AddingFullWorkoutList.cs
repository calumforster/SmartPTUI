using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartPTUI.Migrations
{
    public partial class AddingFullWorkoutList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var SeedExcersize = new List<Tuple<int, string, string, int>>();
            SeedExcersize.Add(Tuple.Create(4, "Barbell Bench Press", "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.", 0));

            SeedExcersize.Add(Tuple.Create(4, "Bench Press", "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Chest Flys", "The dumbbell chest fly is an upper body exercise that can help to strengthen the chest and shoulders", 0));
            SeedExcersize.Add(Tuple.Create(8, "Peck Deck", "A pec deck is a machine designed to increase strength and muscle mass in the chest", 0));
            SeedExcersize.Add(Tuple.Create(4, "Push ups", "Traditional pushups are beneficial for building upper body strength. They work the triceps, pectoral muscles, and shoulders.", 0));
            SeedExcersize.Add(Tuple.Create(4, "Inclined dumbbell flies", "The incline dumbbell fly is an isolated strength exercise that targets the upper chest muscle.", 0));
            SeedExcersize.Add(Tuple.Create(4, "Dumbbell Bench Press", "Lie back on a flat bench with a dumbbell in each hand. Hold the weights at shoulder-level, then press the weights straight up.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Cable Crossover", "Stand between two facing cable stations with both pulleys set midway between the top and bottom of the station. Pull the cables towards each other", 0));
            SeedExcersize.Add(Tuple.Create(4, "Incline Dumbbell Press", "Set an adjustable bench to a 30-45 degree angle and lie back on it with a dumbbell in each hand at shoulder-level. Press the weights over your chest.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Chest Press Machine", "Load plates on both sides of a flat-press machine, and adjust the seat so that both of your feet are flat on the floor. Grasp the handles and press to a full lockout.", 0));
            SeedExcersize.Add(Tuple.Create(4, "Dumbbell Flye", "Lie back on a flat bench with a dumbbell in each hand. Keep a slight bend in your elbows and spread your arms wide, lowering the weights until they’re even with your chest. Flex your pecs and lift the weights back to the starting position.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Landmine Press", "Wedge the end of the barbell into a corner of the room (to avoid damage to the walls, you may have to wrap a towel around it). Load the opposite end with weight and grasp it toward the end of the barbell sleeve with your right hand. Stagger your stance so your left leg is in front. Press the bar straight overhead.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Medicine Ball Pushup", "Place both hands on the ball and get into pushup position. Quickly let go of the ball and spread your hands out to shoulder width on the floor. When you feel your chest touch the ball, push yourself up fast so your hands come off the floor and land on the ball again.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Close-Grip Pushup", "Perform these as you would normal pushups, but position your hands close together. The closer together your hands are, the more this exercise emphasizes the triceps.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Triceps Extension", "Start in pushup position, then rest your forearms on the floor with palms down. Keeping your core tight and your body in a straight line, extend your elbows so your arms are straight.", 0));
            SeedExcersize.Add(Tuple.Create(6, "Barbell floor press", "The barbell floor bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on the floor", 0));
            SeedExcersize.Add(Tuple.Create(8, "Decline dumbbell press", "Hold a dumbbell in each hand, shoulder-width apart and overhand grip. Lie back on a decline bench and extend your arms straight above you. Lower the weights slowly until they reach your chest, then push the dumbbells back to starting position.", 0));
            SeedExcersize.Add(Tuple.Create(4, "Weighted Push ups", "Weighted pushups are beneficial for building upper body strength. They work the triceps, pectoral muscles, and shoulders.", 0));
            SeedExcersize.Add(Tuple.Create(8, "Smith Machine Bench Press", "Keep the form the same as the barbell bench press", 0));
            SeedExcersize.Add(Tuple.Create(6, "Butterfly Machine", "The pushing force should come from the elbows not the hands", 0));
            SeedExcersize.Add(Tuple.Create(4, "Wide Pushup", "Wide pushups are beneficial for building upper body strength. They work the triceps, pectoral muscles, and shoulders.", 0));

            SeedExcersize.Add(Tuple.Create(8, "Deadlift", "Deadlifting can increase core strength, core stability and improve your posture. Deadlifting trains most of the muscles in the legs, lower back and core", 1));
            SeedExcersize.Add(Tuple.Create(10, "Bent Over Row", "A bent-over row (or barbell row) is a weight training exercise that targets a variety of back muscles", 1));
            SeedExcersize.Add(Tuple.Create(4, "Lat Pulldown", "The pulldown exercise works the back muscles, especially the latissimus dorsi or the lats.", 1));
            SeedExcersize.Add(Tuple.Create(6, "Pull Up", "A pullup is a challenging upper body exercise where you grip an overhead bar and lift your body until your chin is above that bar.", 1));
            SeedExcersize.Add(Tuple.Create(6, "Seated Cable Row", "The seated cable row is a pulling exercise that works the back muscles in general, particularly the latissimus dorsi.", 1));
            SeedExcersize.Add(Tuple.Create(6, "Resistance band pull apart", "Stand with your arms extended. Hold a resistance band taut in front of you with both hands so the band is parallel to the ground. Pull Apart", 1));
            SeedExcersize.Add(Tuple.Create(4, "Quadruped dumbbell row", "Get on all fours with a dumbbell positioned in each hand. Ensure your back is straight, hands are directly below shoulders, and knees are directly below hips.", 1));
            SeedExcersize.Add(Tuple.Create(4, "Lat pulldown - Cable", "You can complete a lat pulldown on a machine at the gym or with a resistance band. ", 1));
            SeedExcersize.Add(Tuple.Create(4, "Wide dumbbell row", "Hold a dumbbell in each hand and hinge at the waist, stopping when your upper body forms a 20-degree angle with the ground. ", 1));
            SeedExcersize.Add(Tuple.Create(4, "Single-arm dumbbell row", "Position yourself on a bench so your left knee and shin are resting on it, as well as your left hand — this will be your support, pull dumbell up", 1));
            SeedExcersize.Add(Tuple.Create(6, "TRX row", "Grab hold of the TRX handles and walk under them, lean back and pull body up", 1));
            SeedExcersize.Add(Tuple.Create(4, "Superman", "Lie on your stomach with your arms extended over your head. Pull up medicen ball above your head", 1));
            SeedExcersize.Add(Tuple.Create(6, "Reverse fly", "Holding a dumbbell in each hand, hinge forward at the waist until your torso forms a 45-degree angle with the ground, pull arms backwards", 1));
            SeedExcersize.Add(Tuple.Create(4, "Assisted Pull up", "Stand underneath a pullup bar and grab it with an overhand grip, placing your hands wider than shoulder-width apart with assisted machine", 1));
            SeedExcersize.Add(Tuple.Create(4, "Plank", "Get into a plank position with your elbows and forearms on the ground and legs extended, supporting your weight on your toes and forearms.", 1));
            SeedExcersize.Add(Tuple.Create(4, "Inverted Row", "Place a bar at about hip height on a Smith machine or power rack. Lower yourself to the ground underneath the bar, grabbing it and pulling up", 1));
            SeedExcersize.Add(Tuple.Create(4, "Chin Ups", "Pull up with your chin past the bar", 1));
            SeedExcersize.Add(Tuple.Create(6, "Chest Supported Row", "You perform a chest supported row by lying facedown on an incline bench and rowing a pair of dumbbells", 1));
            SeedExcersize.Add(Tuple.Create(6, "Pendlay Row", "Bend over and grab the bar with a slightly wider than shoulder-width grip with your palms facing toward you. Straighten your back and raise your hips until your back is roughly parallel to the floor. ", 1));
            SeedExcersize.Add(Tuple.Create(6, "T-Bar Row", "Place one end of an empty barbell in the corner of a room or rack, or into a landmine attachment, and load the other end with weight plates. Straddle the barbell and hook a close-grip attachment from a cable pulley machine under the weighted end of the barbell. ", 1));

            SeedExcersize.Add(Tuple.Create(8, "Overhead Press", "A barbell overhead shoulder press (aka barbell standing shoulder press) works not just your shoulders, but most of your body. ", 2));
            SeedExcersize.Add(Tuple.Create(6, "Seated Dumbbell Shoulder Press", "A proper deltoid workout simply isn’t complete without the seated dumbbell shoulder press. ", 2));
            SeedExcersize.Add(Tuple.Create(8, "Dumbbell Lateral Raise", "This wildly effective shoulder exercise targets your middle deltoids, though it also builds upon your overall physique.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Barbell Shrugs", "Save this neck and shoulder exercise for the end of your overall routine. Keeping your feet even with your shoulders, bend your knees and pick up the barbell, bringing it to waist level.", 2));
            SeedExcersize.Add(Tuple.Create(6, "Pec Deck Rear Fly", "This really isolates the rear of your deltoids, so you won’t need to go too heavy here.", 2));
            SeedExcersize.Add(Tuple.Create(6, "Standing Dumbbell Fly", "Hold a dumbbell in each hand by your sides. Without shrugging, use your upper body to swing the weights up a few inches.", 2));
            SeedExcersize.Add(Tuple.Create(6, "Face Pull", "Attach a rope handle to the top pulley of a cable station. Grasp an end in each hand with palms facing each other. Step back to place tension on the cable. Pull the handles to your forehead so your palms face your ears and your upper back is fully contracted.", 2));
            SeedExcersize.Add(Tuple.Create(4, "High Pull", "Grasp the bar with hands about double shoulder width and hold it in front of your thighs. Bend your knees and hips so the bar hangs just above your knees. Explosively extend your hips as if jumping and pull the bar up to shoulder level with elbows wide apart, as in an upright row.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Seated Dumbbell Clean", "Hold a dumbbell in each hand and sit on the edge of a bench. Keeping your lower back flat, lean forward. Explosively straighten your body and shrug the weights so your arms rise", 2));
            SeedExcersize.Add(Tuple.Create(6, "Trap Raise", "Set a bench to a low incline and lie chest-down with a dumbbell in each hand and your palms facing. Retract your shoulder blades, then raise the weights straight out so your arms are parallel to the floor.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Clean and Press", "Stand with feet shoulder width. Keeping your lower back arched, bend your hips back to lower your torso and grasp the bar with hands shoulder width. Extend your hips to lift the bar off the floor. When it gets past your knees, jump and shrug the bar so that momentum raises it and you catch it at shoulder level.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Band Lateral Raise", "Step on the free end of each band with the opposite foot so the bands form an X in front of your body. Raise your arms 90 degrees out to the sides until your upper arms are parallel to the floor.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Hindu Pushup", "Get into pushup position. Push your hands into the floor to drive your weight back so your hips rise into the air. Your back should be straight and your head behind your hands. Lower your body in an arcing motion so that your chest scoops downward and nearly scrapes the floor", 2));
            SeedExcersize.Add(Tuple.Create(4, "Pike Press", "Get into pushup position and push your hips back so your torso is nearly vertical. Your hands, arms, and head should be in a straight line. Lower your body until your head nearly touches the floor between your hands and then press back up.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Dip", "Rest the palms of your hands on a bench or chair, and, if available, place your heels on another elevated object in front of you so your legs are suspended. Lower your body until your upper arms are parallel to the floor.", 2));
            SeedExcersize.Add(Tuple.Create(2, "Snatch-Grip Low Pull", "Set up as you did for the high pull, but when you jump, perform an explosive shrug and bend your elbows to pull the bar into your belly. Do not continue to lift the bar up to chest level.", 2));
            SeedExcersize.Add(Tuple.Create(10, "Farmer's Walk", "Pick up the heaviest set of dumbbells you can handle and walk. Squeeze the handles hard and walk with your chest out and shoulders back. If you don’t have the space to walk in a straight line, walk in a figure-eight pattern.", 2));
            SeedExcersize.Add(Tuple.Create(4, "Dumbbell Bent-Over Lateral Raise", "Hold a dumbbell in each hand and, keeping your lower back in its natural arch, bend your hips back until your torso is about parallel to the floor. Allow your arms to hang. Now squeeze your shoulder blades together and raise your arms out 90 degrees, with thumbs pointing up, until your upper arms are parallel to the floor.", 2));
            SeedExcersize.Add(Tuple.Create(6, "Machine Shoulder Press", "Grasp the handles so your palms face each other. Push Up", 2));
            SeedExcersize.Add(Tuple.Create(4, "Front Raise", "Hold weight, retract your shoulder blades and keep your arms straight as you lift the weight to shoulder level.", 2));

            SeedExcersize.Add(Tuple.Create(8, "Barbell Back Squat", "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Glute Bridge", "Lie face up on the floor, with your knees bent and feet flat on the ground. Lift your hips off the ground until your knees, hips and shoulders form a straight line.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Leg Curl", "Performed on the Leg Curl Machine", 3));
            SeedExcersize.Add(Tuple.Create(4, "Leg Extension", "Performed on the Leg extension machine", 3));
            SeedExcersize.Add(Tuple.Create(6, "Leg Press", "Performed on the leg press machine", 3));
            SeedExcersize.Add(Tuple.Create(6, "Front Squat", "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up.", 3));
            SeedExcersize.Add(Tuple.Create(8, "Romanian Deadlift", "Hold the bar at hip level with your palms facing down. Push your rear back and lower the bar, keeping your head up and forward with your shoulders back.When the bar reaches just below the knee, you’ll feel your hamstrings preventing you from going further.Drive the hips forward to stand tall again.", 3));
            SeedExcersize.Add(Tuple.Create(6, "Dumbbell Lunge", "Grip dumbbells in each hand. Lunge one foot forward and squat into it, so your trail leg lowers until your knee is just about to touch the floor. Step through with your trail leg so that it goes in front of your lead, and repeat the action.", 3));
            SeedExcersize.Add(Tuple.Create(2, "Standing Calf Raises", "Stand on the edge of something with the balls of your feet. Raise your heels up and then drop back down. Do this in a calf raise machine, or with the weight on your shoulders.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Zercher Squat", "Grip a barbell in the crook of your elbows on your upper forearms, wrap your hands in front of the bar to stop it falling forward and perform a squat as normal.", 3));
            SeedExcersize.Add(Tuple.Create(2, "Box Jumps", "Find a box that is roughly waist height. Stand with your feet shoulder width apart, squat down slightly and explode upwards, aiming to land with your feet firmly planted.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Barbell Bulgarian Split Squat", "Stand facing away from the bench, holding a barbell across your upper back. Have one leg resting on the bench behind you, laces down. Squat", 3));
            SeedExcersize.Add(Tuple.Create(2, "Seated Dumbbell Calf Raise", "Put a weight plate on the floor and rest your toes on it whilst sitting on a bench.Place a dumbbell on your knee, your right hand holding the handle whilst your left hand holds the top. Push", 3));
            SeedExcersize.Add(Tuple.Create(4, "Goblet Squat", "Stand with your legs wider than your shoulders and hold a dumbbell with both hands in line with your thighs. Squat", 3));
            SeedExcersize.Add(Tuple.Create(4, "Barbell Side Lunge", "Stand with your legs under your hips and hold a barbell on your back. Step your right leg out to the side and lower your body as you bend your knee, keeping your left leg straight.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Kettlebell Pistol Squat", "Hold one kettlebell with both hands just under your chin. Lift one leg off the floor and squat down with the other.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Single Leg Curl", "Lie face down on the leg curl machine with your heels against the lower pad and the bench against your thighs. Bend one knee to pull the pad up towards your backside as far as possible.", 3));
            SeedExcersize.Add(Tuple.Create(4, "Single Leg Deadlift", "Slowly lift one leg straight behind you, bending the other slightly, and lean forward so that your arms lower the dumbbells towards the floor. Pause, then return to upright position.", 3));
            SeedExcersize.Add(Tuple.Create(6, "Sumo Squat", "Stand with your feet wider than shoulder-width apart holding a barbell across your upper back with an overhand grip. Squat", 3));
            SeedExcersize.Add(Tuple.Create(4, "Hack Squat", "Stand with your feet shoulder width apart and hold a barbell behind you at arms’ length. Squat.", 3));




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
