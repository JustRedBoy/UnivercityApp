namespace UnivercityWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public string ApplicationUserId { get; set; }

        public Group Group { get; set; }
        public ApplicationUser GeneralInfo { get; set; }
    }
}
