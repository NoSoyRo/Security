using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University.Models;

namespace University.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> usrMngr;
        private SignInManager<AppUser> lgnMngr;
        public AccountController(UserManager<AppUser> usrMngr, SignInManager<AppUser> lgnMngr)
        {
            this.usrMngr=usrMngr;
            this.lgnMngr=lgnMngr;
        }

        // Now we create the login view for a get request:
        [AllowAnonymous]
        public ViewResult Login(string returnUrl){
        ViewBag.returnUrl = returnUrl;
        return View();
        }
        // The following method just applies the Login logic.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser detail, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser usr = await usrMngr.FindByEmailAsync(detail.Email);
                if (usr != null)
                {
                    await lgnMngr.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await lgnMngr.PasswordSignInAsync(usr, detail.Password, true, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginUser.Email), "invalid Username of passwortd");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
