using System;
using System.Collections.Generic;

namespace UnivercityWebApp.Models
{
    public class Work // при создании создавать Evaluation для всех студентов с Rate = 0 и IsAttend = true
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }

        public int AbstractWorkId { get; set; }

        public AbstractWork AbstractWork { get; set; }
        public List<Group> Groups { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}
