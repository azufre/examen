using System.ComponentModel.DataAnnotations;

namespace TerminalBus.Core.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Passoword is required")]
        public string Password { get; set; }
    }
}
