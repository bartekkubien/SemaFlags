using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public interface IUserRepository
    {
        public IEnumerable<User> Userps { get; }
        public void SaveElement(User element);
        public Base RemoveElement(int id);
    }
}
