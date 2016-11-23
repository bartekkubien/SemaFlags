using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SemaFlags.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }

    }

    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

    }
}
