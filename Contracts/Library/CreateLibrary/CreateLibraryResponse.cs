namespace Contracts.Library.CreateLibrary;

public record CreateLibraryResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string Birthday { get; set; }
}