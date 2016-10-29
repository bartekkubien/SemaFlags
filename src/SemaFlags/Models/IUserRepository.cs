using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void SaveUser(User element);
        Base RemoveUser(int id);
    }
}
