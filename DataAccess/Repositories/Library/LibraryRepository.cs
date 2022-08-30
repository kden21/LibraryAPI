using System.Linq.Expressions;
using Domain;

namespace DataAccess.Repositories.Library;

public class LibraryRepository : ILibraryRepository
{
    private readonly IRepository<LibraryEntity> _libraryRepository;

    public LibraryRepository(IRepository<LibraryEntity> libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public Task<LibraryEntity> GetByIdAsync(int libraryId, CancellationToken cancellation)
    {
        return _libraryRepository.FindAsync(libraryId, cancellation);
    }

    public IQueryable<LibraryEntity> Where(Expression<Func<LibraryEntity, bool>> predicate)
    {
        return _libraryRepository.Where(predicate);
    }

    public async Task<int> AddAsync(LibraryEntity library, CancellationToken cancellation)
    {
        return await _libraryRepository.AddAsync(library, cancellation);
    }

    public async Task AddRangeAsync(IEnumerable<LibraryEntity> libraries, CancellationToken cancellation)
    {
        await _libraryRepository.AddRangeAsync(libraries, cancellation);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellation)
    {
        await _libraryRepository.DeleteAsync(id, false, cancellation);
    }

    public async Task UpdateAsync(LibraryEntity library, CancellationToken cancellation)
    {
        await _libraryRepository.UpdateAsync(library, cancellation);
    }

    public IQueryable<LibraryEntity> GetAll()
    {
        return _libraryRepository.Query();
    }
}

