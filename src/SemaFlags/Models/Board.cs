using Newtonsoft.Json;
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
        public virtual string Name { get; set; }
        [JsonProperty("Description", Order = 2)]
        public virtual string Description { get; set; }
        //public int UserId { get; set; }
        [JsonProperty("SequenceNumber", Order = 3)]
        public virtual int SequenceNumber { get; set; }
        [JsonProperty("Color", Order = 4)]
        public virtual int Color { get; set; }
        public virtual User UserKey { get; set; }
        public virtual ICollection<UserBoardAffiliation> UserAffiliations { get; set; }
    }
}
