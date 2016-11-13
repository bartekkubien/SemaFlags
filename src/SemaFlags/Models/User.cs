using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SemaFlags.Models
{
    public class User: IdentityUser<int>
        //, IEquatable<User>
    {
        [JsonProperty("Name", Order = 1)]
        [Required(ErrorMessage = "Please enter board name!")]
        public string Name { get; set; }
        [JsonProperty("Description", Order = 2)]
        public string Description { get; set; }
        //public int UserId { get; set; }
        [JsonProperty("SequenceNumber", Order = 3)]
        public int SequenceNumber;
        [JsonProperty("Color", Order = 4)]
        public int Color;

        //public bool Equals(User other)
        //{
        //    return this.Id.Equals(other.Id);
        //}
    }
}
