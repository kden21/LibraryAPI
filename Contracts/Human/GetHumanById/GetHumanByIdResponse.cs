namespace Contracts.Human.GetHumanById;

public record GetHumanByIdResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string Birthday { get; set; } = null!;
}