﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class Board
    {
        private List<Group> groups;

        [Key]
        public int Id { get; set; }
        [Key]
        [Required(ErrorMessage ="Please enter board name!")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Group> Groups {
            get {
                if (groups == null)
                {
                    groups = new List<Group>();
                }
                return groups;
            }
            set {
                groups = value;
            }
        }
    

    }
}
