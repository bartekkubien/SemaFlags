using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public static class BoardList
    {
        private static List<Board> boards = new List<Board>();

        public static IEnumerable<Board> Boards {
            get { return boards; }
        }

        public static void AddBoard(Board board)
        {
            boards.Add(board);
        }
    }
}
