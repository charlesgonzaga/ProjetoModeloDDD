using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Repositories
{
    public class PessoaRepository : Repository<PessoaEntity, int>, IPessoaRepository
    {
        public PessoaRepository(ClientesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PessoaEntity>> SelecionarParaTeste()
        {
            var x = await _dbSet.ToListAsync();

            return x;
        }
    }
}
