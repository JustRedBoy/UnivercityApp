using System.Collections.Generic;

namespace UnivercityWebApp.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }

        public List<Group> Groups { get; set; }
        public List<StudyItem> StudyItems { get; set; }
    }
}
