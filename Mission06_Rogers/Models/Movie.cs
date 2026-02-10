using System.ComponentModel.DataAnnotations;

namespace Mission06_Rogers.Models;

public class Movie
{
    public int MovieId { get; set; }

    [Required]
    public string Category { get; set; } = "";

    [Required]
    public string Title { get; set; } = "";

    [Required]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; } = "";

    [Required]
    public string Rating { get; set; } = ""; // G PG PG-13 R

    public bool Edited { get; set; } // true or false

    public string? LentTo { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }
}