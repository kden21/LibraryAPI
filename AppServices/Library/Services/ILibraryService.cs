namespace AppServices.Library.Services;

public interface ILibraryService
{
    Task<GetLibrariesResponse> GetHumans(GetLibrariesRequest request, CancellationToken cancellation);
    Task<CreateLibraryResponse> CreateHuman(CreateLibraryRequest request, CancellationToken cancellationToken);
    Task<DeleteLibraryResponse> DeleteHuman(DeleteLibraryRequest request, CancellationToken cancellationToken);
    Task<UpdateLibraryResponse> UpdateHuman(UpdateLibraryRequest request, CancellationToken cancellationToken);
    Task<GetLibraryByIdResponse> GetHumanById(GetLibraryByIdRequest request, CancellationToken cancellation);
}