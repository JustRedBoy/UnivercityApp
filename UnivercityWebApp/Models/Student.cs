namespace UnivercityWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Course { get; set; }

        public int GroupId { get; set; }
        public int ApplicationUserId { get; set; }

        public Group Group { get; set; }
        public ApplicationUser GeneralInfo { get; set; }
    }
}
