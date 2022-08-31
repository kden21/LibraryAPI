using Contracts.Library.CreateLibrary;
using Contracts.Library.DeleteLibrary;
using Contracts.Library.GetLibraries;
using Contracts.Library.GetLibraryById;
using Contracts.Library.UpdateLibrary;

namespace AppServices.Library.Services;

public interface ILibraryService
{
    Task<GetLibrariesResponse> GetLibraries(GetLibrariesRequest request, CancellationToken cancellation);
    Task<CreateLibraryResponse> CreateLibrary(CreateLibraryRequest request, CancellationToken cancellationToken);
    Task<DeleteLibraryResponse> DeleteLibrary(DeleteLibraryRequest request, CancellationToken cancellationToken);
    Task<UpdateLibraryResponse> UpdateLibrary(UpdateLibraryRequest request, CancellationToken cancellationToken);
    Task<GetLibraryByIdResponse> GetLibraryById(GetLibraryByIdRequest request, CancellationToken cancellation);
}