using System.Linq.Expressions;
using Domain;

namespace AppServices.Shared;

public interface IHumanRepository
{
    Task<HumanEntity> GetByIdAsync(int humanId, CancellationToken cancellation);
    IQueryable<HumanEntity> Where(Expression<Func<HumanEntity, bool>> predicate);
    Task<int> AddAsync(HumanEntity birthday, CancellationToken cancellation);
    Task AddRangeAsync(IEnumerable<HumanEntity> birthdays, CancellationToken cancellation);
    Task DeleteAsync(int id, CancellationToken cancellation);
    Task UpdateAsync(HumanEntity category, CancellationToken cancellation);
    IQueryable<HumanEntity> GetAll();
}