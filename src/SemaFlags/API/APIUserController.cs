﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SemaFlags.Models;
using SemaFlags.Controllers;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.API
{
    [Route("api/[controller]")]
    public class APIUserController : BaseController
    {
       
        public APIUserController(IBoardRepo repo) : base(repo) { }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get() => Repo.Users;
        // GET api/values/5
        //[HttpGet("{id}")]
        //public IEnumerable<Node> Get(int id) => Repo.Nodes.Where(n => n.GroupId == id);

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //    throw new NotImplementedException();
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}