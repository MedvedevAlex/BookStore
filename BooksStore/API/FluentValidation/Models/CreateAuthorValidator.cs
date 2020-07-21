using FluentValidation;
using Model.Models;

namespace API.FluentValidation.Models
{
    public class CreateAuthorValidatior : AbstractValidator<Author>
    {
        public CreateAuthorValidatior()
        {
            RuleFor(a => a.Name).NotEmpty()
                .WithMessage("Имя не может быть пустым");
            RuleFor(a => a.Name).MaximumLength(20)
                .WithMessage("Название не может превышать 30 символов");
            RuleFor(a => a.Age).InclusiveBetween((byte)1, (byte)90)
                .WithMessage("Возраст имеет диапазон значений от 1 до 90");
        }
    }
}