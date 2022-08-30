using System.Linq.Expressions;
using Domain;

namespace DataAccess.Repositories.Library;

public interface ILibraryRepository
{
    Task<LibraryEntity> GetByIdAsync(int libraryId, CancellationToken cancellation);
    IQueryable<LibraryEntity> Where(Expression<Func<LibraryEntity, bool>> predicate);
    Task<int> AddAsync(LibraryEntity birthday, CancellationToken cancellation);
    Task AddRangeAsync(IEnumerable<LibraryEntity> birthdays, CancellationToken cancellation);
    Task DeleteAsync(int id, CancellationToken cancellation);
    Task UpdateAsync(LibraryEntity category, CancellationToken cancellation);
    IQueryable<LibraryEntity> GetAll();
}