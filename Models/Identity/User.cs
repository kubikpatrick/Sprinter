using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace Sprinter.Models.Identity;

public sealed class User : IdentityUser
{
    public User()
    {

    }

    [StringLength(32)]
    [Required]
    [PersonalData]
    public string FirstName { get; internal set; }

    [StringLength(32)]
    [Required]
    [PersonalData]
    public string LastName { get; internal set; }

    [Required]
    public string Avatar { get; internal set; }

    [Required]
    public DateTime CreatedAt { get; internal set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}