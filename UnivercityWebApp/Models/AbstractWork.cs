namespace UnivercityWebApp.Models
{
    public class AbstractWork
    {
        public int Id { get; set; }
        public WorkType WorkType { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public double Сoefficient { get; set; }
        public double MaxRate { get; set; }
        //public int? DaysToDueDate { get; set; } // for lab, rgr

        public int StudyItemId { get; set; }

        public StudyItem StudyItem { get; set; }
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