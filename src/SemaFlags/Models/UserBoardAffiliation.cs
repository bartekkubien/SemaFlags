using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class UserBoardAffiliation:Base
    {
        public int userId { get; set; }
        public int boardId { get; set; }

    }
}
