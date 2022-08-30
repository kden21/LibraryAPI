namespace Contracts.Book.CreateBook;

public record CreateBookRequest
{
    public string? Title { get; set; }
    public DateTime Birthday { get; set; }
    public int YearOfRelease { get; set; }
    public string? PublishingHouse {get; set;}
    public string? Author {get; set;}
    
}