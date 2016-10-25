using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.ViewModels;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class GroupController : BaseController
    {
        public GroupController(IBoardRepo repo) : base(repo)
        {
        }

        [HttpGet]
        public IActionResult Index( int? id)
        {
            Group group = Repo.Groups.FirstOrDefault(g => g.Id == id);
            ViewBag.GroupId = id;
            ViewBag.BoardId = group.BoardId;
            ViewBag.Name = group.Name;
            ViewBag.Description = group.Description;
            return View(Repo.Nodes.Where(n => n.GroupId == id));
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            Board board = Repo.Boards.FirstOrDefault(b=>b.Id == id);
            ViewBag.BoardId = id;
            ViewBag.Name = board.Name;
            ViewBag.Description = board.Description;
            return View();
        }

        [HttpPost]
        public IActionResult Add( Group group)
        {
            if (ModelState.IsValid)
            {
                Board board = Repo.Boards.FirstOrDefault(b => b.Id == group.BoardId);
                Repo.AddGroup(group);
                //ViewBag.BoardId = board.Id;
                //ViewBag.Name = board.Name;
                //ViewBag.Description = board.Description;

                //GroupView gv = new ViewModels.GroupView();
                //gv.Groups = Repo.Groups.Where(g => g.BoardId == board.Id).ToList<Group>();
                //foreach (Group g in gv.Groups)
                //{
                //    gv.Nodes.AddRange(Repo.Nodes.Where(n => n.GroupId == g.Id).ToList<Node>());
                //}

                return RedirectToAction("Index", "Board", new { id = board.Id });
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit( int? id)
        {
            return View(Repo.Groups.FirstOrDefault(g => g.Id == id));
        }

        [HttpPost]
        public IActionResult Edit( Group group)
        {
            if (ModelState.IsValid)
            {
                Repo.EditGroup(group);
                return RedirectToAction("Index", "Board", new { id = group.BoardId });
            }
            else
                return View();
        }

        public IActionResult Delete(int groupID)
        {
            Group group = Repo.Groups.FirstOrDefault(g => g.Id == groupID);
            int boardId = group.BoardId;
            Repo.DeleteGroup(group);
            return RedirectToAction("Index", "Board", new { id = boardId });
        }

    }
    
}
