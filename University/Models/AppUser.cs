using Microsoft.AspNetCore.Identity;

namespace University.Models
{
    public class AppUser : IdentityUser
    {
        // If you want to add a specific user feature/property you just need to add the property here, for example nickname implementation would be:
        // public String Nickname {get; set;}
        // In this case you just need to leave this class alone and wokr with default user data that Identity brings on.
    }
}
