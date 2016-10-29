using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            SemaFlagsDBContext context = app.ApplicationServices.GetRequiredService<SemaFlagsDBContext>();

            Board board1 = null;
            Board board2 = null;
            if (!context.Boards.Any())
            {
                board1 = new Board { Name = "Rauta", Description = "Integration Environment" };
                board2 = new Board { Name = "Nordic" };
                context.Boards.AddRange(
                     board1 ,
                     board2
               );
                context.SaveChanges();
            }

            Group group1 = null;
            Group group2 = null;
            Group group3 = null;
            Group group4 = null;

            if (!context.Groups.Any())
            {
                group1 = new Group { BoardId = board1.Id, Name = "Dev", Description = "Development machines" };
                group2 = new Group { BoardId = board1.Id, Name = "QA", Description = "QA machines" };
                group3 = new Group { BoardId = board2.Id, Name = "Dev", Description = "Development machines" };
                group4 = new Group { BoardId = board2.Id, Name = "QA", Description = "QA machines" };
                context.Groups.AddRange(
                        group1, group2, group3, group4    
                    );
            }
           
            if (!context.Nodes.Any())
            {
                context.Nodes.AddRange(
                        new Node { GroupId = group1.Id, Name = "Finnish POS", Description = "F555P001"},
                        new Node { GroupId = group1.Id, Name = "Finnish BS", Description = "F555S001" },
                        new Node { GroupId = group1.Id, Name = "Swedish POS", Description = "H555P001" },
                        new Node { GroupId = group1.Id, Name = "Swedish BS", Description = "H555S001" },
                        new Node { GroupId = group1.Id, Name = "Latvian POS", Description = "L555P001" },
                        new Node { GroupId = group1.Id, Name = "Latvian BS", Description = "L555S001" },
                        new Node { GroupId = group1.Id, Name = "Estonian POS", Description = "V555P001" },
                        new Node { GroupId = group1.Id, Name = "Estonian BS", Description = "V555S001" },
                        new Node { GroupId = group2.Id, Name = "Finnish POS", Description = "F550P001" },
                        new Node { GroupId = group2.Id, Name = "Finnish BS", Description = "F550S001" },
                        new Node { GroupId = group2.Id, Name = "Swedish POS", Description = "H550P001" },
                        new Node { GroupId = group2.Id, Name = "Swedish BS", Description = "H550S001" },
                        new Node { GroupId = group2.Id, Name = "Latvian POS", Description = "L550P001" },
                        new Node { GroupId = group2.Id, Name = "Latvian BS", Description = "L550S001" },
                        new Node { GroupId = group2.Id, Name = "Estonian POS", Description = "V550P001" },
                        new Node { GroupId = group2.Id, Name = "Estonian BS", Description = "V550S001" }
                    );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                        new User { Name = "Bartek", Description = "" },
                        new User { Name = "Tomek", Description = "" },
                        new User { Name = "Ania", Description = "" },
                        new User { Name = "Paweł", Description = "" }
                    );
                context.SaveChanges();
            }
          
        }
    }
}
