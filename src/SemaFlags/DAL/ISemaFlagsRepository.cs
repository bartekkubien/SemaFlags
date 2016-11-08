using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SemaFlags.Models;

namespace SemaFlags.DAL

{
    public interface ISemaFlagsRepository
    {
        IQueryable<Board> Boards { get; }
        void SaveElement(Board element);
        Base RemoveElement(int id);

        IQueryable<Group> Groups { get; }
        void SaveGroup(Group element);
        Base RemoveGroup(int id);

        IQueryable<Node> Nodes { get; }
        void SaveNode(Node element);
        Base RemoveNode(int id);

        IQueryable<User> Users { get; }
        void SaveUser(User element);
        User RemoveUser(string id);
    }
}
