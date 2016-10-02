using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface IBoardRepo
    {
        List<Board> Boards { get; }

        void AddBoard(Board board);

         void EditBoard(Board board);

        void DeleteBoard(Board board);
    }
}
