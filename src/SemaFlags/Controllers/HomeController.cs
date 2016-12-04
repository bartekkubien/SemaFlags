using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SemaFlags.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(SemaFlagsDBContext repo, UserManager<User> mgr):base(repo, mgr)
        {

        }
        
        public IActionResult Index()
        {

            //IEnumerable<Board> boards = Repo.BoardRepository.Elements.Where(e => e.BoardOwnerId == User.Identity.) 
            string  userId = UserManager.GetUserId(User );
            return View(Repo.BoardRepository.Elements);
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

        //[HttpGet]
        //public ViewResult Board()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ViewResult Board(Board board)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Repo.AddBoard(board);
        //        return View("Index", Repo.Boards);
        //    }
        //    else
        //        return View();
        //}
    }
}
