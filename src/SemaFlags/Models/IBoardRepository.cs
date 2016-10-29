using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface IGroupRepository
    {
         IEnumerable<Group> Groups { get; }
         void SaveElement(Group element);
         Base RemoveElement(int id);
    }
}
