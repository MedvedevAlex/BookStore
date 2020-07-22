using FluentValidation;
using Model.Entities;

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
        }
    }
}