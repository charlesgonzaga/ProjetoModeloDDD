using ProjetoModeloDDD.Domain.DTOs;
using ProjetoModeloDDD.Domain.DTOs.InputModels;
using ProjetoModeloDDD.Domain.DTOs.OutputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<ResultViewModel<IEnumerable<PessoaOutputModel>>> ObterTodosAsync();
        Task<ResultViewModel<PessoaOutputModel>> ObterPorIdAsync(int id);
        Task<ResultViewModel<bool>> InsertAsync(PessoaInputModel inputModel);
        Task<ResultViewModel<bool>> AtualizarAsync(PessoaInputModel inputModel);
        Task<ResultViewModel<bool>> DeletarAsync(int id);
    }
}
