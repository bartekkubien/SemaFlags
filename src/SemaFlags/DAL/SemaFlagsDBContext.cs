using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemaFlags.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SemaFlags.DAL

{
    public class SemaFlagsDBContext : IdentityDbContext<User, Role, int>
    {
        // GET: /<controller>/
        public SemaFlagsDBContext(DbContextOptions<SemaFlagsDBContext> options)
            : base(options) { }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<UserBoardAffiliation> UserBoardAffiliations { get; set; }
        // public DbSet<User> Users { get; set; }

    }
}
