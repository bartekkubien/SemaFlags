using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class Node: Base
    {
        public Node() {
            AssignedUserId = 0;
        }
        public int GroupId { get; set; }
    
        public int AssignedUserId { get; set; }

    }
}
