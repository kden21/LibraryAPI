using Contracts.Book.CreateBook;
using Contracts.Book.DeleteBook;
using Contracts.Book.GetBookById;
using Contracts.Book.GetBooks;
using Contracts.Book.UpdateBook;

namespace AppServices.Book.Services;

public interface IBookService
{
    Task<GetBooksResponse> GetBooks(GetBooksRequest request, CancellationToken cancellation);
    Task<CreateBookResponse> CreateBook(CreateBookRequest request, CancellationToken cancellationToken);
    Task<DeleteBookResponse> DeleteBook(DeleteBookRequest request, CancellationToken cancellationToken);
    Task<UpdateBookResponse> UpdateBook(UpdateBookRequest request, CancellationToken cancellationToken);
    Task<GetBookByIdResponse> GetBookById(GetBookByIdRequest request, CancellationToken cancellation);
}