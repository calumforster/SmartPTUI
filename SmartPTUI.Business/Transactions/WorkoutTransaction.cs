using AutoMapper;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Data.Data.DomainModels;
using SmartPTUI.Data.DomainModels;
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

            List<Task<Excersize>> taskList = new List<Task<Excersize>>();
           // taskList.Add(_excersizeRepository.GetChestExcersize());
           // taskList.Add(_excersizeRepository.GetBackExcersize());
           // taskList.Add(_excersizeRepository.GetShouldersExcersize());
            //taskList.Add(_excersizeRepository.GetLegsExcersize());


            var Workout = new WorkoutPlan();
            Workout.Customer = _mapper.Map<CustomerViewModel, Customer>(questionResults.Customer);
            Workout.WorkoutQuestion = questionResults.WorkoutQuestion;
            Workout.WorkoutWeek = new List<WorkoutWeek>();
            Workout.WorkoutWeek.Add(new WorkoutWeek() {
                StartWeight = questionResults.WorkoutQuestion.StartWeight.Value,
                EndWeight = questionResults.WorkoutQuestion.StartWeight.Value - 1,
                CaloriesConsumed = 0
            });


            for (int i = 0; i < questionResults.WorkoutQuestion.DaysPerWeek; i ++) 
            {
                var excersizeCycle = i;
                if (i > 4)
                {
                    excersizeCycle = excersizeCycle - 4;
                }
                Workout.WorkoutWeek[0].Workout = new List<WorkoutSession>();

                WorkoutSession workoutSession = new WorkoutSession();
                workoutSession.Excersizes = new List<ExcersizeMeta>();
                workoutSession.Feedback = new WorkoutFeedback();

                for (int j = 0; j < 4; j++) {
                    workoutSession.Excersizes.Add(new ExcersizeMeta
                    { 
                     Weight = (int) (0.7 * questionResults.WorkoutQuestion.StartWeight),
                     Sets = 4,
                     Reps = 12,
                     ExcersizeType = await _excersizeRepository.GetChestExcersize()
                    });
                }
                Workout.WorkoutWeek[0].Workout.Add(workoutSession);
            }

            return await _workoutRepository.SaveInitialWorkout(Workout);
            
        }

        public async Task<WorkoutPlan> GetWorkout(int id)
        {
            return await _workoutRepository.GetWorkout(id);
        }
    }
}
