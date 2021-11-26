using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity, TPK> where TEntity : BaseEntity<TPK>
    {
        Task<IEnumerable<TEntity>> GetAllAsnc();
        Task<TEntity> GetByIdAsync(TPK id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TPK id);
    }
}
