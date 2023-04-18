using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using University.Models;

namespace University.Infrastructure
{
    [HtmlTargetElement("td", Attributes = "identity-role")]
    public class UsersTagHelper : TagHelper
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public UsersTagHelper(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager=userManager;
            this.roleManager=roleManager;
        }
        // we need to assign the role.id as a property of the class.
        [HtmlAttributeName("identity-role")]
        public string Role { get; set; }
        // we override the function ProcessAsync to change this process asychronous to a process that satisfies the business requirements.
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            IdentityRole role = await roleManager.FindByIdAsync(Role);
            if (role != null)
            {
                foreach(var user in userManager.Users)
                {
                    if (user != null && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        names.Add(user.UserName);
                    }
                }

            }
            output.Content.SetContent(names.Count == 0 ? "No Users" : String.Join(", ", names));
        }
    }
}
