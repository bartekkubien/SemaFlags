using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.ViewModels;
using SemaFlags.DAL;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class GroupController : BaseController
    {
        public GroupController(SemaFlagsDBContext repo) : base(repo)
        {
        }

        [HttpGet]
        public IActionResult Index( int? id)
        {
            Group group = Repo.GroupRepository?.Elements?.FirstOrDefault(g => g.Id == id);
            ViewBag.GroupId = id;
            ViewBag.BoardId = group.BoardId;
            ViewBag.Name = group.Name;
            ViewBag.Description = group.Description;
            return View(Repo.NodeRepository?.Elements?.Where(n => n.GroupId == id));
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            Board board = Repo?.BoardRepository?.Elements?.FirstOrDefault(b=>b.Id == id);
            ViewBag.BoardId = id;
            ViewBag.Name = board.Name;
            ViewBag.Description = board.Description;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Add( Group group)
        {
            if (ModelState.IsValid)
            {
                int boardId = group.BoardId;
                Repo?.GroupRepository?.SaveElement(group);
                Repo?.Save();
                return RedirectToAction("Index", "Board", new { id = boardId });
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit( int? id)
        {
            return View(Repo?.GroupRepository?.Elements?.FirstOrDefault(g => g.Id == id));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit( Group group)
        {
            if (ModelState.IsValid)
            {
                Repo.GroupRepository?.SaveElement(group);
                Repo?.Save();
                return RedirectToAction("Index", "Board", new { id = group.BoardId });
            }
            else
                return View();
        }

        public IActionResult Delete(int groupID)
        {
            //Group group = Repo?.GroupRepository?.Elements?.FirstOrDefault(g => g.Id == groupID);
            //int boardId = group.BoardId;
            Group group = Repo?.GroupRepository?.RemoveElement(groupID);
            Repo?.Save();
            return RedirectToAction("Index", "Board", new { id = group.BoardId  });
        }

    }
    
}
