using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Models.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Brugernavn er påkrævet")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Adgangskode er påkrævet")]
        [StringLength(100, ErrorMessage = "Adgangskoden skal minimum være {2} karaktere lang", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Adgangskoden og bekræftelsesadgangskoden stemmer ikke overens")]
        public string ConfirmPassword { get; set; }
    }
}
