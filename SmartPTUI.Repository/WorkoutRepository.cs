using SmartPTUI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.ContentRepository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly SmartPTUIContext _context;
        public WorkoutRepository(SmartPTUIContext context)
        {
            _context = context;
        }


    }
}
