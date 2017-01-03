using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using SemaFlags.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SemaFlags.Controllers
{
    [Authorize]
    public class BoardController : BaseController
    {
        public BoardController(SemaFlagsDBContext repo, UserManager<User> mgr) : base(repo, mgr)
        {
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
                
            if (id !=0 && GetUserId !=-1 && Repo.CanUserEditBoard(GetUserId, (int)id))
            {
                Board board = Repo?.BoardRepository?.Elements?.FirstOrDefault(b => b.Id == id);
                ViewBag.Id = id;
                ViewBag.Name = board.Name;
                ViewBag.Description = board.Description;

                GroupView gv = new ViewModels.GroupView();
                gv.userId = GetUserId;
                gv.Groups = Repo?.GroupRepository?.Elements?.Where(g => g.BoardId == id).ToList<Group>();

                foreach (Group g in gv.Groups)
                {
                    gv.Nodes.AddRange(Repo?.NodeRepository?.Elements?.Where(n => n.GroupId == g.Id).ToList<Node>());
                }

                var userIds = Repo?.UserBoardAffiliationRepository.Elements.Where(uba => uba.boardId == id).Select(uba => uba.userId );

                gv.Users.AddRange(Repo?.UserRepository?.Elements.Where(u => userIds.Contains(u.Id)));

                return View(gv);
            }
            else {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Add(Board board)
        {
            if (ModelState.IsValid)
            {
                Repo?.BoardRepository?.SaveElement(board);
                Repo?.Save();
                UserBoardAffiliation uba = new UserBoardAffiliation()
                {
                    userId = GetUserId,
                    boardId = board.Id,
                    isAdmin = true
                };
                Repo?.UserBoardAffiliationRepository?.SaveElement(uba);
                Repo?.Save();
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (Repo.CanUserEditBoard(GetUserId, id))
                return View(Repo.BoardRepository?.Elements?.FirstOrDefault(b => b.Id == id /*canedit(user, board)*/));  //add CanEdit in Repo
            else
                return RedirectToAction("Index");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Board board)
        {
            if (ModelState.IsValid && Repo.CanUserEditBoard(GetUserId, board.Id))
            {
                Board b = Repo.BoardRepository.SaveElement(board);
                Repo?.Save();
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        public IActionResult Delete(int id)
        {
            if (Repo.CanUserEditBoard(GetUserId, id))
            {
                Repo?.BoardRepository?.RemoveElement(id);
                Repo?.Save();
            }
            return RedirectToAction("Index", "Home");
        }

    }
    
}
