using Microsoft.AspNetCore.Identity;

namespace MyApp2.Data
{
    public class User: IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
