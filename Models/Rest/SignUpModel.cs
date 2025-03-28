using System.ComponentModel.DataAnnotations;

namespace Sprinter.Models.Rest;

public sealed class SignUpModel
{
    public SignUpModel()
    {
        
    }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Avatar is required.")]
    public IFormFile Avatar { get; set; }
}
