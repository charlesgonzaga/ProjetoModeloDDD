using ProjetoModeloDDD.Domain.DTOs.InputModels;
using ProjetoModeloDDD.Domain.DTOs.OutputModels;
using ProjetoModeloDDD.Domain.Entities;
using System;
using Xunit;

namespace ProjetoModeloDDD.Tests.TestesUnitarios
{
    public class PessoaEntityTests
    {
        [Fact (DisplayName = "ConvertePessoaEntityParaPessoaOutputModel_Sucesso")]
        [Trait("Testes Unitarios", "PessoaEntity")]
        public void ConvertePessoaEntityParaPessoaOutputModel_Sucesso()
        {
            var inputModel = new PessoaInputModel
            {
                Nome = "Charles Gonzaga",
                DataNascimento = DateTime.Parse("1983-11-01")
            };

            var pessoaEntity = new PessoaEntity(inputModel);
            var pessoaOutput = (PessoaOutputModel)pessoaEntity;

            Assert.Equal(typeof(PessoaOutputModel), pessoaOutput.GetType());
        }
    }
}
