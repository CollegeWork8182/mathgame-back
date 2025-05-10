using FluentValidation;
using mathgame.Dtos.Room;
using mathgame.Dtos.Enums;

namespace mathgame.Controllers.Validators.Room
{
    public class CreateRoomValidator : AbstractValidator<CreateRoomDTO>
    {
        public CreateRoomValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(250).WithMessage("A descrição deve ter no máximo 250 caracteres.");

            RuleFor(x => x.Operation)
                .Must(op => Enum.IsDefined(typeof(OperationType), op))
                .WithMessage("A operação informada é inválida. Valores permitidos: ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION.");

            RuleFor(x => x.Difficulty)
                .Must(diff => Enum.IsDefined(typeof(DifficultyType), diff))
                .WithMessage("A dificuldade informada é inválida. Valores permitidos: EASY, MEDIUM, HARD.");
        }
    }
}