using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface IGroupRepository
    {
        IEnumerable<Group> Groups { get; }
        void SaveGroup(Group element);
        Base RemoveGroup(int id);
    }
}
