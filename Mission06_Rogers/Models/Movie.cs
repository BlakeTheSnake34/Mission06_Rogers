using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Rogers.Models;

public class Movie
{
    public int MovieId { get; set; }

    [NotMapped]
    public string? Category { get; set; }

    [Required]
    public string Title { get; set; } = "";

    [Required]
    [Range(1888, 3000)]
    public int Year { get; set; }

    public string? Director { get; set; }
    public string? Rating { get; set; } = "";

    [Required]
    public bool Edited { get; set; }

    [Required]
    public bool CopiedToPlex { get; set; }

    public string? LentTo { get; set; }
}