namespace Contracts.Human.CreateHuman;

public record CreateHumanResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string Birthday { get; set; }
}