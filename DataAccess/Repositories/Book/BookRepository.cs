using System.Linq.Expressions;
using Domain;

namespace DataAccess.Repositories.Book;

public class BookRepository : IBookRepository
{
    private readonly IRepository<BookEntity> _bookRepository;

    public BookRepository(IRepository<BookEntity> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task<BookEntity> GetByIdAsync(int bookId, CancellationToken cancellation)
    {
        return _bookRepository.FindAsync(bookId, cancellation);
    }

    public IQueryable<BookEntity> Where(Expression<Func<BookEntity, bool>> predicate)
    {
        return _bookRepository.Where(predicate);
    }

    public async Task<int> AddAsync(BookEntity book, CancellationToken cancellation)
    {
        return await _bookRepository.AddAsync(book, cancellation);
    }

    public async Task AddRangeAsync(IEnumerable<BookEntity> books, CancellationToken cancellation)
    {
        await _bookRepository.AddRangeAsync(books, cancellation);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellation)
    {
        await _bookRepository.DeleteAsync(id, false, cancellation);
    }

    public async Task UpdateAsync(BookEntity book, CancellationToken cancellation)
    {
        await _bookRepository.UpdateAsync(book, cancellation);
    }

    public IQueryable<BookEntity> GetAll()
    {
        return _bookRepository.Query();
    }
}

