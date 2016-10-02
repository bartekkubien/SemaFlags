using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class FakeRepo : IBoardRepo
    {
        private static List<Board> boards;

        public List<Board> Boards
        {
            get
            {
                if (boards == null)
                {
                    boards = new List<Board> {
                        new Board {Id = 0, Name = "Rauta" , Description="Integration Environment",
                            Groups = new List<Group> {
                                new Group {Id = 0, Name = "Dev", Description="Development machines" },
                                new Group {Id = 1, Name = "QA", Description="QA machines" }
                                }
                        },
                        new Board {Id = 1, Name = "Nordic" ,
                          Groups = new List<Group> {
                                new Group {Id = 0, Name = "Dev", Description="Development machines" },
                                new Group {Id = 1, Name = "QA", Description="QA machines" }
                                }
                        }

                    };
                }
                return boards;
            }
        }

        public void AddBoard(Board board)
        {
            board.Id = Boards.Count() > 0 ? Boards.Max(b => b.Id) + 1 : 0;
            Boards.Add(board);
        }

        public void EditBoard(Board board)
        {
            Board editBoard = Boards.FirstOrDefault(b => b.Id == board.Id);
            if (editBoard != null)
            {
                editBoard.Name = board.Name;
                editBoard.Description = board.Description;
            }

        }

        public void DeleteBoard(Board board)
        {

            Boards.Remove(board);
        }

    }
}
