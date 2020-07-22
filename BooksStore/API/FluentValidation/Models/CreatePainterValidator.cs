using FluentValidation;
using Model.Entities;

namespace API.FluentValidation.Models
{
    public class CreatePainterValidatior : AbstractValidator<Painter>
    {
        public CreatePainterValidatior()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("Имя не может быть пустым");
            RuleFor(p => p.Name).MaximumLength(20)
                .WithMessage("Название не может превышать 30 символов");
            RuleFor(p => p.Age).InclusiveBetween((byte)1, (byte)90)
                .WithMessage("Возраст имеет диапазон значений от 1 до 90");
            RuleFor(p => p.Style).IsInEnum()
                .WithMessage("Нет такого стиля");
        }
    }
}