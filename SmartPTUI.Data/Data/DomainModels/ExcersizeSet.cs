using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class ExcersizeSet
    {
        public int ExcersizeSetId { get; set; }
        public string SetName { get; set; }
        public int RepsAchieved { get; set; }
        public int WeightAchieved { get; set; }
        public int RepsInReserve { get; set; }
    }
}
