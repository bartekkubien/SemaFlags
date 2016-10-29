using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class EFUserRepository : IUserRepository
    {
        private SemaFlagsDBContext context;

        public EFUserRepository(SemaFlagsDBContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<User> Users => context.Users;
        public void SaveElement(User element)
        {

            if (element.Id == 0)

                context.Users.Add(element);
            else
            {
                User dbEntry = context.Users.FirstOrDefault(e => e.Id == element.Id);
                if (dbEntry != null) {
                    dbEntry.Name = element.Name;
                    dbEntry.Description = element.Name;
                    dbEntry.Color = element.Color;
                    dbEntry.SequenceNumber = element.SequenceNumber;
                }
            }
            context.SaveChanges();
        }

        public Base RemoveElement(int id)
        {
            User dbEntry = context.Users.FirstOrDefault(e => e.Id == id);
            if (dbEntry != null) {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
