using FluentValidation;
using LuxOne.Model.DTO;

namespace ApiTimeJogador_LuxOne.Models.Validacao
{
    public class TimeValidator : AbstractValidator<TimeSalvarDTQ>
    {
        public TimeValidator()
        {
            RuleFor(t => t.Nome)
                .NotEmpty().WithMessage("O Nome do time deve ser preenchido.")
            .Length(3,10).WithMessage("O nome do time deve conter {MinLengt} e no max {MaxLength}");

            RuleFor(t => t.DataInclusao)
                .NotEmpty().WithMessage("A data deve ser preenchida");
               

        }
    }
}
