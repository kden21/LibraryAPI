using Contracts.Library.Dto;

namespace Contracts.Library.GetLibraries;

public record GetLibrariesResponse
{
    public IEnumerable<LibraryDto> Libraries { get; set; } = null!;
}