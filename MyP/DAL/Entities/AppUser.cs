using Microsoft.AspNetCore.Identity;

namespace MyP.DAL.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
