using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SemaFlags.Models
{
    public class SemaFlagsDBContext : DbContext
    {
        // GET: /<controller>/
        public SemaFlagsDBContext(DbContextOptions<SemaFlagsDBContext> options)
            : base(options) { }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<User> Users { get; set; }
       
    }
}
