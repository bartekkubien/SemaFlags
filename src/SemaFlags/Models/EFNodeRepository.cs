using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class EFNodeRepository : INodeRepository
    {
        private SemaFlagsDBContext context;

        public EFNodeRepository(SemaFlagsDBContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Node> Nodes => context.Nodes;
        public void SaveElement(Node element)
        {

            if (element.Id == 0)

                context.Nodes.Add(element);
            else
            {
                Node dbEntry = context.Nodes.FirstOrDefault(e => e.Id == element.Id);
                if (dbEntry != null) {
                    dbEntry.Name = element.Name;
                    dbEntry.Description = element.Name;
                    dbEntry.Color = element.Color;
                    dbEntry.SequenceNumber = element.SequenceNumber;
                    dbEntry.GroupId = element.GroupId;
                    dbEntry.AssignedUserId = element.AssignedUserId;
                }
            }
            context.SaveChanges();
        }

        public Base RemoveElement(int id)
        {
            Node dbEntry = context.Nodes.FirstOrDefault(e => e.Id == id);
            if (dbEntry != null) {
                context.Nodes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
