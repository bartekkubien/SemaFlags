using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.DAL;
using Microsoft.AspNetCore.Authorization;

namespace SemaFlags.Controllers
{
    [Authorize]
    public class NodeController : BaseController
    {
        public NodeController(SemaFlagsDBContext repo) : base(repo)
        {
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            Node node = Repo?.NodeRepository?.Elements?.FirstOrDefault(n => n.Id == id);
            ViewBag.GroupId = node?.GroupId;
            ViewBag.GroupName = Repo?.GroupRepository?.Elements?.FirstOrDefault(g => g.Id == node.GroupId).Name;
            return View(node);

        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            Group group = Repo?.GroupRepository?.Elements?.FirstOrDefault(n => n.Id == id);
            ViewBag.GroupId = id;
            ViewBag.Name = group?.Name;
            ViewBag.Description = group?.Description;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Add(Node Node)
        {
            if (ModelState.IsValid)
            {
                Board board = Repo?.BoardRepository?.Elements?.FirstOrDefault(b => b.Id == Node.GroupId);
                Repo?.NodeRepository?.SaveElement(Node);
                Repo?.Save();
                return RedirectToAction("Index", "Group", new { id=Node.GroupId });
            }
            else
                return View();
        }

        [HttpGet]
        public  IActionResult Edit(int? id) =>  View(Repo?.NodeRepository?.Elements?.FirstOrDefault(g => g.Id == id));
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Node Node)
        {
            if (ModelState.IsValid)
            {
                Node n = Repo.NodeRepository.SaveElement(Node);
                Repo.Save();
                return RedirectToAction("Index", "Group", new { id = n.GroupId });
            }
            else
                return View();
        }

        public IActionResult Delete(int id)
        {
            //Node Node = Repo?.NodeRepository?.Elements?.FirstOrDefault(g => g.Id == id);
           // if (Node == null) RedirectToAction("Error");       
           // int groupId = Node.GroupId;
            Node node  = Repo?.NodeRepository?.RemoveElement(id);
            Repo?.Save();
            //Group group = Repo?.GroupRepository?.Elements?.FirstOrDefault(g => g.Id == groupId);
            //ViewBag.BoardId = group.BoardId;
            //ViewBag.Name = group.Name;
            //ViewBag.Description = gro up.Description;

            return RedirectToAction("Index", "Group", new { id = node.GroupId  });
        }


        public void ChangeUser(int nodeId, int userId)
        {
            System.Threading.Thread.Sleep(1000);
            Node node = Repo?.NodeRepository?.Elements?.FirstOrDefault(n => n.Id == nodeId);
            node.AssignedUserId = userId;
            Repo?.NodeRepository?.SaveElement(node);
            Repo?.Save();
        }
    }

}
