using Microsoft.AspNetCore.Identity;

namespace Chapter_Find_Online_Bookstore.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
