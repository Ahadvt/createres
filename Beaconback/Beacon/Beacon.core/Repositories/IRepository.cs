using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> expression);
        IQueryable<TEntity> GetAll();
        Task Remove(TEntity entity);
        Task<int> CommitAsync();
        int Commit();

    }
}
