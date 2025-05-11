using FluentValidation;
using mathgame.Dtos.Room;

namespace mathgame.Controllers.Validators.Room;

public class EnterRoomValidator : AbstractValidator<EnterRoomDTO>
{
    public EnterRoomValidator()
    {
        RuleFor(x => x.accessCode)
            .NotEmpty().WithMessage("O código de acesso é obrigatório.")
            .Length(6).WithMessage("O código de acesso deve ter exatamente 6 caracteres.");
    }
}