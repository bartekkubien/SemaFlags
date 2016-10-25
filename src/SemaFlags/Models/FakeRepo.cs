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
        private static List<User> users;
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

                                new Node {Id = 0, GroupId=0,  Name = "Finnish POS", Description="F555P001", AssignedUserId=2 },
                                new Node {Id = 1, GroupId=0,  Name = "Finnish BS", Description="F555S001" },
                                new Node {Id = 2, GroupId=0,  Name = "Swedish POS", Description="H555P001" },
                                new Node {Id = 3, GroupId=0,  Name = "Swedish BS", Description="H555S001" },
                                new Node {Id = 4, GroupId=0,  Name = "Latvian POS", Description="L555P001" },
                                new Node {Id = 5, GroupId=0,  Name = "Latvian BS", Description="L555S001" },
                                new Node {Id = 6, GroupId=0,  Name = "Estonian POS", Description="V555P001" },
                                new Node {Id = 7, GroupId=0,  Name = "Estonian BS", Description="V555S001" },
                                new Node {Id = 8, GroupId=1,  Name = "Finnish POS", Description="F550P001" },
                                new Node {Id = 9, GroupId=1,  Name = "Finnish BS", Description="F550S001" },
                                new Node {Id = 10, GroupId=1,  Name = "Swedish POS", Description="H550P001" },
                                new Node {Id = 11, GroupId=1,  Name = "Swedish BS", Description="H550S001" },
                                new Node {Id = 12, GroupId=1,  Name = "Latvian POS", Description="L550P001" },
                                new Node {Id = 13, GroupId=1,  Name = "Latvian BS", Description="L550S001" },
                                new Node {Id = 14, GroupId=1,  Name = "Estonian POS", Description="V550P001" },
                                new Node {Id = 15, GroupId=1,  Name = "Estonian BS", Description="V550S001" }
                                };
                }
                return nodes;
            }

        }
        public List<User> Users
        {
            get
            {
                if (users == null)
                {
                    users = new List<User> {

                                new User {Id = 1, Name = "Bartek", Description="" },
                                new User {Id = 2, Name = "Tomek", Description="" },
                                new User {Id = 77, Name = "Ania", Description="" },
                                new User {Id = 4, Name = "Paweł", Description="" }
                                };
                }
                return users;
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
            Node editNode = Nodes.FirstOrDefault(g => g.Id == node.Id);
            if (editNode != null)
            {
                editNode.Name = node.Name;
                editNode.Description = node.Description;
            }
        }

        public void DeleteNode(Node node)
        {
            Nodes.Remove(node);
        }

        public void AddUser(User user)
        {
            user.Id = Users.Count() > 0 ? Users.Max(g => g.Id) + 1 : 0;
            Users.Add(user);
        }
        public void EditUser(User user)
        {
            User editUser = Users.FirstOrDefault(u => u.Id == user.Id);
            if (editUser != null)
            {
                editUser.Name = user.Name;
                editUser.Description = user.Description;
            }
        }
        public void DeleteUser(User user)
        {
            Users.Remove(user);
        }
    }
}
