using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface INodeRepository
    {
        IEnumerable<Node> Nodes { get; }
        void SaveElement(Node element);
        Base RemoveElement(int id);
    }
}
