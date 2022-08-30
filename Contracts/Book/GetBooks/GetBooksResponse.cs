using Contracts.Book.Dto;

namespace Contracts.Book.GetBooks;

public record GetBooksResponse
{
    public IEnumerable<BookDto> Books { get; set; } = null!;
}