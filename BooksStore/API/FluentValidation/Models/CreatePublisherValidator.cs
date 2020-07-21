using FluentValidation;
using Model.Models;

namespace API.FluentValidation.Models
{
    public class CreatePublisherValidatior : AbstractValidator<Publisher>
    {
        public CreatePublisherValidatior()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("Имя не может быть пустым");
            RuleFor(p => p.Name).MaximumLength(20)
                .WithMessage("Имя не может превышать 30 символов");
            RuleFor(p => p.ShortName).MaximumLength(3)
                .WithMessage("Короткое имя не может превышать 3 символа");
            RuleFor(p => p.Corporation).MaximumLength(20)
                .WithMessage("Национальность корпорации не может первышать 30 символов");
        }
    }
}