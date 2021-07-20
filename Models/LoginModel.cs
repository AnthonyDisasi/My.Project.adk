using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.Models
{
    public class LoginModel
    {
        [Required, Display(Name = "Matricule")]
        [UIHint("Name")]
        public string Matricule { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
