using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SemaFlags.Models;
using Microsoft.EntityFrameworkCore;

namespace SemaFlags.DAL
{
    public class UserRepository {
        DbSet<User> context;

        public UserRepository(DbSet<User> ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Elements => context;
        public User RemoveElement(int id)
        {
            User dbEntry = context.FirstOrDefault(e => e.Id == id);
            if (dbEntry != null)
            {
                context.Remove(dbEntry);
                //context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveElement(User element)
        {
            if (element.Id!=0)

                context.Add(element);
            else
            {
                User dbEntry = context.FirstOrDefault(e => e.Id == element.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = element.Name;
                    dbEntry.Description = element.Name;
                    dbEntry.Color = element.Color;
                    dbEntry.SequenceNumber = element.SequenceNumber;
                }
            }
        }
    }
}
