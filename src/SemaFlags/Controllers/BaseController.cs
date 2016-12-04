using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.DAL;
using Microsoft.AspNetCore.Identity;

namespace SemaFlags.Controllers
{
    public class BaseController : Controller
    {
        private UnitOfWork repository;
        private UserManager<User> userManager;

        public BaseController(SemaFlagsDBContext repo, UserManager<User> mgr)
        {
            repository = new DAL.UnitOfWork( repo);
            userManager = mgr;
        }

        protected UnitOfWork Repo => repository;
        protected UserManager<User> UserManager => userManager;
    }
}
