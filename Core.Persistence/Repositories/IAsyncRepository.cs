using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<TEntity, TEntityId> 
    where TEntity : Entity<TEntityId>
{
    Task<TEntity?> GetAsync (
        Expression<Func<TEntity, bool>> predicate, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false
            );

}

