using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;

namespace SemaFlags.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(BoardList.Boards);
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
            BoardList.AddBoard(board);
            return View("Index", BoardList.Boards);
        }
    }
}
