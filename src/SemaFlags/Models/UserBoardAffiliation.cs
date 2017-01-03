using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class UserBoardAffiliation : Base
    {
        [Required]
        public virtual int userId { get; set; }
        [Required]
        public virtual int boardId { get; set; }

        [DefaultValue("false")]
        public bool isAdmin { get; set; }

    }
}
