using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface IBoardRepository 
    {
         IEnumerable<Board> Boards { get; }
         void SaveBoard(Board element);
         Base RemoveBoard(int id);
    }
}
