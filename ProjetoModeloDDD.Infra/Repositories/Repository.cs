using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Repositories
{
    public class Repository<TEntity, TPK> : IRepository<TEntity, TPK> where TEntity : BaseEntity<TPK>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsnc()
            => await _dbSet.ToListAsync();

        public async Task<TEntity> GetByIdAsync(TPK id)
            => await _dbSet.FindAsync(id);

        public async Task InsertAsync(TEntity entity)
            => await _dbSet.AddAsync(entity);

        public async Task UpdateAsync(TEntity entity)
        {
            /*
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            */

            var result = await _dbSet.FindAsync(entity.Id);
            _context.Entry(result).CurrentValues.SetValues(entity);
        }

        public async Task DeleteAsync(TPK id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
