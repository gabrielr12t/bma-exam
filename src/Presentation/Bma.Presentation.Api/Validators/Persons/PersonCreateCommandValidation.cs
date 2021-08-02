using Bma.Application.Commands.Persons;
using FluentValidation;

namespace Bma.Presentation.Api.Validators.Persons
{
    public class PersonCreateCommandValidation : AbstractValidator<PersonCreateCommand>
    {
        public PersonCreateCommandValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Campo Nome obrigatório")
                .MaximumLength(60).WithMessage("Campo nome deve ter no máximo 60 caracteres");

            RuleFor(p => p.Age)
                .NotEmpty().WithMessage("Campo Idade obrigatório");

            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("Campo Sexo obrigatório");

            RuleFor(p => p.Weight)
                .NotEmpty().WithMessage("Campo Peso obrigatório");
        }
    }
}