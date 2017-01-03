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

        private int userID = -1;

        public BaseController(SemaFlagsDBContext repo, UserManager<User> mgr)
        {
            repository = new DAL.UnitOfWork( repo);
            userManager = mgr;
        }

        public virtual int GetUserId {
            get { if (userID != -1)
                    return userID;

                bool ret = int.TryParse(UserManager.GetUserId(User), out userID);
                if (ret)
                    return userID;
                else return -1;
            }
        }

        protected UnitOfWork Repo => repository;
        protected UserManager<User> UserManager => userManager;
    }
}
