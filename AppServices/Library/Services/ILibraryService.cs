using Contracts.Library.CreateLibrary;
using Contracts.Library.DeleteLibrary;
using Contracts.Library.GetLibraries;
using Contracts.Library.GetLibraryById;
using Contracts.Library.UpdateLibrary;

namespace AppServices.Library.Services;

public interface ILibraryService
{
    Task<GetLibrariesResponse> GetHumans(GetLibrariesRequest request, CancellationToken cancellation);
    Task<CreateLibraryResponse> CreateHuman(CreateLibraryRequest request, CancellationToken cancellationToken);
    Task<DeleteLibraryResponse> DeleteHuman(DeleteLibraryRequest request, CancellationToken cancellationToken);
    Task<UpdateLibraryResponse> UpdateHuman(UpdateLibraryRequest request, CancellationToken cancellationToken);
    Task<GetLibraryByIdResponse> GetHumanById(GetLibraryByIdRequest request, CancellationToken cancellation);
}