using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;

namespace SemaFlags.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IBoardRepo repo):base(repo)
        {
            
        }
        public IActionResult Index()
        {
            return View(Repo.Boards);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Board()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Board(Board board)
        {
            if (ModelState.IsValid)
            {
                Repo.AddBoard(board);
                return View("Index", Repo.Boards);
            }
            else
                return View();
        }
    }
}
