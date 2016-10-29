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
        private ISemaFlagsRepository repository;

        public BaseController(ISemaFlagsRepository repo)
        {
            repository = repo;
        }

        protected ISemaFlagsRepository Repo => repository;

    }
}
