using ProjetoModeloDDD.Domain.DTOs.InputModels;
using ProjetoModeloDDD.Domain.DTOs.OutputModels;
using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class PessoaEntity : BaseEntity<int>
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        public PessoaEntity()
        {

        }

        public PessoaEntity(PessoaInputModel inputModel)
        {
            Id = inputModel.Id;
            Nome = inputModel.Nome;
            DataNascimento = inputModel.DataNascimento;
            DataCadastro = DateTime.Now;
        }

        public static explicit operator PessoaOutputModel(PessoaEntity pessoa)
        {
            return new PessoaOutputModel
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                DataNascimento = pessoa.DataNascimento
            };
        }
    }
}
