using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class EFBoardRepository : IBoardRepository
    {
        private SemaFlagsDBContext context;

        public EFBoardRepository(SemaFlagsDBContext ctx)
        {
            context = ctx;
        }
       public IEnumerable<Board> Boards => context.Boards;
        public void SaveBoard(Board element)
        {

            if (element.Id == 0)

                context.Boards.Add(element);
            else
            {
                Board dbEntry = context.Boards.FirstOrDefault(e => e.Id == element.Id);
                if (dbEntry != null) {
                    dbEntry.Name = element.Name;
                    dbEntry.Description = element.Name;
                    dbEntry.Color = element.Color;
                    dbEntry.SequenceNumber = element.SequenceNumber;
                }
            }
            context.SaveChanges();
        }

        public Base RemoveBoard(int id)
        {
            Board dbEntry = context.Boards.FirstOrDefault(e => e.Id == id);
            if (dbEntry != null) {
                context.Boards.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
