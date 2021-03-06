﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SemaFlags.Models
{

    public class Group : Base
    {
        [JsonProperty("Name", Order = 1)]
        [Required(ErrorMessage = "Please enter board name!")]
        public virtual string Name { get; set; }
        [JsonProperty("Description", Order = 2)]
        public virtual string Description { get; set; }
        //public int UserId { get; set; }
        [JsonProperty("SequenceNumber", Order = 3)]
        public virtual int SequenceNumber { get; set; }
        [JsonProperty("Color", Order = 4)]
        public virtual int Color { get; set; }
        [ForeignKey("BoardKey")]
        [Required(ErrorMessage = "Board does not exist!")]
        [JsonProperty("BoardId", Order = 5)]
        public virtual int BoardId { get; set; }
        public virtual Board BoardKey { get; set;}
    }
}
