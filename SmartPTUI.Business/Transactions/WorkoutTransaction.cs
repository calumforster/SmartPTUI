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

            Workout.WorkoutWeek.Add(new WorkoutWeek() {
                StartWeight = questionResults.WorkoutQuestion.StartWeight.Value,
                EndWeight = questionResults.WorkoutQuestion.StartWeight.Value - 1,
                CaloriesConsumed = 0
            });

            Workout.WorkoutWeek[0].Workout = new List<WorkoutSession>();
            var excersizeCycle = 0;

            for (int i = 0; i < questionResults.WorkoutQuestion.DaysPerWeek; i ++) 
            {                             
                WorkoutSession workoutSession = new WorkoutSession();
                workoutSession.Excersizes = new List<ExcersizeMeta>();
                workoutSession.Feedback = new WorkoutFeedback();
                Random random = new Random();

                for (int j = 0; j < 4; j++) {
                    var excersize = await _excersizeRepository.GetExcersizeWithWorkoutArea(excersizeCycle);
                    int excersizeId = excersize.Id;
                    workoutSession.Excersizes.Add(new ExcersizeMeta
                    { 
                     WeightGoal = (int) (0.7 * questionResults.WorkoutQuestion.StartWeight),
                     SetsGoal = random.Next(1,10),
                     RepsGoal = 12,
                     ExcersizeId = excersizeId
                    });
                }


                if ((i > 0) && (i % 3 == 0))
                {
                    excersizeCycle = excersizeCycle - 3;
                }
                else 
                {
                    excersizeCycle++;
                }
                
                Workout.WorkoutWeek[0].Workout.Add(workoutSession);
            }

            return await _workoutRepository.SaveInitialWorkout(Workout);
            
        }

        public async Task<WorkoutPlan> GetWorkout(int id)
        {
            return await _workoutRepository.GetWorkout(id);
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

        public async Task<int> SaveExcersizeMeta(ExcersizeMeta excersizeMeta)
        {
            return await _workoutRepository.SaveExcersizeMeta(excersizeMeta);
        }
    }
}
