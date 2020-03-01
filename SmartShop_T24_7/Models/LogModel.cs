using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop_T24_7.Models
{
    public class LogModel
    {
        [Required(ErrorMessage = "Necesar de completat acest spatiu")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Necesar de completat acest spatiu")]

        public string Password { get; set; }
    }
}
