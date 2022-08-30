namespace Contracts.Human.CreateHuman;

public record CreateHumanRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string Birthday { get; set; }
    
}