using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class NodeController : BaseController
    {
        public NodeController(IBoardRepo repo) : base(repo)
        {
        }

        [HttpGet]
        public IActionResult Index( int NodeID)
        {
            return View(Repo.Nodes.FirstOrDefault(n=>n.Id == NodeID)
                );
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            Group group = Repo.Groups.FirstOrDefault(n=>n.Id == id);
            ViewBag.Id = id;
            ViewBag.Name = group.Name;
            ViewBag.Description = group.Description;
            return View();
        }

        [HttpPost]
        public IActionResult Add( Node Node)
        {
            if (ModelState.IsValid)
            {
                Board board = Repo.Boards.FirstOrDefault(b => b.Id == Node.GroupId);
                Repo.AddNode(Node);
                ViewBag.Id = board.Id;
                ViewBag.Name = board.Name;
                ViewBag.Description = board.Description;
                return View("~/Views/Board/Index.cshtml", Repo.Nodes.Where(g=>g.GroupId == Node.GroupId));
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit( int NodeID)
        {
            return View(Repo.Nodes.FirstOrDefault(g => g.Id == NodeID));
        }

        [HttpPost]
        public IActionResult Edit( Node Node)
        {
            if (ModelState.IsValid)
            {
                Repo.EditNode(Node);
                return View("~/Views/Board/Index.cshtml", Repo.Nodes.Where(g => g.GroupId == Node.GroupId));
            }
            else
                return View();
        }

        public IActionResult Delete(int NodeID)
        {
            Node Node = Repo.Nodes.FirstOrDefault(g => g.Id == NodeID);
            int boardId = Node.GroupId;
            Repo.DeleteNode(Node);
            return View("~/Views/Board/Index.cshtml", Repo.Nodes.Where(g => g.GroupId == boardId));
        }

    }
    
}
