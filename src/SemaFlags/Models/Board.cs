using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [Key]
        [Required(ErrorMessage ="Please enter board name!")]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
