using System;

namespace ProjetoModeloDDD.Domain.DTOs.OutputModels
{
    public class PessoaOutputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
