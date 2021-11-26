using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Text.Json.Serialization;

namespace ProjetoModeloDDD.Domain.DTOs.InputModels
{
    public class PessoaInputModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public static explicit operator PessoaEntity(PessoaInputModel inputModel)
            => new PessoaEntity(inputModel);
    }
}
