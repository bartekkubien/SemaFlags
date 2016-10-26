using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SemaFlagsTray.Models
{
    [DataContract]
    public class Node: Base
    {
        
        public Node() {
            AssignedUserId = 0;
        }
        [DataMember(Order = 5)]
        public int GroupId { get; set; }
        [DataMember(Order = 6)]
        public int AssignedUserId { get; set; }

    }
}
