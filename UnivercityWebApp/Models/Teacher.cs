namespace UnivercityWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Position { get; set; }

        public ApplicationUser GeneralInfo { get; set; }
    }
}
