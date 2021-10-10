using Microsoft.AspNetCore.Identity;

namespace UnivercityWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public bool IsTeacher { get; set; }
    }
}
