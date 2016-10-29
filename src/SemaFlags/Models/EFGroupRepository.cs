using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class EFGroupRepository : IGroupRepository
    {
        private SemaFlagsDBContext context;

        public EFGroupRepository(SemaFlagsDBContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Group> Groups => context.Groups;
        public void SaveGroup(Group element)
        {

            if (element.Id == 0)

                context.Groups.Add(element);
            else
            {
                Group dbEntry = context.Groups.FirstOrDefault(e => e.Id == element.Id);
                if (dbEntry != null) {
                    dbEntry.Name = element.Name;
                    dbEntry.Description = element.Name;
                    dbEntry.Color = element.Color;
                    dbEntry.BoardId = element.BoardId;
                    dbEntry.SequenceNumber = element.SequenceNumber;
                }
            }
            context.SaveChanges();
        }

        public Base RemoveGroup(int id)
        {
            Group dbEntry = context.Groups.FirstOrDefault(e => e.Id == id);
            if (dbEntry != null) {
                context.Groups.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
