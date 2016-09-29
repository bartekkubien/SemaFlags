using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Controllers
{
    public class BoardController : Controller
    {

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Board board)
        {
            if (ModelState.IsValid)
            {
                BoardList.AddBoard(board);
                return View("~/Views/Home/Index.cshtml", BoardList.Boards);
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return View(BoardList.Boards.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                BoardList.EditBoard(board);
                return View("~/Views/Home/Index.cshtml", BoardList.Boards);
            }
            else
                return View();
        }

        public IActionResult Delete(int id)
        {
            BoardList.DeleteBoard(BoardList.Boards.FirstOrDefault(b => b.Id == id));
            return View("~/Views/Home/Index.cshtml", BoardList.Boards);
        }

    }
    
}
