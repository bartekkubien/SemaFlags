using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface IBoardRepo
    {
        IEnumerable<Board> Boards { get; }
        IEnumerable<Group> Groups { get; }
        IEnumerable<Node> Nodes { get; }
        IEnumerable<User> Users { get; }

        void AddElement(Base element);

        void AddBoard(Board board);
        void EditBoard(Board board);
        void DeleteBoard(Board board);
        void AddGroup(Group group);
        void EditGroup(Group group);
        void DeleteGroup(Group group);
        void AddNode(Node node);
        void EditNode(Node node);
        void DeleteNode(Node node);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(User user);


    }
}
