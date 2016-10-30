using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.DAL;

namespace SemaFlags.Controllers
{
    public class BaseController : Controller
    {
        private UnitOfWork repository;
      

        public BaseController(SemaFlagsDBContext repo)
        {
            repository = new DAL.UnitOfWork( repo);
          
        }

        protected UnitOfWork Repo => repository;

    }
}
