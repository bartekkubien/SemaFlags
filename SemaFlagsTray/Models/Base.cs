using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SemaFlagsTray.Models
{
    [DataContract]
    public class Base
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public string Description { get; set; }
        [DataMember(Order = 3)]
        public int SequenceNumber;
        [DataMember(Order = 4)]
        public int Color;
    }
}
