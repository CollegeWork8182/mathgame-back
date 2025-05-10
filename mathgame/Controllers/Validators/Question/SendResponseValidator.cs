using FluentValidation;
using mathgame.Dtos.Question;

namespace mathgame.Controllers.Validators.Question;

public class SendResponseValidator : AbstractValidator<SendResponseDTO>
{
    public SendResponseValidator()
    {
        RuleFor(x => x.Response)
            .NotEmpty().WithMessage("A resposta é obrigatório.");
    }
}