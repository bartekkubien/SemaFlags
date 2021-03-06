﻿using Newtonsoft.Json;
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
        [JsonProperty("GroupId", Order = 5)]
        public virtual int GroupId { get; set; }

        [JsonProperty("AssignedUserId", Order = 6)]
        public virtual int AssignedUserId { get; set; }

    }
}
