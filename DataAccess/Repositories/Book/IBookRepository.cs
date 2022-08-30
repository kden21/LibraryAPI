using System.Linq.Expressions;
using Domain;

namespace DataAccess.Repositories;

public interface IBookRepository
{
    Task<BookEntity> GetByIdAsync(int bookId, CancellationToken cancellation);
    IQueryable<BookEntity> Where(Expression<Func<BookEntity, bool>> predicate);
    Task<int> AddAsync(BookEntity birthday, CancellationToken cancellation);
    Task AddRangeAsync(IEnumerable<BookEntity> birthdays, CancellationToken cancellation);
    Task DeleteAsync(int id, CancellationToken cancellation);
    Task UpdateAsync(BookEntity category, CancellationToken cancellation);
    IQueryable<BookEntity> GetAll();
}