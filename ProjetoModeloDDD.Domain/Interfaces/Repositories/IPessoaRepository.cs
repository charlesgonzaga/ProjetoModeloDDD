using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IRepository<PessoaEntity, int>
    {
        Task<IEnumerable<PessoaEntity>> SelecionarParaTeste();
    }
}
