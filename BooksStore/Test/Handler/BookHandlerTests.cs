using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.Interpreters;
using ViewModel.Models.Painters;
using ViewModel.Models.Publishers;

namespace Test.Handler
{
    /// <summary>
    /// Набор тестов для тестирования обработчика данных книга
    /// </summary>
    [TestFixture]
    public class BookHandlerTests
    {
        private readonly IServiceProvider _services;
        private readonly IBookHandler _bookHandler;

        public BookHandlerTests()
        {
            _services = ConfigDI.GetServiceProvider();
            _bookHandler = _services.GetService<IBookHandler>();
        }

        /// <summary>
        /// Должен получить книгу
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetBook()
        {
            // Arrange
            var book = new BookViewModel
            {
                Id = Guid.Parse("D22D44A7-E987-4F8F-8CB2-0768CC6199C6"),
                Name = "Вторая жизнь Уве",
                PublishDate = DateTime.Parse("2017-11-01"),
                CoverType = "Твердая стеклянная",
                Genre = "Мемуары",
                Language = "Бразильский",
                Description = "На первый взгляд Уве — самый угрюмый человек на свете. Он, как и многие из нас, " +
                "полагает, что его окружают преимущественно идиоты — соседи, которые неправильно паркуют свои " +
                "машины; продавцы в магазине, говорящие на птичьем языке; бюрократы, портящие жизнь нормальным людям.",
                ISBN_13 = "978-5-905891-97-7",
                Format = "20.5 x 13 x 2.4",
                CountPage = 384,
                Price = 406.00M,
                Weight = 400,
                Duplicate = 5000,
                AgeLimit = 14,
                Publisher = new PublisherShortModel
                {
                    Id = Guid.Parse("3F755440-89BF-4335-99A7-DB1D9226D666"),
                    Name = "Амфора"
                },
                Authors = new List<AuthorShortModel>
                {
                    new AuthorShortModel
                    {
                        Id = Guid.Parse("6B6F819C-2A9D-4EF9-92DD-55F69097F36C"),
                        Name = "Эрих Мария Ремарк"
                    }
                },
                Painters = new List<PainterShortModel>
                {
                    new PainterShortModel
                    {
                        Id = Guid.Parse("549903F5-66AB-48E8-B126-8610C4BB08B9"),
                        Name = "Рембрандт Ха?рменс ван Рейн"
                    }
                },
                Interpreters = new List<InterpreterShortModel>
                {
                    new InterpreterShortModel
                    {
                        Id = Guid.Parse("9A46E40F-57DC-465C-8D2B-67EDF3CF5B4E"),
                        Name = "Рита Райт-Ковалева"
                    }
                }
            };
            // Act
            var result = await _bookHandler.GetAsync(book.Id);
            // Assert
            result.Should().BeEquivalentTo(book);
        }

        /// <summary>
        /// Должен обновить книгу
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldUpdateBook()
        {
            // Arrange
            var modifiedBook = new BookModifyModel
            {
                Id = Guid.Parse("D22D44A7-E987-4F8F-8CB2-0768CC6199C6"),
                Name = "Третья жизнь Уве",
                PublishDate = DateTime.Parse("2018-12-01"),
                CoverTypeId = Guid.Parse("FC4519DF-A67D-4686-904B-4EE105F37D22"),
                GenreId = Guid.Parse("7CF21233-4CAF-4902-BCC1-85A677BF1C59"),
                LanguageId = Guid.Parse("AE0CF116-C244-4997-93CD-F7760A93FE0F"),
                Description = "Кто же он такой, этот самый Уве? Пожилой въедливый ворчун, достающий соседей вечными " +
                "придирками. Он впадает в ярость при виде брошенного не туда мусора или неправильно припаркованной машины.",
                ISBN_13 = "978-5-999999-97-7",
                Format = "22.5 x 14 x 2.4",
                CountPage = 532,
                Price = 466.00M,
                Weight = 300,
                Duplicate = 34000,
                AgeLimit = 8,
                PublisherId = Guid.Parse("B9AF4688-E273-4676-A92A-656023A2D216"),
                AuthorsIds = new List<Guid>() { Guid.Parse("6B6F819C-2A9D-4EF9-92DD-55F69097F36C") },
                PaintersIds = new List<Guid>() { Guid.Parse("549903F5-66AB-48E8-B126-8610C4BB08B9") },
                InterpretersIds = new List<Guid>() { Guid.Parse("9A46E40F-57DC-465C-8D2B-67EDF3CF5B4E") },
            };
            var book = new BookViewModel
            {
                Id = Guid.Parse("D22D44A7-E987-4F8F-8CB2-0768CC6199C6"),
                Name = "Третья жизнь Уве",
                PublishDate = DateTime.Parse("2018-12-01"),
                CoverType = "Мягкая картонная",
                Genre = "Ужасы",
                Language = "Японский",
                Description = "Кто же он такой, этот самый Уве? Пожилой въедливый ворчун, достающий соседей вечными " +
                "придирками. Он впадает в ярость при виде брошенного не туда мусора или неправильно припаркованной машины.",
                ISBN_13 = "978-5-999999-97-7",
                Format = "22.5 x 14 x 2.4",
                CountPage = 532,
                Price = 466.00M,
                Weight = 300,
                Duplicate = 34000,
                AgeLimit = 8,
                Publisher = new PublisherShortModel
                {
                    Id = Guid.Parse("B9AF4688-E273-4676-A92A-656023A2D216"),
                    Name = "Рипол Классик"
                },
                Authors = new List<AuthorShortModel>
                {
                    new AuthorShortModel
                    {
                        Id = Guid.Parse("6B6F819C-2A9D-4EF9-92DD-55F69097F36C"),
                        Name = "Эрих Мария Ремарк"
                    }
                },
                Painters = new List<PainterShortModel>
                {
                    new PainterShortModel
                    {
                        Id = Guid.Parse("549903F5-66AB-48E8-B126-8610C4BB08B9"),
                        Name = "Рембрандт Ха?рменс ван Рейн"
                    }
                },
                Interpreters = new List<InterpreterShortModel>
                {
                    new InterpreterShortModel
                    {
                        Id = Guid.Parse("9A46E40F-57DC-465C-8D2B-67EDF3CF5B4E"),
                        Name = "Рита Райт-Ковалева"
                    }
                }
            };
            // Act
            var result = await _bookHandler.UpdateAsync(modifiedBook);
            // Assert
            result.Should().BeEquivalentTo(book);
        }
    }
}