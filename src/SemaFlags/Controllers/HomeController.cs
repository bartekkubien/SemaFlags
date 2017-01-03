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

            if (GetUserId != -1) {
                List<int> boardIDs = Repo.UserBoardAffiliationRepository.Elements.Where(uba => uba.userId == GetUserId).Select(p => p.boardId).ToList<int>();
                List<Board> vb = new List<Board>();
                                     
                foreach (int id in boardIDs) {
                    Board b = Repo?.BoardRepository?.Elements.FirstOrDefault(e => e.Id == id);
                    b.UserAffiliations = Repo?.UserBoardAffiliationRepository?.Elements.Where(uba => uba.boardId == id && uba.userId == GetUserId).ToList<UserBoardAffiliation>();
                    vb.Add(b);
                }
                return View(vb);
            }
            else return View();
                     
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
