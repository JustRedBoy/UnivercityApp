using System;
using System.Collections.Generic;

namespace UnivercityWebApp.Models
{
    public class Work
    {
        public int Id { get; set; }
        public WorkType WorkType { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public double Сoefficient { get; set; }
        public double MaxRate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Hidden { get; set; }

        public int StudyItemId { get; set; }

        public StudyItem StudyItem { get; set; }
        // при создании создавать Evaluation для всех студентов с Rate = 0 и IsAttend = true
        public List<Evaluation> Evaluations { get; set; } 
    }

    public enum WorkType
    {
        Lecture = 0,
        Practice,
        Lab,
        RGR,
        Module,
        IndividualWork,
        Essay,
        ExtraWork,
        Stage // for course work
    }
}