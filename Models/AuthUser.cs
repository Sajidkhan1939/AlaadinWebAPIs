using Microsoft.AspNetCore.Identity;

namespace AlaadinWebAPIs.Models
{
    public class AuthUser: IdentityUser
    {

        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
