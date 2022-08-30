namespace Contracts.Library.UpdateLibrary;

public record UpdateLibraryResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string Birthday { get; set; } = null!;
}