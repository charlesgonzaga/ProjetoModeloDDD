using FluentValidation;
using ProjetoModeloDDD.Domain.DTOs.InputModels;
using System;

namespace ProjetoModeloDDD.Api.FluentValidation
{
    public class PessoaInputModelValidator : AbstractValidator<PessoaInputModel>
    {
        public PessoaInputModelValidator()
        {
            RuleFor(x => x.Nome)
                .Length(3, 20)
                .WithMessage(string.Format(ApiResource.CampoInvalido, "Nome"));

            RuleFor(x => x.DataNascimento)
                .Must(ValidarData)
                .WithMessage(string.Format(ApiResource.CampoInvalido, "DataNascimento"));
        }

        private bool ValidarData(DateTime data)
            => (data.GetType() == typeof(DateTime)) && data != DateTime.Parse("01/01/0001 00:00:00");
    }
}
