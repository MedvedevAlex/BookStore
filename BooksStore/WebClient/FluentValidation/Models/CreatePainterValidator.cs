using FluentValidation;
using InterfaceDB.Models;

namespace WebClient.FluentValidation.Models
{
    public class CreatePainterValidatior : AbstractValidator<Painter>
    {
        public CreatePainterValidatior()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("Имя не может быть пустым");
            RuleFor(p => p.Name).MaximumLength(20)
                .WithMessage("Название не может превышать 30 символов");
            RuleFor(p => p.Age).NotEmpty()
                .WithMessage("Возраст не может быть пустым");
            //RuleFor(p => p.Age).InclusiveBetween(1, 90)
            //    .WithMessage("Название не может превышать 30 символов")
            RuleFor(p => p.Style).IsInEnum()
                .WithMessage("Стиль имеет диапазон значений, который не включает данное значение");
        }
    }
}