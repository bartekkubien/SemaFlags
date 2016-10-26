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
        [JsonProperty("GroupId", Order = 5)]
        public int GroupId { get; set; }

        [JsonProperty("AssignedUserId", Order = 6)]
        public int AssignedUserId { get; set; }

    }
}
