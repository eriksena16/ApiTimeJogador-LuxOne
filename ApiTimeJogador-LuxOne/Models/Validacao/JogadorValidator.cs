using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ApiTimeJogador_LuxOne.Models.Validacao
{
    public class JogadorValidator : AbstractValidator<Jogador>
    {
        public JogadorValidator()
        {
            RuleFor(j => j.NomeCompleto)
                .NotEmpty().WithMessage("Nome do Jogador é Obrigatorio")
                .Length(2, 20).WithMessage("O nome do jogador deve conter min {MinLength} e no max {MaxLength}");

            RuleFor(j => j.Idade)
                .NotEmpty().WithMessage("Idade do jogador é obrigatório");

            RuleFor(j => j.TimeID)
                .NotEmpty().WithMessage("O time do jogador é obrigatório");
                
        }
    }
}
