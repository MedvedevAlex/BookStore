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
using ViewModel.Responses;

namespace Test.Handlers
{
    /// <summary>
    /// Набор тестов для тестирования обработчика данных книга
    /// </summary>
    [TestFixture]
    public class BookHandlerTests
    {
        private readonly IBookHandler _bookHandler;

        public BookHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _bookHandler = _services.GetService<IBookHandler>();
        }

        /// <summary>
        /// Должен обновить книгу
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldUpdateBook()
        {
            // Arrange
            var modifiedBook = new BookModifyModel
            {
                Id = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"),
                Name = "Дом, в котором… ничего не происходит",
                PublishDate = DateTime.Parse("2018-12-01"),
                CoverTypeId = Guid.Parse("FC4519DF-A67D-4686-904B-4EE105F37D22"),
                GenreId = Guid.Parse("7CF21233-4CAF-4902-BCC1-85A677BF1C59"),
                LanguageId = Guid.Parse("AE0CF116-C244-4997-93CD-F7760A93FE0F"),
                Description = "На окраине города, среди стандартных новостроек, стоит Серый Дом," +
                " в котором живут Сфинкс, Слепой, Лорд, Табаки, Македонский, Черный и многие другие.",
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
                Id = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"),
                Name = "Дом, в котором… ничего не происходит",
                PublishDate = DateTime.Parse("2018-12-01"),
                CoverType = "Мягкая картонная",
                Genre = "Ужасы",
                Language = "Японский",
                Description = "На окраине города, среди стандартных новостроек, стоит Серый Дом," +
                " в котором живут Сфинкс, Слепой, Лорд, Табаки, Македонский, Черный и многие другие.",
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
                        Name = "Рембрандт Харменс ван Рейн"
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
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(book);
        }

        /// <summary>
        /// Должен удалить книгу
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldDeleteBook()
        {
            // Arrange
            var guid = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC");
            var baseResponse = new BaseResponse();
            // Act
            var result = await _bookHandler.DeleteAsync(guid);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(baseResponse);
        }

        /// <summary>
        /// Должен добавить книгу
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task ShouldAddBook()
        {
            // Arrange
            var modifiedBook = new BookModifyModel
            {
                Id = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"),
                Name = "Дом, в котором…",
                PublishDate = DateTime.Parse("22.09.2016"),
                CoverTypeId = Guid.Parse("56D180CA-F9BD-4DAD-87EF-AF334F636BE1"),
                GenreId = Guid.Parse("7CF21233-4CAF-4902-BCC1-85A677BF1C59"),
                LanguageId = Guid.Parse("8D13A346-389B-48B3-9299-A565BF2A6658"),
                Description = "На окраине города, среди стандартных новостроек, стоит Серый Дом, " +
                "в котором живут Сфинкс, Слепой, Лорд, Табаки, Македонский, Черный и многие другие.",
                ISBN_13 = "978-5-904584-69-6",
                Format = "22 x 15 x 5",
                CountPage = 960,
                Price = 605.00M,
                Weight = 1050,
                Duplicate = 15000,
                AgeLimit = 12,
                PublisherId = Guid.Parse("3F755440-89BF-4335-99A7-DB1D9226D666"),
                AuthorsIds = new List<Guid>() { Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7") },
                PaintersIds = new List<Guid>() { Guid.Parse("549903F5-66AB-48E8-B126-8610C4BB08B9") },
                InterpretersIds = new List<Guid>() { Guid.Parse("9A46E40F-57DC-465C-8D2B-67EDF3CF5B4E") },
            };
            var book = new BookViewModel
            {
                Id = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"),
                Name = "Дом, в котором…",
                PublishDate = DateTime.Parse("22.09.2016"),
                CoverType = "Твердая бумажная",
                Genre = "Ужасы",
                Language = "Французский",
                Description = "На окраине города, среди стандартных новостроек, стоит Серый Дом, " +
                "в котором живут Сфинкс, Слепой, Лорд, Табаки, Македонский, Черный и многие другие.",
                ISBN_13 = "978-5-904584-69-6",
                Format = "22 x 15 x 5",
                CountPage = 960,
                Price = 605.00M,
                Weight = 1050,
                Duplicate = 15000,
                AgeLimit = 12,
                Publisher = new PublisherShortModel
                {
                    Id = Guid.Parse("3F755440-89BF-4335-99A7-DB1D9226D666"),
                    Name = "Амфора"
                },
                Authors = new List<AuthorShortModel>
                {
                    new AuthorShortModel
                    {
                        Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                        Name = "Антуан де Сент-Экзюпери"
                    }
                },
                Painters = new List<PainterShortModel>
                {
                    new PainterShortModel
                    {
                        Id = Guid.Parse("549903F5-66AB-48E8-B126-8610C4BB08B9"),
                        Name = "Рембрандт Харменс ван Рейн"
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
            var result = await _bookHandler.AddAsync(modifiedBook);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(book);
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
                Id = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"),
                Name = "Дом, в котором…",
                PublishDate = DateTime.Parse("22.09.2016"),
                CoverType = "Твердая бумажная",
                Genre = "Ужасы",
                Language = "Французский",
                Description = "На окраине города, среди стандартных новостроек, стоит Серый Дом, " +
                "в котором живут Сфинкс, Слепой, Лорд, Табаки, Македонский, Черный и многие другие.",
                ISBN_13 = "978-5-904584-69-6",
                Format = "22 x 15 x 5",
                CountPage = 960,
                Price = 605.00M,
                Weight = 1050,
                Duplicate = 15000,
                AgeLimit = 12,
                Publisher = new PublisherShortModel
                {
                    Id = Guid.Parse("3F755440-89BF-4335-99A7-DB1D9226D666"),
                    Name = "Амфора"
                },
                Authors = new List<AuthorShortModel>
                {
                    new AuthorShortModel
                    {
                        Id = Guid.Parse("BC72FAF4-F5EA-41B4-B85B-835731BDB0F7"),
                        Name = "Антуан де Сент-Экзюпери"
                    }
                },
                Painters = new List<PainterShortModel>
                {
                    new PainterShortModel
                    {
                        Id = Guid.Parse("549903F5-66AB-48E8-B126-8610C4BB08B9"),
                        Name = "Рембрандт Харменс ван Рейн"
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
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(book);
        }

        /// <summary>
        /// Должен получить пагинацией 3 книги
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetAndSkipBooks()
        {
            // Act
            var resultWithTaked = await _bookHandler.GetAsync(3, 0);
            var resultWithSkipped = await _bookHandler.GetAsync(3, 3);
            // Assert
            resultWithTaked.PreviewBooks.Should().NotBeNull();
            resultWithTaked.PreviewBooks.Count.Should().Be(3);

            resultWithSkipped.PreviewBooks.Should().NotBeNull();
            resultWithSkipped.PreviewBooks.Count.Should().Be(3);

            resultWithTaked.PreviewBooks.Should().NotBeEquivalentTo(resultWithSkipped.PreviewBooks);
        }

        /// <summary>
        /// Должен найти книги по автору
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldSearchBooksByAuthor()
        {
            // Act
            var result = await _bookHandler.SearchByAuthorAsync("Эрих", 2, 1);
            // Assert
            result.PreviewBooks.Should().NotBeNull();
            result.PreviewBooks.Count.Should().Be(2);
            result.Count.Should().Be(3);
        }

        /// <summary>
        /// Должен найти книги по названию
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldSearchBooksByName()
        {
            // Act
            var result = await _bookHandler.SearchByNameAsync("ди", 2, 1);
            // Assert
            result.PreviewBooks.Should().NotBeNull();
            result.PreviewBooks.Count.Should().Be(2);
            result.Count.Should().Be(3);
        }

        /// <summary>
        /// Должен найти книги по жанру
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldSearchBooksByGenre()
        {
            // Act
            var result = await _bookHandler.SearchByGenreAsync("Антиутопия", 1, 1);
            // Assert
            result.PreviewBooks.Should().NotBeNull();
            result.PreviewBooks.Count.Should().Be(1);
            result.Count.Should().Be(2);
        }
    }
}