using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprinter.Models.Shift;

public sealed class Ride : BaseModel
{
    public Ride()
    {

    }

    [Required]
    public DateTime Start { get; internal set; }

    [Required]
    public DateTime End { get; internal set; }

    [Required]
    public string Departure { get; internal set; }

    [Required]
    public string Arrival { get; internal set; }

    [Required]
    public string Country { get; internal set; }
}