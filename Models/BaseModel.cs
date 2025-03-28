using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Sprinter.Models;

[PrimaryKey(nameof(Id))]
public abstract class BaseModel
{   
    protected BaseModel()
    {
        
    }

    protected BaseModel(string id)
    {
        Id = id;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public string Id { get; internal set; }
}