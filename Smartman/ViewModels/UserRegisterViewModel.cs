using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smartman.ViewModels
{
    public class UserRegisterViewModel
    {
        public long Id { get; set; }

         [Required]
         [MaxLength(20)]
         public string Name { get; set; }

         [Required]
         [MaxLength(20)]
        public string Surname { get; set; }

         [Required]
         [MaxLength(20)]
        public int Username { get; set; }

         [Required]
         [MaxLength(30)]
        public string  Login { get; set; }

        [Required]
        [MinLength(8)]   
        public string Password { get; set; }

         [Required]
         [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
    }
}