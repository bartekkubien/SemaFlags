using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class Base
    {
        [JsonProperty("Id", Order = 0)]
        [Key]
        public int Id { get; set; }
        [JsonProperty("Name", Order = 1)]
        [Key]
        [Required(ErrorMessage = "Please enter board name!")]
        public string Name { get; set; }
        [JsonProperty("Description", Order = 2)]
        public string Description { get; set; }
        //public int UserId { get; set; }
        [JsonProperty("SequenceNumber",Order = 3)]
        public int SequenceNumber;
        [JsonProperty("Color",Order = 4)]
        public int Color;
    }
}
