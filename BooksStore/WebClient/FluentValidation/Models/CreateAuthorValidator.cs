using FluentValidation;
using InterfaceDB.Models;

namespace WebClient.FluentValidation.Models
{
    public class CreateAuthorValidatior : AbstractValidator<Author>
    {
        public CreateAuthorValidatior()
        {
            RuleFor(a => a.Name).NotEmpty()
                .WithMessage("Имя не может быть пустым");
            RuleFor(a => a.Name).MaximumLength(20)
                .WithMessage("Название не может превышать 30 символов");
            RuleFor(a => a.Age).NotEmpty()
                .WithMessage("Возраст не может быть пустым");
            //RuleFor(a => a.Age).InclusiveBetween(1, 90)
            //    .WithMessage("Название не может превышать 30 символов")
        }
    }
}