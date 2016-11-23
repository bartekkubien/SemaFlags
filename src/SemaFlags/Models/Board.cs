﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class Board : Base
    {
        [JsonProperty("Name", Order = 1)]
        [Required(ErrorMessage = "Please enter board name!")]
        public string Name { get; set; }
        [JsonProperty("Description", Order = 2)]
        public string Description { get; set; }
        //public int UserId { get; set; }
        [JsonProperty("SequenceNumber", Order = 3)]
        public int SequenceNumber { get; set; }
        [JsonProperty("Color", Order = 4)]
        public int Color { get; set; }
        [JsonProperty("BoardOwnerId", Order = 5)]
        public int BoardOwnerId { get; set; }
    }
}
