using AutoMapper;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
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
