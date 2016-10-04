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
        private static List<Node> nodes;
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

                                new Group {Id = 0, BoardId=0,  Name = "Dev", Description="Development machines" },
                                new Group {Id = 1, BoardId=0,  Name = "QA", Description="QA machines" },
                                new Group {Id = 2, BoardId=1,  Name = "Dev", Description="Development machines" },
                                new Group {Id = 3, BoardId=1,  Name = "QA", Description="QA machines" }
                                };
                }
                return groups;
            }

        }
        public List<Node> Nodes
        {
            get
            {
                if (nodes == null)
                {
                    nodes = new List<Node> {

                                new Node {Id = 0, GroupId=0,  Name = "Finnish POS", Description="F555P001" },
                                new Node {Id = 1, GroupId=0,  Name = "Finnish BS", Description="F555S001" },
                                new Node {Id = 2, GroupId=0,  Name = "Swedish POS", Description="H555P001" },
                                new Node {Id = 3, GroupId=0,  Name = "Swedish BS", Description="H555S001" },
                                new Node {Id = 4, GroupId=0,  Name = "Latvian POS", Description="L555P001" },
                                new Node {Id = 5, GroupId=0,  Name = "Latvian BS", Description="L555S001" },
                                new Node {Id = 6, GroupId=0,  Name = "Estonian POS", Description="V555P001" },
                                new Node {Id = 7, GroupId=0,  Name = "Estonian BS", Description="V555S001" }
                                };
                }
                return nodes;
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

        public void AddNode(Node node)
        {
            node.Id = Nodes.Count() > 0 ? Nodes.Max(g => g.Id) + 1 : 0;
            Nodes.Add(node);
        }

        public void EditNode(Node node)
        {
            Node editBoard = Nodes.FirstOrDefault(g => g.Id == node.Id);
            if (editBoard != null)
            {
                editBoard.Name = node.Name;
                editBoard.Description = node.Description;
            }
        }

        public void DeleteNode(Node node)
        {
            Nodes.Remove(node);
        }
    }
}
