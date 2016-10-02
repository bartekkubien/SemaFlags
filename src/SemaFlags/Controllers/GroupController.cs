using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class GroupController : BaseController
    {
        public GroupController(IBoardRepo repo) : base(repo)
        {
        }

        [HttpGet]
        public IActionResult Index( int groupID)
        {
            return View(Repo.Groups.FirstOrDefault(g=>g.Id == groupID)
                );
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            Board board = Repo.Boards.FirstOrDefault(b=>b.Id == id);
            ViewBag.Id = id;
            ViewBag.Name = board.Name;
            ViewBag.Description = board.Description;
            return View();
        }

        [HttpPost]
        public IActionResult Add( Group group)
        {
            if (ModelState.IsValid)
            {
                Board board = Repo.Boards.FirstOrDefault(b => b.Id == group.boardId);
                Repo.AddGroup(group);
                ViewBag.Id = board.Id;
                ViewBag.Name = board.Name;
                ViewBag.Description = board.Description;
                return View("~/Views/Board/Index.cshtml", Repo.Groups.Where(g=>g.boardId == group.boardId));
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit( int groupID)
        {
            return View(Repo.Groups.FirstOrDefault(g => g.Id == groupID));
        }

        [HttpPost]
        public IActionResult Edit( Group group)
        {
            if (ModelState.IsValid)
            {
                Repo.EditGroup(group);
                return View("~/Views/Board/Index.cshtml", Repo.Groups.Where(g => g.boardId == group.boardId));
            }
            else
                return View();
        }

        public IActionResult Delete(int groupID)
        {
            Group group = Repo.Groups.FirstOrDefault(g => g.Id == groupID);
            int boardId = group.boardId;
            Repo.DeleteGroup(group);
            return View("~/Views/Board/Index.cshtml", Repo.Groups.Where(g => g.boardId == boardId));
        }

    }
    
}
