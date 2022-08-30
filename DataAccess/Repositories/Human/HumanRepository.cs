using System.Linq.Expressions;
using Domain;

namespace DataAccess.Repositories.Human;

public class HumanRepository : IHumanRepository
{
    private readonly IRepository<HumanEntity> _humanRepository;

    public HumanRepository(IRepository<HumanEntity> humanRepository)
    {
        _humanRepository = humanRepository;
    }

    public Task<HumanEntity> GetByIdAsync(int humanId, CancellationToken cancellation)
    {
        return _humanRepository.FindAsync(humanId, cancellation);
    }

    public IQueryable<HumanEntity> Where(Expression<Func<HumanEntity, bool>> predicate)
    {
        return _humanRepository.Where(predicate);
    }

    public async Task<int> AddAsync(HumanEntity human, CancellationToken cancellation)
    {
        return await _humanRepository.AddAsync(human, cancellation);
    }

    public async Task AddRangeAsync(IEnumerable<HumanEntity> humans, CancellationToken cancellation)
    {
        await _humanRepository.AddRangeAsync(humans, cancellation);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellation)
    {
        await _humanRepository.DeleteAsync(id, false, cancellation);
    }

    public async Task UpdateAsync(HumanEntity human, CancellationToken cancellation)
    {
        await _humanRepository.UpdateAsync(human, cancellation);
    }

    public IQueryable<HumanEntity> GetAll()
    {
        return _humanRepository.Query();
    }
}

