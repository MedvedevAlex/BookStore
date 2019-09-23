using FluentValidation;
using InterfaceDB.Models;

namespace WebClient.FluentValidation.Models
{
    public class CreateAuthorValidatior : AbstractValidator<Author>
    {
        public CreateAuthorValidatior()
        {
            RuleFor(b => b.Name).NotEmpty()
                .WithMessage("Имя не может быть пустым");
            RuleFor(b => b.Name).MaximumLength(20)
                .WithMessage("Название не может превышать 30 символов");
            RuleFor(b => b.Age).NotEmpty()
                .WithMessage("Возраст не может быть пустым");
            //RuleFor(b => b.Age).InclusiveBetween(1, 90)
            //    .WithMessage("Название не может превышать 30 символов")
        }
    }
}