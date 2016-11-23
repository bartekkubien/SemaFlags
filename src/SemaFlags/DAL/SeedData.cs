using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SemaFlags.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading;

namespace SemaFlags.DAL

{
    public class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            SemaFlagsDBContext context = app.ApplicationServices.GetRequiredService<SemaFlagsDBContext>();
            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();

            context.Boards.RemoveRange(context.Boards);
            context.Groups.RemoveRange(context.Groups);
            context.Nodes.RemoveRange(context.Nodes);
            context.UserBoardAffiliations.RemoveRange(context.UserBoardAffiliations);
            context.SaveChanges();
            Board board1 = null;
            Board board2 = null;
            if (!context.Boards.Any())
            {
                board1 = new Board { Name = "Rauta", Description = "Integration Environment" };
                board2 = new Board { Name = "Nordic" };
                context.Boards.AddRange(
                     board1,
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
                context.SaveChanges();
            }

            if (!context.Nodes.Any())
            {
                context.Nodes.AddRange(
                        new Node { GroupId = group1.Id, Name = "Finnish POS", Description = "F555P001" },
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

            //Task<User> tu = userManager.FindByNameAsync("Ania");
            //Task<User> tu1 = userManager.FindByNameAsync("Tomek");
            //Task<User> tu2 = userManager.FindByNameAsync("Michał");
            //Task<User> tu3 = userManager.FindByNameAsync("Jacek");

            //User user;
            //User user1;
            //User user2;
            //User user3;
            User user = await userManager.FindByNameAsync("Ania");
            User user1 = await userManager.FindByNameAsync("Tomek");
            User user2 = await userManager.FindByNameAsync("Michał");
            User user3 = await userManager.FindByNameAsync("Jacek");



            if (user == null)
            {
                user = new Models.User { UserName = "Ania", Email = "ania@example.com", Name = "Ania R" };
                userManager.CreateAsync(user, "aniaPass");
            }

            if (user1 == null)
            {
                user1 = new Models.User { UserName = "Tomek", Email = "tomek@example.com", Name = "Tomek H" };
                userManager.CreateAsync(user1, "tomekPass");
            }

            if (user2 == null)
            {
                user2 = new Models.User { UserName = "Michał", Email = "michal@example.com", Name = "Michał S" };
                userManager.CreateAsync(user2, "michalPass");
            }

            if (user3 == null)
            {
                user3 = new Models.User { UserName = "Jacek", Email = "jacek@example.com", Name = "Jacek W" };
                userManager.CreateAsync(user3, "jacekPass");
            }


            if (!context.UserBoardAffiliations.Any())
            {

                UserBoardAffiliation uba = new UserBoardAffiliation { userId = user.Id, boardId = board1.Id };
                UserBoardAffiliation uba1 = new UserBoardAffiliation { userId = user1.Id, boardId = board1.Id };
                UserBoardAffiliation uba2 = new UserBoardAffiliation { userId = user2.Id, boardId = board1.Id };
                UserBoardAffiliation uba3 = new UserBoardAffiliation { userId = user3.Id, boardId = board1.Id };
            }

        }

     }
}
