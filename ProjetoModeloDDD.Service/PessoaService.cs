using AutoMapper;
using ProjetoModeloDDD.Domain.DTOs;
using ProjetoModeloDDD.Domain.DTOs.InputModels;
using ProjetoModeloDDD.Domain.DTOs.OutputModels;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ClientesDbContext> _unitOfWork;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(
            IMapper mapper,
            IUnitOfWork<ClientesDbContext> unitOfWork,
            IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<ResultViewModel<IEnumerable<PessoaOutputModel>>> ObterTodosAsync()
        {
            var retorno = new ResultViewModel<IEnumerable<PessoaOutputModel>>();

            var pessoas = await _pessoaRepository.GetAllAsnc();
            if (pessoas.ToList().Count < 1)
                return retorno.AddMessage("Nenhum resultado encontrado!");

            var outputModel = _mapper.Map<IEnumerable<PessoaOutputModel>>(pessoas);
            return retorno.AddResult(outputModel);
        }

        public async Task<ResultViewModel<PessoaOutputModel>> ObterPorIdAsync(int id)
        {
            var retorno = new ResultViewModel<PessoaOutputModel>();

            var pessoa = await _pessoaRepository.GetByIdAsync(id);

            if (pessoa == null)
                return retorno.AddMessage("Nenhum resultado encontrado!");

            return retorno.AddResult((PessoaOutputModel)pessoa);
        }

        public async Task<ResultViewModel<bool>> InsertAsync(PessoaInputModel inputModel)
        {
            await _pessoaRepository.InsertAsync((PessoaEntity)inputModel);
            await _unitOfWork.CommitAsync();
            return new ResultViewModel<bool>(true);
        }

        public async Task<ResultViewModel<bool>> AtualizarAsync(PessoaInputModel inputModel)
        {
            await _pessoaRepository.UpdateAsync((PessoaEntity)inputModel);
            await _unitOfWork.CommitAsync();
            return new ResultViewModel<bool>(true);
        }

        public async Task<ResultViewModel<bool>> DeletarAsync(int id)
        {
            await _pessoaRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return new ResultViewModel<bool>(true);
        }
    }
}
