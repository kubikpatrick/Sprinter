using System.ComponentModel.DataAnnotations;

namespace Sprinter.Models.Rest;

public sealed class LoginModel
{
    public LoginModel()
    {

    }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; } = false;
}
