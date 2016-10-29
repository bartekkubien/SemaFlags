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
        public IActionResult Index(int? id)
        {
            Node node = Repo?.Nodes?.FirstOrDefault(n => n.Id == id);
            ViewBag.GroupId = node?.GroupId;
            ViewBag.GroupName = Repo?.Groups.FirstOrDefault(g => g.Id == node.GroupId).Name;
            return View(node);

        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            Group group = Repo?.Groups?.FirstOrDefault(n => n.Id == id);
            ViewBag.GroupId = id;
            ViewBag.Name = group?.Name;
            ViewBag.Description = group?.Description;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Node Node)
        {
            if (ModelState.IsValid)
            {
                Board board = Repo?.Boards?.FirstOrDefault(b => b.Id == Node.GroupId);
                Repo?.AddNode(Node);

                return RedirectToAction("Index", "Group", new { id=Node.GroupId });
            }
            else
                return View();
        }

        [HttpGet]
        public  IActionResult Edit(int? id) =>  View(Repo?.Nodes?.FirstOrDefault(g => g.Id == id));
        

        [HttpPost]
        public IActionResult Edit(Node Node)
        {
            if (ModelState.IsValid)
            {
                Repo?.EditNode(Node);
                return RedirectToAction("Index", "Group", new { id = Node.GroupId });
            }
            else
                return View();
        }

        public IActionResult Delete(int? id)
        {
            Node Node = Repo?.Nodes?.FirstOrDefault(g => g.Id == id);
            if (Node == null) RedirectToAction("Error");       
            int groupId = Node.GroupId;
            Repo?.DeleteNode(Node);

            Group group = Repo?.Groups?.FirstOrDefault(g => g.Id == groupId);
            //ViewBag.BoardId = group.BoardId;
            //ViewBag.Name = group.Name;
            //ViewBag.Description = gro up.Description;

            return RedirectToAction("Index", "Group", new { id = groupId });
        }


        public void ChangeUser(int nodeId, int userId)
        {
            System.Threading.Thread.Sleep(1000);
            Node Node = Repo?.Nodes?.FirstOrDefault(n => n.Id == nodeId);
            Node.AssignedUserId = userId;
        }
    }

}
