using ProjetoModeloDDD.Domain.DTOs.InputModels;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infra;
using ProjetoModeloDDD.Infra.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoModeloDDD.Tests.TestesIntegracao
{
    [Collection(nameof(InMemoryFixture))]
    public class PessoaServiceTests
    {
        private readonly IUnitOfWork<ClientesDbContext> _unitOfWork;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaServiceTests(BaseFixture fixture)
        {
            #region Criando contexto manualmente
            /*
            var builder = new DbContextOptionsBuilder<ExemploSimplesDbContext>();
            builder.UseInMemoryDatabase("BaseEmMemoria01");
            var contextMemory = new ExemploSimplesDbContext(builder.Options);
            */
            #endregion

            //Criando contexto automaticamente
            var contexto = fixture.GerarContexto<ClientesDbContext>();

            _unitOfWork = new UnitOfWork<ClientesDbContext>(contexto);
            _pessoaRepository = new PessoaRepository(contexto);
        }

        [Fact (DisplayName = "TesteRepositorio")]
        [Trait("Testes Integrados", "PessoaService")]
        public async Task TesteRepositorio()
        {
            //Mostra Total
            var totalPessoas = await _pessoaRepository.GetAllAsnc();

            var inputModel = new PessoaInputModel
            {
                Nome = "Charles Gonzaga",
                DataNascimento = DateTime.Parse("1983-11-01")
            };
            var pessoaEntity = new PessoaEntity(inputModel);

            await _pessoaRepository.InsertAsync(pessoaEntity);
            await _unitOfWork.CommitAsync();

            //Mostra Total
            totalPessoas = await _pessoaRepository.GetAllAsnc();

            Assert.True(totalPessoas.Count() > 0);
            Assert.Equal(inputModel.Nome, totalPessoas.FirstOrDefault().Nome);
        }

        [Fact(DisplayName = "TesteService", Skip = "Este teste não está pronto!")]
        [Trait("Testes Integrados", "PessoaService")]
        public void TesteService()
        {
            /*
            var inputModel = new PessoaInputModel
            {
                Nome = "Teste Usuário Um",
                DataNascimento = DateTime.Parse("1983-11-01")
            };

            var pessoas = new List<PessoaOutputModel>();

            var mokIMapper = new Mock<IMapper>().Object;

            var service = new PessoaService(mokIMapper, _unitOfWork, _pessoaRepository);

            await service.InsertAsync(inputModel);
            var retorno = await service.ObterTodosAsync();

            Assert.True(retorno.Result.Count() > 0);
            */
        }
    }
}
