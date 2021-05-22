using AutoMapper;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
using SmartPTUI.Data.Enums.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPTUI.Business.Transactions
{
    public class WorkoutTransaction : IWorkoutTransaction
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExcersizeRepository _excersizeRepository;
        private readonly IMapper _mapper;

        private static readonly int oneRepMaximumCoEfficient = 75;

        public WorkoutTransaction(IWorkoutRepository workoutRepository, IMapper mapper, IExcersizeRepository excersizeRepository)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
            _excersizeRepository = excersizeRepository;
        }

        public async Task<int> CreateWorkout(QuestionnaireViewModel questionResults)
        {
            //Object instantiation
            var Workout = new WorkoutPlan();


            Workout.Customer = _mapper.Map<CustomerViewModel, Customer>(questionResults.Customer);
            Workout.WorkoutQuestion = questionResults.WorkoutQuestion;
            Workout.WorkoutWeek = new List<WorkoutWeek>();
            var excersizeList = new List<List<Excersize>>();

            for (int x = 0; x < questionResults.WorkoutQuestion.NumberOfWeeks; x++)
            {
                //Adds a workout week based on answers on workout form
                Workout.WorkoutWeek.Add(new WorkoutWeek()
                {
                    StartWeight = questionResults.WorkoutQuestion.StartWeight.Value,
                    EndWeight = questionResults.WorkoutQuestion.StartWeight.Value - 1,
                    CaloriesConsumed = 0
                });



                Workout.WorkoutWeek[x].Workout = new List<WorkoutSession>();
                var excersizeCycle = 0;

                for (int i = 0; i < questionResults.WorkoutQuestion.DaysPerWeek; i++)
                {

                    //If it's the first week, cycle through exercise type and relevent workouts per day
                    if (x == 0)
                    {
                        WorkoutSession workoutSession = new WorkoutSession();
                        workoutSession.Excersizes = new List<ExcersizeMeta>();

                        //Get's the workout from the db based on what day it is 1-4, cycling round on the 3-7 days
                        excersizeList.Add(GenerateFinalExcersizeList(await _excersizeRepository.GetExcersizesWithWorkoutArea(excersizeCycle), questionResults.WorkoutQuestion.TimePerWorkout.Value));

                        var excersizeListOfExcersize = excersizeList[excersizeCycle];
                        for (int j = 0; j < excersizeListOfExcersize.Count; j++)
                        {
                            var excersize = excersizeListOfExcersize[j];
                            int excersizeId = excersize.Id;
                            
                            //Adds the exercise - limited by how many exercises per session user chose in form
                            workoutSession.Excersizes.Add(new ExcersizeMeta
                            {
                                WeightGoal = 0,
                                SetsGoal = 1,
                                RepsGoal = 10,
                                ExcersizeId = excersizeId,
                                ExcersizeFeedbackRating = 0
                            });

                            //Object instantiation

                            workoutSession.Excersizes[j].ExcersizeSet = new List<ExcersizeSet>();

                            //First week so set name is 10RM
                            workoutSession.Excersizes[j].ExcersizeSet.Add(new ExcersizeSet()
                            {
                                SetName = $"10 RM Max Set"
                            });
                        }

                        Workout.WorkoutWeek[0].Workout.Add(workoutSession);

                    }
                    else
                    {
                        //Same as on first week generation, yet clones previous week's structure for remaining ones

                        WorkoutSession workoutSessionFollowing = new WorkoutSession();
                        workoutSessionFollowing.Excersizes = new List<ExcersizeMeta>();

                        for (int h = 0; h < Workout.WorkoutWeek[0].Workout[i].Excersizes.Count; h++)
                        {
                            var excersizeB = Workout.WorkoutWeek[0].Workout[i].Excersizes[h];
                            int excersizeIdB = excersizeB.ExcersizeId;
                            workoutSessionFollowing.Excersizes.Add(new ExcersizeMeta
                            {
                                WeightGoal = 0,
                                SetsGoal = 1,
                                RepsGoal = 10,
                                ExcersizeId = excersizeIdB,
                                ExcersizeFeedbackRating = 0
                            });

                            workoutSessionFollowing.Excersizes[h].ExcersizeSet = new List<ExcersizeSet>();

                            workoutSessionFollowing.Excersizes[h].ExcersizeSet.Add(new ExcersizeSet()
                            {
                                SetName = $"10 RM Max Set"
                            });
                        }

                        Workout.WorkoutWeek[x].Workout.Add(workoutSessionFollowing);
                    }


                    //Cyclical workout type flag - see ExeciseType enum for values
                    if ((i > 0) && (i % 3 == 0))
                    {
                        excersizeCycle = excersizeCycle - 3;
                    }
                    else
                    {
                        excersizeCycle++;
                    }


                }
            }
            //Reverses list due to filo nature of list
            Workout.WorkoutWeek.Reverse();

            //Saves to database
            return await _workoutRepository.SaveInitialWorkout(Workout);

        }

        public async Task CalculateNextWorkoutWeek(int workoutPlanId)
        {
            var workoutPlan = await _workoutRepository.GetWorkoutPlan(workoutPlanId);

            //Checks to see if the 2nd week has been completed or not (as this calculation is different to first and remaining weeks
            if (!workoutPlan.WorkoutWeek[1].isCompletedWorkoutWeek)
            {
                await CalculateSecondWorkoutWeek(workoutPlan);
            }
            //Checks to make sure there are remaining uncomplete workout weeks
            else if (!workoutPlan.WorkoutWeek[workoutPlan.WorkoutWeek.Count - 1].isCompletedWorkoutWeek)
            {
                var workoutWeekList = workoutPlan.WorkoutWeek.ToList();

                int previousWeek = 0;
                int currentWeek = 0;


                //finds current index and previous weeks index
                for (int h = 1; h < workoutWeekList.Count; h++)
                {
                    if (workoutWeekList[h].isCompletedWorkoutWeek)
                    {
                        previousWeek = h;
                        currentWeek = h + 1;

                    }
                }

                var workoutWeek = workoutPlan.WorkoutWeek[currentWeek];
                var previousWorkoutWeek = workoutPlan.WorkoutWeek[previousWeek];

                //Itterates through workout sessions to adjust newly generated goals based on previous week
                for (int i = 0; i < workoutWeek.Workout.Count; i++)
                {
                    var workout = workoutWeek.Workout[i];
                    var prevWorkout = previousWorkoutWeek.Workout[i];
                    for (int j = 0; j < workout.Excersizes.Count; j++)
                    {
                        var excersize = workout.Excersizes[j];

                        var prevEx = prevWorkout.Excersizes[j];

                        var tempExcersize = await _workoutRepository.GetExcersizeMeta(excersize.ExcersizeMetaId);

                        var previousExcersizeMeta = await _workoutRepository.GetExcersizeMeta(prevEx.ExcersizeMetaId);

                        //Calculated avarage reps in reserve from previous week
                        int avarageRepsInReserve = 0;
                        foreach (var sets in previousExcersizeMeta.ExcersizeSet)
                        {
                            avarageRepsInReserve += sets.RepsInReserve;
                        }

                        avarageRepsInReserve = avarageRepsInReserve / previousExcersizeMeta.ExcersizeSet.Count;


                        var excersizeIncrease = CalculateFollowingWeekWeightRepsSets(previousExcersizeMeta.WeightGoal, previousExcersizeMeta.RepsGoal, previousExcersizeMeta.SetsGoal, avarageRepsInReserve, previousExcersizeMeta.ExcersizeFeedbackRating);


                        //Assigns updated data to excersize meta - before overwriting in the db
                        tempExcersize.ExcersizeId = previousExcersizeMeta.ExcersizeId;

                        tempExcersize.WeightGoal = excersizeIncrease.Item1;
                        tempExcersize.RepsGoal = excersizeIncrease.Item2;
                        tempExcersize.SetsGoal = excersizeIncrease.Item3;
                        tempExcersize.ExcersizeSet[0].SetName = "Set 1";

                        //Adds sets if required and saves to database
                        for (int z = 1; z < tempExcersize.SetsGoal; z++)
                        {

                            await _workoutRepository.SaveExcersizeSetWorkoutCalc(new ExcersizeSet
                            {
                                SetName = $"Set {z + 1}"
                            }, tempExcersize.ExcersizeMetaId);

                        }
                        await _workoutRepository.SaveExcersizeMetaRevised(tempExcersize);
                    }


                }

            }

        }

        private async Task CalculateSecondWorkoutWeek(WorkoutPlan workoutPlan)
        {
            //get's first and current week
            var workoutWeek = workoutPlan.WorkoutWeek[1];
            var previousWorkoutWeek = workoutPlan.WorkoutWeek[0];

            //itterates through workout session
            for (int i = 0; i < workoutWeek.Workout.Count; i++)
            {
                var workout = workoutWeek.Workout[i];
                var prevWorkout = previousWorkoutWeek.Workout[i];
                for (int j = 0; j < workout.Excersizes.Count; j++)
                {
                    var excersize = workout.Excersizes[j];

                    var prevEx = prevWorkout.Excersizes[j];

                    var tempExcersize = await _workoutRepository.GetExcersizeMeta(excersize.ExcersizeMetaId);



                    var previousExcersizeMeta = await _workoutRepository.GetExcersizeMeta(prevEx.ExcersizeMetaId);

                    var weightRepSetCalculation = SecondWeekWeightRepsSets(previousExcersizeMeta.ExcersizeSet[0].WeightAchieved, workoutPlan.WorkoutQuestion.Goal);


                    //assigns newly calculated data to excersize meta
                    tempExcersize.ExcersizeId = previousExcersizeMeta.ExcersizeId;

                    tempExcersize.WeightGoal = weightRepSetCalculation.Item1;
                    tempExcersize.RepsGoal = weightRepSetCalculation.Item2;
                    tempExcersize.SetsGoal = weightRepSetCalculation.Item3;
                    tempExcersize.ExcersizeSet[0].SetName = "Set 1";
                    tempExcersize.ExcersizeSet[0].RepsAchieved = 0;

                    //Adds in extra sets and saves to db
                    for (int z = 1; z < weightRepSetCalculation.Item3; z++)
                    {

                        await _workoutRepository.SaveExcersizeSetWorkoutCalc(new ExcersizeSet
                        {
                            SetName = $"Set {z + 1}"
                        }, tempExcersize.ExcersizeMetaId);

                    }
                    await _workoutRepository.SaveExcersizeMetaRevised(tempExcersize);
                }


            }

        }

        private Tuple<int, int, int> SecondWeekWeightRepsSets(int weight, Goals workoutGoal)
        {
            //depending on workout goal, different amount of reps, sets and weight added to workout

            if (workoutGoal == Goals.WeightGain)
            {
                double weightGainWeight = (double)CalculateOneRepMaximum(weight);
                double strenthPercent = 89;
                double actualWeight = (strenthPercent / 100) * weightGainWeight;

                return new Tuple<int, int, int>((int)actualWeight, 5, 3);
            }

            if (workoutGoal == Goals.WeightLoss)
            {
                double weighLossWeight = (double)CalculateOneRepMaximum(weight);
                double strenthPercent = 70;
                double actualWeight = (strenthPercent / 100) * weighLossWeight;

                return new Tuple<int, int, int>((int)actualWeight, 13, 2);
            }

            if (workoutGoal == Goals.Fitness)
            {
                double weightFitnessWeight = (double)CalculateOneRepMaximum(weight);
                double strenthPercent = 67;
                double actualWeight = (strenthPercent / 100) * weightFitnessWeight;

                return new Tuple<int, int, int>((int)actualWeight, 15, 3);
            }
            else return default;

        }

        private Tuple<int, int, int> CalculateFollowingWeekWeightRepsSets(int weight, int reps, int sets, int rIr, int feedbackRating)
        {

            //depending on feedback from previous week - weight, reps or sets are altered
            if (feedbackRating < 4)
            {
                return new Tuple<int, int, int>(weight, reps, sets);
            }

            if (rIr > 5 && feedbackRating > 7)
            {
                double weightIncreasePercent = weight / 10;
                weight += (int)Math.Round(weightIncreasePercent, 0);
                return new Tuple<int, int, int>(weight, reps, sets + 1);
            }

            if (rIr > 5 && feedbackRating > 5)
            {
                double weightIncreasePercent = weight / 10;
                weight += (int)Math.Round(weightIncreasePercent, 0);
                return new Tuple<int, int, int>(weight, reps, sets);
            }

            if (rIr > 2 && feedbackRating > 5)
            {
                return new Tuple<int, int, int>(weight, reps + 2, sets);
            }


            return new Tuple<int, int, int>(weight, reps + 1, sets);
        }

        private double CalculateOneRepMaximum(int weightAchieved)
        {
            return (weightAchieved * 100) / oneRepMaximumCoEfficient;
        }

        private List<Excersize> GenerateFinalExcersizeList(List<Excersize> excersizeList, int numberOfExcersizes)
        {

            var returnedExcersizeLift = new List<Excersize>();

            //uses LINQ query to find different difficulties of lift in the provided collection
            var compoundLift = excersizeList.Where(x => x.Difficulty == 1).FirstOrDefault();
            var secondaryLift = excersizeList.Where(x => x.Difficulty == 2).ToList();
            var tertiaryLift = excersizeList.Where(x => x.Difficulty == 3).ToList();

            Random ran = new Random();
            List<int> secondaryListNumbers = new List<int>();
            List<int> tertiaryListNumbers = new List<int>();

            //depending on amount of exercises different amounts of lifts are added - will always have one compound and 3 secondary lifts
            for (int i = 0; i < numberOfExcersizes; i++)
            {
                if (i < 1)
                {
                    returnedExcersizeLift.Add(compoundLift);
                }
                else if (i < 3)
                {
                    int seconrdaryNumber;
                    do
                    {
                        seconrdaryNumber = ran.Next(0, secondaryLift.Count);
                    } while (secondaryListNumbers.Contains(seconrdaryNumber));
                    secondaryListNumbers.Add(seconrdaryNumber);
                    returnedExcersizeLift.Add(secondaryLift[seconrdaryNumber]);
                }
                else if (i > 2)
                {

                    int tertiaryNumber;
                    do
                    {
                        tertiaryNumber = ran.Next(0, tertiaryLift.Count);
                    } while (tertiaryListNumbers.Contains(tertiaryNumber));
                    tertiaryListNumbers.Add(tertiaryNumber);
                    returnedExcersizeLift.Add(tertiaryLift[tertiaryNumber]);
                }
            }

            returnedExcersizeLift.Reverse();

            return returnedExcersizeLift;

        }

        public async Task<WorkoutPlan> GetWorkoutPlan(int id)
        {
            return await _workoutRepository.GetWorkoutPlan(id);
        }

        public async Task<List<WorkoutPlan>> GetWorkoutPlansForCustomer(int customerId)
        {
            return await _workoutRepository.GetWorkoutPlansForCustomer(customerId);
        }

        public async Task<WorkoutWeek> GetWorkoutWeek(int id)
        {
            return await _workoutRepository.GetWorkoutWeek(id);
        }

        public async Task<WorkoutSession> GetWorkoutSession(int id)
        {
            return await _workoutRepository.GetWorkoutSession(id);
        }

        public async Task<ExcersizeMeta> GetExcersizeMeta(int id)
        {
            return await _workoutRepository.GetExcersizeMeta(id);
        }

        public async Task SaveExcersizeMeta(ExcersizeMeta excersizeMeta)
        {
            await _workoutRepository.SaveExcersizeMeta(excersizeMeta);
        }

        public async Task SaveWorkoutSession(WorkoutSession workoutSession)
        {
            await _workoutRepository.SaveWorkoutSession(workoutSession);
        }

        public async Task SaveWorkoutWeek(WorkoutWeek workoutWeek)
        {
            await _workoutRepository.SaveWorkoutWeek(workoutWeek);
        }

        public async Task SaveWorkoutPlan(WorkoutPlan workoutPlan)
        {
            await _workoutRepository.SaveWorkoutPlan(workoutPlan);
        }
    }
}
