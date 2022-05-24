using Beacon.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beacon.data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private readonly BeaconDbContext _context;

        public Repository(BeaconDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public  IQueryable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>().AsQueryable();
            
            return query;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            return  await query.FirstOrDefaultAsync(expression);
        }

        public async Task Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
