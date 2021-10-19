using System.Collections.Generic;

namespace UnivercityWebApp.Models
{
    public class StudyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudyType StudyType { get; set; }

        public int TeacherId { get; set; }

        //public List<Group> Groups { get; set; }
        public List<AbstractWork> Works { get; set; }
        public Teacher Teacher { get; set; }
    }

    public enum StudyType
    {
        StudyCourse = 0,
        CourseWork
    }
}
