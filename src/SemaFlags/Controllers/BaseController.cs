using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class BaseController : Controller
    {
        private IBoardRepo repository;

        public BaseController(IBoardRepo repo)
        {
            repository = repo;
        }

        protected IBoardRepo Repo => repository;

    }
}
