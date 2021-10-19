using System.Collections.Generic;

namespace UnivercityWebApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int Course { get; set; }
        public string Name { get; set; }

        public int DirectionId { get; set; }
        public int TeacherId { get; set; }

        public List<Student> Students { get; set; }
        public Direction Direction { get; set; }
        public Teacher Curator { get; set; }
    }
}
