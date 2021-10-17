namespace UnivercityWebApp.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public bool IsAttend { get; set; } // for lectures, practices

        public int StudentId { get; set; }
        public int WorkId { get; set; }

        public Student Student { get; set; }
        public Work Work { get; set; }
    }
}
