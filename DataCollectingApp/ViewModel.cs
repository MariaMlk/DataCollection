using System;
using System.Collections.Generic;

namespace DataCollectingApp
{
    public class ViewModel
    {
        public string FullName { get; set; }
        public int? Age { get; set; } = null;
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public double? Weight { get; set; } = null;
        public double? Height { get; set; } = null;
        public string Recommendations { get; set; }
        public DateTime? VisitDate { get; set; } = null;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }

    public class Exercise
    {
        public string Name { get; set; }
        public int? RepeatsNumber { get; set; } = null;
        public int? Minutes { get; set; } = null;
        public string Comment { get; set; }
    }
}
