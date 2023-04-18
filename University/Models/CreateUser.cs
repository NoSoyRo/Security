using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class CreateUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        // This implements a non optimal way of implementation of the manage of membership.
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }
    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[]? IdsToAdd { get; set; }
        public string[]? IdsToDelete { get; set; }
    }
}
