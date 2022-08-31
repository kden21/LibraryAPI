using Contracts.Library.CreateLibrary;
using Contracts.Library.DeleteLibrary;
using Contracts.Library.GetLibraries;
using Contracts.Library.GetLibraryById;
using Contracts.Library.UpdateLibrary;

namespace AppServices.Library.Services;

public class LibraryService : ILibraryService
{
    public Task<GetLibrariesResponse> GetLibraries(GetLibrariesRequest request, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<CreateLibraryResponse> CreateLibrary(CreateLibraryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteLibraryResponse> DeleteLibrary(DeleteLibraryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateLibraryResponse> UpdateLibrary(UpdateLibraryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<GetLibraryByIdResponse> GetLibraryById(GetLibraryByIdRequest request, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}