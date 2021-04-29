using AutoMapper;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
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

                    for (int j = 0; j < 1; j++) {
                        var excersize = await _excersizeRepository.GetExcersizeWithWorkoutArea(excersizeCycle);
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

                        for (int z = 0; z < 1; z++) {
                            workoutSession.Excersizes[j].ExcersizeSet.Add(new ExcersizeSet()
                            {
                                SetName = $"10 RM Max Set {z + 1}"
                            });

                        }
                    }


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
            }
            return await _workoutRepository.SaveInitialWorkout(Workout);
            
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
