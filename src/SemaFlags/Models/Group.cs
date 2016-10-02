using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class Group
    {

        [Key]
        public int Id { get; set; }
        [Key]
        [Required(ErrorMessage = "Please enter group name!")]
        public string Name { get; set; }
        public string Description { get; set; }

        public int boardId { get; set; }

    }
}
