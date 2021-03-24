using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginModel
    {
        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı alanını doldurunuz.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifre alanını doldurunuz.")]
        public string Password { get; set; }
    }
}
