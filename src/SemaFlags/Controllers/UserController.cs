using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SemaFlags.ViewModels;
using SemaFlags.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class UserController : Controller
    {

        private UserManager<User> userManager;

        public UserController(UserManager<User> usrMgr) {
            userManager = usrMgr;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
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
