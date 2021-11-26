using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _context;

        public UnitOfWork(T context)
        {
            _context = context;
        }

        public async Task CommitAsync()
            => await _context.SaveChangesAsync();
    }
}
