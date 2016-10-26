﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SemaFlags.Models
{
  
    public class Group : Base
    {
        [JsonProperty("BoardId", Order = 5)]
        public int BoardId { get; set; }

    }
}
