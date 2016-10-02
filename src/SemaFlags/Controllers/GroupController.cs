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
        public IActionResult Index(int? id)
        {
            return View(Repo.Boards.FirstOrDefault(b => b.Id == id));
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
                return View("~/Views/Home/Index.cshtml", Repo.Boards);
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
                return View("~/Views/Home/Index.cshtml", Repo.Boards);
            }
            else
                return View();
        }

        public IActionResult Delete(int id)
        {
            Repo.DeleteBoard(Repo.Boards.FirstOrDefault(b => b.Id == id));
            return View("~/Views/Home/Index.cshtml", Repo.Boards);
        }

    }
    
}
