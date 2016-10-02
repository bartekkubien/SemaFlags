using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class FakeRepo : IBoardRepo
    {
        private static List<Board> boards;
        private static List<Group> groups;
        public List<Board> Boards
        {
            get
            {
                if (boards == null)
                {
                    boards = new List<Board> {
                        new Board {Id = 0, Name = "Rauta" , Description="Integration Environment" },
                        new Board {Id = 1, Name = "Nordic" }

                    };
                }
                return boards;
            }
        }

        public List<Group> Groups
        {
            get
            {
                if (groups == null)
                {
                    groups = new List<Group> {

                                new Group {Id = 0, boardId=0,  Name = "Dev", Description="Development machines" },
                                new Group {Id = 1, boardId=0,  Name = "QA", Description="QA machines" },
                                new Group {Id = 2, boardId=1,  Name = "Dev", Description="Development machines" },
                                new Group {Id = 3, boardId=1,  Name = "QA", Description="QA machines" }
                                };
                }
                return groups;
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

        public void AddGroup(Group group)
        {
            group.Id = Groups.Count() > 0 ? Groups.Max(g => g.Id) + 1 : 0;
            Groups.Add(group);
        }

        public void EditGroup(Group group)
        {
            Group editBoard = Groups.FirstOrDefault(g => g.Id == group.Id);
            if (editBoard != null)
            {
                editBoard.Name = group.Name;
                editBoard.Description = group.Description;
            }
        }

        public void DeleteGroup(Group group)
        {
            Groups.Remove(group);
        }
    }
}
