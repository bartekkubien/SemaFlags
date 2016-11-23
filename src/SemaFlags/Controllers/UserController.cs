using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SemaFlags.ViewModels;
using SemaFlags.Models;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class UserController : Controller
    {

        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(UserManager<User> usrMgr, SignInManager<User> signMgr) {
            userManager = usrMgr;
            signInManager = signMgr;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user;
                if (model.UserName.Contains("@"))
                {
                    user = await userManager.FindByEmailAsync(model.UserName);
                }
                else {
                    user = await userManager.FindByNameAsync(model.UserName);
                }
                if (user != null) {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult  result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded) {
                        return Redirect(returnUrl ?? "/");
                    }
                }
            }

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid) {
                User user = new Models.User {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) { return RedirectToAction("Login"); }
                else { foreach (IdentityError error in result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    } }
            }
            else { }
            return View(model);
        }
    }
}
