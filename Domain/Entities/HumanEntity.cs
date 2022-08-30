using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain;

public record HumanEntity : Entity
{
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    [Required]
    public DateTime Birthday { get; set; }
    [DefaultValue(Enums.Role.Client)]
    public Role? Role { get; set; }
    public List<LibraryEntity> Libraries { get; set; } = new List<LibraryEntity>();
    public List<BookEntity> Books { get; set; } = new List<BookEntity>();
}