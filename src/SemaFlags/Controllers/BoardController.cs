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
        public IActionResult Index(int? id)
        {
            if (id == null) return View();
            Board board = Repo?.BoardRepository?.Elements?.FirstOrDefault(b => b.Id == id);
            ViewBag.Id = id;
            ViewBag.Name = board.Name;
            ViewBag.Description = board.Description;

            GroupView gv = new ViewModels.GroupView();
            gv.Groups = Repo?.GroupRepository?.Elements?.Where(g => g.BoardId == id).ToList<Group>();
            
            foreach (Group g in gv.Groups) {
                gv.Nodes.AddRange(Repo?.NodeRepository?.Elements?.Where(n => n.GroupId == g.Id).ToList<Node>());
            }

            foreach (User u in Repo.UserRepository?.Elements) {
                gv.Users.Add(new SelectListItem { Value = u.Id.ToString(),  Text=u.Name});
            }
            return View(gv);
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
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View(Repo.BoardRepository?.Elements?.FirstOrDefault(b => b.Id == id));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
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
            Repo?.BoardRepository?.RemoveElement(id);
            Repo?.Save();
            return RedirectToAction("Index", "Home");
        }

    }
    
}
