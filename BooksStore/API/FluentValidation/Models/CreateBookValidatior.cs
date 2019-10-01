using FluentValidation;
using InterfaceDB.Models;

namespace API.FluentValidation.Models
{
    public class CreateBookValidatior : AbstractValidator<Book>
    {
        public CreateBookValidatior()
        {
            RuleFor(b => b.Name).NotEmpty()
                .WithMessage("Название не может быть пустым");
            RuleFor(b => b.Name).MaximumLength(30)
                .WithMessage("Название не может превышать 30 символов");
            RuleFor(b => b.Cover).IsInEnum()
                .WithMessage("Нет такого переплета");
            RuleFor(b => b.Genre).IsInEnum()
                .WithMessage("Нет такого жанра");
            RuleFor(b => b.Language).IsInEnum()
                .WithMessage("Нет такого языка");
            RuleFor(b => b.Description).MinimumLength(30).MaximumLength(100)
                .WithMessage("Описание имеет диапазон значений от 30 до 100 симовлов");
            RuleFor(b => b.ISBN_10).Matches("[0-9]{10}").MaximumLength(10)
                .WithMessage("Уникальный номер книжного издания старого образца должен содержать 10 цифр");
            RuleFor(b => b.ISBN_13).Matches("[0-9]{13}").MaximumLength(10)
                .WithMessage("Уникальный номер книжного издания нового образца должен содержать 13 цифр");
            RuleFor(b => b.Dimensions).MaximumLength(10)
                .WithMessage("Размер не может превышать 10 символов");
            RuleFor(b => b.NumbersPages).InclusiveBetween(50, 5000)
                .WithMessage("Количество страниц имеет диапазон значений от 50 до 5000 символов");
            RuleFor(b => b.Price).ScalePrecision(2, 7)
                .WithMessage("Цена не может превышать 7 целых и 2 десятичные после запятой");
            RuleFor(b => b.QuantityStock).InclusiveBetween(1, 10000)
                .WithMessage("Количество на складе имеет диапазон значений от 1 до 10000 символов");
            RuleFor(b => b.Edition).InclusiveBetween(1, 1000000)
                .WithMessage("Тираж имеет диапазон значений от 1 до 1000000 символов");
            RuleFor(b => b.AgeLimit).InclusiveBetween((byte)1,(byte)30)
                .WithMessage("Возрастное ограничение имеет диапазон значений от 1 до 30 лет");
            RuleFor(b => b.Weight).ScalePrecision(2, 7)
                .WithMessage("Вес не может превышать 4 целых и 2 десятичные после запятой");
            RuleFor(b => b.CountCustomers).InclusiveBetween(0, 1000000)
                .WithMessage("Количество покупок не может превышать 1000000 символов");
            RuleFor(b => b.AvgReview).ScalePrecision(1, 1)
                .WithMessage("Средняя оценка не может превышать 1 целую и 1 десятичную после запятой");
            RuleFor(b => b.Publisher.PublisherId).NotEmpty()
                .WithMessage("Издатель не может быть пустым");
        }
    }
}