using FluentValidation;
using mathgame.Dtos.AccessCode;

namespace mathgame.Controllers.Validators.AccessCode;

public class ResendAccessCodeValidator : AbstractValidator<ResendAccessCodeDTO>
{
    public ResendAccessCodeValidator()
    {
        RuleFor(x => x.UserEmail)
            .NotNull().WithMessage("O campo Email não pode ser nulo.")
            .NotEmpty().WithMessage("O campo Email é obrigatório.")
            .EmailAddress().WithMessage("O campo Email deve conter um endereço de e-mail válido.");
    }
}