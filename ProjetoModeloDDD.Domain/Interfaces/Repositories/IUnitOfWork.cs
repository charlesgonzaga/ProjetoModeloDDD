using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork<TContext>
    {
        Task CommitAsync();
    }
}
