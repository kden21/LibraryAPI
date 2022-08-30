using System.ComponentModel.DataAnnotations;

namespace Domain;

public record BookEntity : Entity
{
    [Required, StringLength(200)]
    public string? Title { get; set; } 
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    public int YearOfRelease { get; set; }
    public string? PublishingHouse {get; set;}
    [Required]
    public string? Author {get; set;}
    public int LibraryId { get; set; }
    public LibraryEntity Library { get; set; }
    public List<HumanEntity> Humans { get; set; } = new List<HumanEntity>();
}