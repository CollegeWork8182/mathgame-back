using mathgame.Dtos.User;
using FluentValidation;

namespace mathgame.Controllers.Validators.User;

public class CreateUserValidator : AbstractValidator<CreateUserDTO>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MinimumLength(2).WithMessage("Nome deve ter pelo menos 2 caracteres");

        RuleFor(x => x.Email)
            .NotNull().WithMessage("O campo Email não pode ser nulo.")
            .NotEmpty().WithMessage("O campo Email é obrigatório.")
            .EmailAddress().WithMessage("O campo Email deve conter um endereço de e-mail válido.");
        
        RuleFor(x => x.Password)
            .NotNull().WithMessage("O campo Password não pode ser nulo.")
            .NotEmpty().WithMessage("A senha é obrigatório")
            .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres");

        RuleFor(x => x.Role)
            .NotNull().WithMessage("O campo Role não pode ser nulo.")
            .NotEmpty().WithMessage("O campo Role é obrigatório.")
            .Must(role => role.ToString() == "ADMIN" || role.ToString() == "PROFESSOR" || role.ToString() == "STUDENT")
            .WithMessage("O campo Role deve ser ADMIN, RECEPTIONTEAM, DOCTOR, NURSE ou INTITUATIONMANAGEMENT");
    }
}