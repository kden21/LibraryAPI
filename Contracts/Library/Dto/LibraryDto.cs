namespace Contracts.Library.Dto;

public record LibraryDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string Birthday { get; set; } = null!;
}