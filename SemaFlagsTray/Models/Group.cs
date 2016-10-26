using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SemaFlagsTray.Models
{
    [DataContract]
    public class Group : Base
    {
        [DataMember(Order = 5)]
        public int BoardId { get; set; }

    }
}
