using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop_T24_7.Models
{
    public class RegModel
    {
        [Required(ErrorMessage = "Necesar de completat acest spatiu")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "Lungimea caracterului trebuie sa  fie minim 5 maxim 12")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Necesar de completat acest spatiu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Parola nu corespunde")]
        [DataType(DataType.Password)]
        public string RPassword { get; set; }
        [Required(ErrorMessage = "Necesar de completat acest spatiu")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Format email nu este valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Necesar de completat acest spatiu")]
        [RegularExpression("^[0-9]*$")]

        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }


    }
}
