using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork<T> where T : class
    {
        Task CommitAsync();
    }
}
