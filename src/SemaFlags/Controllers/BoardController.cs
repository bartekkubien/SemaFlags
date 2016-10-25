using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace SemaFlags.Controllers
{
    public class BoardController : BaseController
    {
        public BoardController(IBoardRepo repo) : base(repo)
        {
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if (id == null) return View();
            Board board = Repo.Boards.FirstOrDefault(b => b.Id == id);
            ViewBag.Id = id;
            ViewBag.Name = board.Name;
            ViewBag.Description = board.Description;

            GroupView gv = new ViewModels.GroupView();
            gv.Groups = Repo.Groups.Where(g => g.BoardId == id).ToList<Group>();
            
            foreach (Group g in gv.Groups) {
                gv.Nodes.AddRange(Repo.Nodes.Where(n => n.GroupId == g.Id).ToList<Node>());
            }

            foreach (User u in Repo.Users) {
                gv.Users.Add(new SelectListItem { Value = u.Id.ToString(),  Text=u.Name});
            }
            return View(gv);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Board board)
        {
            if (ModelState.IsValid)
            {
                Repo.AddBoard(board);
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View(Repo.Boards.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                Repo.EditBoard(board);
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        public IActionResult Delete(int id)
        {
            Repo.DeleteBoard(Repo.Boards.FirstOrDefault(b => b.Id == id));
            return RedirectToAction("Index", "Home");
        }

    }
    
}
