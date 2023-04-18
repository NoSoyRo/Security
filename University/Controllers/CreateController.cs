using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University.Models;

namespace University.Controllers
{
    // We need to inherit from Controller class in MVC, the reason of this is that you can use methods such as View for returning the Action.
    public class CreateController : Controller
    {
        // So now we need the service of UserManager, the point of this is to facilitate using Identity and E.F. the managing of users in the D.B.
        public UserManager<AppUser> usrMngr;
        // Use D.I. for Unit Tests
        public CreateController(UserManager<AppUser> usrMngr)
        {
            this.usrMngr=usrMngr;
        }
        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateUser usr)
        {
            // We verify if the model was created valid.
            if (ModelState.IsValid)
            {
                // Create an instance of the AppUser with the CreateUser information. 
                AppUser user = new AppUser
                {
                    UserName = usr.UserName,
                    Email = usr.Email,
                };
                // Then we use it to create the user in an asychronous way but stoping everything until the result finishes.
                IdentityResult result = await usrMngr.CreateAsync(user, usr.Password);                
                if (result.Succeeded)
                {
                    // If the result is succeded then we redirect to Home ---> Thi will change because it needs to redirect to other page
                    return RedirectToAction("Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }      
            }
            // TODO: Create a view such that it can obtain a model and write some bad features of each value. Right now it only redirects to istelf.
            return View(usr);
        }
        
    }
}
