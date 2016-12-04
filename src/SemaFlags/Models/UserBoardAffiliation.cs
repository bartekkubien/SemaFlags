using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class UserBoardAffiliation : Base
    {
        [Required]
        //[ForeignKey("UserKey")]
        public virtual int userId { get; set; }
        [Required]
       // [ForeignKey("BoardKey")]
        public virtual int boardId { get; set; }

        //public virtual User UserKey { get; set; }
        //public virtual Board BoardKey { get; set; }
    }
}
