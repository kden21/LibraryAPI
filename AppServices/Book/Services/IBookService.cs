namespace AppServices.Book.Services;

public interface IBookService
{
    Task<GetBooksResponse> GetHumans(GetBooksRequest request, CancellationToken cancellation);
    Task<CreateBookResponse> CreateHuman(CreateBookRequest request, CancellationToken cancellationToken);
    Task<DeleteBookResponse> DeleteHuman(DeleteBookRequest request, CancellationToken cancellationToken);
    Task<UpdateBookResponse> UpdateHuman(UpdateBookRequest request, CancellationToken cancellationToken);
    Task<GetBookByIdResponse> GetHumanById(GetBookByIdRequest request, CancellationToken cancellation);
}