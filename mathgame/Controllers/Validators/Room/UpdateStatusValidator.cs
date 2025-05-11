using FluentValidation;
using mathgame.Dtos.Room;
using mathgame.Dtos.Enums;

namespace mathgame.Controllers.Validators.Room
{
    public class UpdateStatusValidator : AbstractValidator<UpdateStatusDTO>
    {
        public UpdateStatusValidator()
        {
            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Status informado é inválido. Os valores permitidos são: STARTED, FINISHED.");
        }
    }
}