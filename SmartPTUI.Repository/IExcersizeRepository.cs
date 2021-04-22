using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartPTUI.ContentRepository
{
    public interface IExcersizeRepository
    {
        public Task<Excersize> GetChestExcersize();
        public Task<Excersize> GetBackExcersize();
        public Task<Excersize> GetShouldersExcersize();
        public Task<Excersize> GetLegsExcersize();
        public Task<Excersize> GetExcersizeWithWorkoutArea(int workoutArea);
    }
}
