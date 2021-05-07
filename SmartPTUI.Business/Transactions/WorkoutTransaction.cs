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

            var Workout = new WorkoutPlan();


            Workout.Customer = _mapper.Map<CustomerViewModel, Customer>(questionResults.Customer);
            Workout.WorkoutQuestion = questionResults.WorkoutQuestion;
            Workout.WorkoutWeek = new List<WorkoutWeek>();
            var excersizeList = new List<List<Excersize>>();
            for (int x = 0; x < questionResults.WorkoutQuestion.NumberOfWeeks; x++) {

                Workout.WorkoutWeek.Add(new WorkoutWeek() {
                    StartWeight = questionResults.WorkoutQuestion.StartWeight.Value,
                    EndWeight = questionResults.WorkoutQuestion.StartWeight.Value - 1,
                    CaloriesConsumed = 0
                });



                Workout.WorkoutWeek[x].Workout = new List<WorkoutSession>();
                var excersizeCycle = 0;

                for (int i = 0; i < questionResults.WorkoutQuestion.DaysPerWeek; i++)
                {
                    WorkoutSession workoutSession = new WorkoutSession();
                    workoutSession.Excersizes = new List<ExcersizeMeta>();


                    if (x == 0) {
                        excersizeList.Add(GenerateFinalExcersizeList(await _excersizeRepository.GetExcersizesWithWorkoutArea(excersizeCycle), questionResults.WorkoutQuestion.TimePerWorkout.Value));
                    }
                   

                    Random ran = new Random();
                    var excersizeListOfExcersize = excersizeList[excersizeCycle];
                    for (int j = 0; j < excersizeListOfExcersize.Count; j++) {
                        var excersize = excersizeListOfExcersize[j];
                        int excersizeId = excersize.Id;
                        workoutSession.Excersizes.Add(new ExcersizeMeta
                        {
                            WeightGoal = 0,
                            SetsGoal = 1,
                            RepsGoal = 10,
                            ExcersizeId = excersizeId,
                            ExcersizeFeedbackRating = 0
                        });

                        workoutSession.Excersizes[j].ExcersizeSet = new List<ExcersizeSet>();
                                                                                                            
                            workoutSession.Excersizes[j].ExcersizeSet.Add(new ExcersizeSet()
                                {
                                    SetName = $"10 RM Max Set"
                                });
                    }

                    workoutSession.Excersizes.Reverse();


                    if ((i > 0) && (i % 3 == 0))
                    {
                        excersizeCycle = excersizeCycle - 3;
                    }
                    else
                    {
                        excersizeCycle++;
                    }

                    Workout.WorkoutWeek[x].Workout.Add(workoutSession);
                }
                Workout.WorkoutWeek[x].Workout.Reverse();
            }
            Workout.WorkoutWeek.Reverse();
            return await _workoutRepository.SaveInitialWorkout(Workout);
            
        }

        public async Task CalculateNextWorkoutWeek(int workoutPlanId)
        {
           var workoutPlan = await _workoutRepository.GetWorkoutPlan(workoutPlanId);

             if (!workoutPlan.WorkoutWeek[1].isCompletedWorkoutWeek)
            {
                await CalculateSecondWorkoutWeek(workoutPlan);
            }
             else if (!workoutPlan.WorkoutWeek[workoutPlan.WorkoutWeek.Count-1].isCompletedWorkoutWeek)
            {
                var workoutWeekList = workoutPlan.WorkoutWeek.ToList();

                int previousWeek = 0;
                int currentWeek = 0;

                for (int h = 1; h < workoutWeekList.Count; h++) {
                    if (workoutWeekList[h].isCompletedWorkoutWeek)
                    {
                        previousWeek = h;
                        currentWeek = h+1;

                    }                             
                }

                var workoutWeek = workoutPlan.WorkoutWeek[currentWeek];
                var previousWorkoutWeek = workoutPlan.WorkoutWeek[previousWeek];


                for (int i = 0; i < workoutWeek.Workout.Count; i++)
                {
                    var workout = workoutWeek.Workout[i];
                    var prevWorkout = previousWorkoutWeek.Workout[i];
                    for (int j = 0; j < workout.Excersizes.Count; j++)
                    {
                        var excersize = workout.Excersizes[j];

                        var tempExcersize = await _workoutRepository.GetExcersizeMeta(excersize.ExcersizeMetaId);

                        var prevExcersize = prevWorkout.Excersizes.Where(x => x.ExcersizeType.Id == tempExcersize.ExcersizeType.Id).FirstOrDefault();

                        var previousExcersizeMeta = await _workoutRepository.GetExcersizeMeta(prevExcersize.ExcersizeMetaId);

                        int avarageRepsInReserve = 0;
                        foreach (var sets in previousExcersizeMeta.ExcersizeSet)
                        {
                            avarageRepsInReserve += sets.RepsInReserve;                        
                        }

                        avarageRepsInReserve = avarageRepsInReserve / previousExcersizeMeta.ExcersizeSet.Count;

                        //Add in further workout edits
                       var excersizeIncrease = CalculateFollowingWeekWeightRepsSets(previousExcersizeMeta.WeightGoal, previousExcersizeMeta.RepsGoal, previousExcersizeMeta.SetsGoal, avarageRepsInReserve, previousExcersizeMeta.ExcersizeFeedbackRating);

                        tempExcersize.WeightGoal = excersizeIncrease.Item1;
                        tempExcersize.RepsGoal = excersizeIncrease.Item2;
                        tempExcersize.SetsGoal = excersizeIncrease.Item3;
                        tempExcersize.ExcersizeSet[0].SetName = "Set 1";
                        

                        for (int z = 1; z < tempExcersize.SetsGoal; z++)
                        {

                            await _workoutRepository.SaveExcersizeSetWorkoutCalc(new ExcersizeSet
                            {
                                SetName = $"Set {z + 1}"
                            }, tempExcersize.ExcersizeMetaId);

                        }
                        await _workoutRepository.SaveExcersizeMeta(tempExcersize);
                    }


                }

            }

        }

        private async Task CalculateSecondWorkoutWeek(WorkoutPlan workoutPlan)
        {
            var workoutWeek = workoutPlan.WorkoutWeek[1];
            var previousWorkoutWeek = workoutPlan.WorkoutWeek[0];


            for (int i = 0; i < workoutWeek.Workout.Count; i++)
            {
                var workout = workoutWeek.Workout[i];
                var prevWorkout = previousWorkoutWeek.Workout[i];
                for (int j = 0; j < workout.Excersizes.Count; j++) 
                {
                    var excersize = workout.Excersizes[j];
                    
                    var tempExcersize = await _workoutRepository.GetExcersizeMeta(excersize.ExcersizeMetaId);

                    var prevExcersize = prevWorkout.Excersizes.Where(x => x.ExcersizeType.Id == tempExcersize.ExcersizeType.Id).FirstOrDefault();

                    var previousExcersizeMeta = await _workoutRepository.GetExcersizeMeta(prevExcersize.ExcersizeMetaId);

                    var weightRepSetCalculation = SecondWeekWeightRepsSets(previousExcersizeMeta.ExcersizeSet[0].WeightAchieved,workoutPlan.WorkoutQuestion.Goal);

                    tempExcersize.WeightGoal = weightRepSetCalculation.Item1;
                    tempExcersize.RepsGoal = weightRepSetCalculation.Item2;
                    tempExcersize.SetsGoal = weightRepSetCalculation.Item3;
                    tempExcersize.ExcersizeSet[0].SetName = "Set 1";
                    tempExcersize.ExcersizeSet[0].RepsAchieved = 0;

                    for (int z = 1; z < weightRepSetCalculation.Item3; z++)
                    {

                       await _workoutRepository.SaveExcersizeSetWorkoutCalc(new ExcersizeSet
                        {
                            SetName = $"Set {z + 1}"
                        }, tempExcersize.ExcersizeMetaId);

                    }
                    await _workoutRepository.SaveExcersizeMeta(tempExcersize);
                }
            
            
            }

        }

        private Tuple<int, int, int> SecondWeekWeightRepsSets(int weight, Goals workoutGoal)
        {

            if (workoutGoal == Goals.WeightGain)
            {
                double weightGainWeight = (double) CalculateOneRepMaximum(weight);
                double strenthPercent = 89;
                double actualWeight = (strenthPercent / 100) * weightGainWeight;

                return new Tuple<int, int, int>((int) actualWeight,5,3);
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
            if (feedbackRating < 4)
            {
                return new Tuple<int, int, int>(weight,reps,sets);
            }

            if (rIr > 5 && feedbackRating > 7)
            {
                double weightIncreasePercent = weight / 10;
                weight += (int)Math.Round(weightIncreasePercent, 0);
                return new Tuple<int, int, int>(weight, reps, sets+1);
            }

            if (rIr > 5 && feedbackRating > 5)
            {
                double weightIncreasePercent = weight / 10;
                weight += (int) Math.Round(weightIncreasePercent, 0);
                return new Tuple<int, int, int>(weight, reps, sets);
            }

            if (rIr > 2 && feedbackRating >5) 
            {
                return new Tuple<int, int, int>(weight, reps+2, sets);
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

            var compoundLift = excersizeList.Where(x => x.Difficulty == 1).FirstOrDefault();
            var secondaryLift = excersizeList.Where(x => x.Difficulty == 2).ToList();
            var tertiaryLift = excersizeList.Where(x => x.Difficulty == 3).ToList();

            Random ran = new Random();
            List<int> secondaryListNumbers = new List<int>();
            List<int> tertiaryListNumbers = new List<int>();


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
                else if(i > 2){

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
