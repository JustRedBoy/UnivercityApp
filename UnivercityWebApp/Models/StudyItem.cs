using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnivercityWebApp.Models
{
    public class StudyItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public StudyType StudyType { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        public List<Group> Groups { get; set; }
        public List<Work> Works { get; set; }
    }

    public enum StudyType
    {
        StudyCourse = 0,
        CourseWork
    }
}
