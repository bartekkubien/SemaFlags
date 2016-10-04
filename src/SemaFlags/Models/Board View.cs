using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class BoardView : Board
    {
        public List<Group> Groups;
    }
}
