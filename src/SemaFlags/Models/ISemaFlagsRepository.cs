using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface ISemaFlagsRepository
    {
        IEnumerable<Board> Boards { get; }
        void SaveBoard(Board element);
        Base RemoveBoard(int id);

        IEnumerable<Group> Groups { get; }
        void SaveGroup(Group element);
        Base RemoveGroup(int id);

        IEnumerable<Node> Nodes { get; }
        void SaveNode(Node element);
        Base RemoveNode(int id);

        IEnumerable<User> Users { get; }
        void SaveUser(User element);
        Base RemoveUser(int id);
    }
}
