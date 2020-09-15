using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.Painters;
using ViewModel.Responses;

namespace Test.Handlers
{
    /// <summary>
    /// Набор тестов для тестирования обработчика данных художник
    /// </summary>
    [TestFixture]
    public class PainterHadlerTests
    {
        private readonly IPainterHandler _painterHandler;
        private Guid _createPainterId;

        public PainterHadlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _painterHandler = _services.GetService<IPainterHandler>();
        }

        /// <summary>
        /// Должен добавить художника
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldAddPainter()
        {
            // Arrange
            var modifiedPainter = new PainterModifyModel
            {
                Name = "Антон Брусикин",
                Age = 13,
                Description = "Антоша стал выдающимся художником " +
                "после случая в метро, Омского метро, которого не существует",
                StyleId = Guid.Parse("B08F1F01-D09C-42C7-9A6D-4E355C3FB599"),
                BooksIds = new List<Guid>
                {
                    Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25"),
                    Guid.Parse("8C038ACD-17DB-4554-A741-DE98CA121256")
                }
            };
            var painter = new PainterViewModel
            {
                Name = "Антон Брусикин",
                Age = 13,
                Description = "Антоша стал выдающимся художником " +
                "после случая в метро, Омского метро, которого не существует",
                Style = "Бедное искусство",
                Books = new List<BookPreviewModel>
                {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25"),
                        Name = "Алхимик",
                        Price = 250.00M,
                        Authors = new List<AuthorShortModel>()
                    },
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("8C038ACD-17DB-4554-A741-DE98CA121256"),
                        Name = "Найди меня",
                        Price = 363.00M,
                        Authors = new List<AuthorShortModel>()
                    }
                }
            };
            // Act
            var result = await _painterHandler.AddAsync(modifiedPainter);
            _createPainterId = result.Id;
            painter.Id = result.Id;
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(painter);
        }

        /// <summary>
        /// Должен обновить художника
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldUpdatePainter()
        {
            // Arrange
            var modifiedPainter = new PainterModifyModel
            {
                Id = _createPainterId,
                Name = "Антон Барбаросса",
                Age = 18,
                Description = "Антон подрос и уже может гулять во дворе",
                StyleId = Guid.Parse("AF18C5DC-800C-485B-AB1A-16B15DCDED18"),
                BooksIds = new List<Guid>
                {
                    Guid.Parse("7DB924D8-00A7-4B46-9E31-73D95C38EB31")
                }
            };
            var painter = new PainterViewModel
            {
                Id = _createPainterId,
                Name = "Антон Барбаросса",
                Age = 18,
                Description = "Антон подрос и уже может гулять во дворе",
                Style = "Подземный",
                Books = new List<BookPreviewModel>
                {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("7DB924D8-00A7-4B46-9E31-73D95C38EB31"),
                        Name = "Дни нашей жизни",
                        Price = 330.00M,
                        Authors = new List<AuthorShortModel>()
                    }
                }
            };
            // Act
            var result = await _painterHandler.UpdateAsync(modifiedPainter);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(painter);
        }

        /// <summary>
        /// Должен удалить художника
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task ShouldDeletePainter()
        {
            // Arrange
            var baseResponse = new BaseResponse();
            // Act
            var result = await _painterHandler.DeleteAsync(_createPainterId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(result);
        }

        /// <summary>
        /// Должен получить художника
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetPainter()
        {
            // Arrange
            var painterId = Guid.Parse("8E9093A9-8F64-4EF5-8D03-090C1ED062A5");
            var painter = new PainterViewModel
            {
                Id = painterId,
                Name = "Рафаэль Санти",
                Age = 37,
                Description = "Самый знаменитый представитель Эпохи " +
                "Возрождения поражает гармоничными композициями и лиризмом.",
                Style = "Абстракция Импрессионизм",
                Books = new List<BookPreviewModel>
                {
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("1FFA9B7C-E021-4084-A14B-35839B9CC9D2"),
                        Name = "1984",
                        Price = 203.00M,
                        Authors = new List<AuthorShortModel>()
                    },
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("7DB924D8-00A7-4B46-9E31-73D95C38EB31"),
                        Name = "Дни нашей жизни",
                        Price = 330.00M,
                        Authors = new List<AuthorShortModel>()
                    },
                    new BookPreviewModel
                    {
                        Id = Guid.Parse("8C038ACD-17DB-4554-A741-DE98CA121256"),
                        Name = "Найди меня",
                        Price = 363.00M,
                        Authors = new List<AuthorShortModel>()
                    }
                }
            };
            // Act
            var result = await _painterHandler.GetAsync(painterId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(painter);
        }

        /// <summary>
        /// Должен получить пагинацией 3 художников
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetAndSkipPainters()
        {
            // Act
            var resultWithTaked = await _painterHandler.GetAsync(3, 0);
            var resultWithSkipped = await _painterHandler.GetAsync(3, 3);
            // Assert
            resultWithTaked.PreviewPainters.Should().NotBeNull();
            resultWithTaked.PreviewPainters.Count.Should().Be(3);

            resultWithSkipped.PreviewPainters.Should().NotBeNull();
            resultWithSkipped.PreviewPainters.Count.Should().Be(3);

            resultWithTaked.PreviewPainters.Should()
                .NotBeEquivalentTo(resultWithSkipped.PreviewPainters);
        }

        /// <summary>
        /// Должен найти художников по наименованию
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldSearchPaintersByName()
        {
            // Act
            var result = await _painterHandler.SearchByNameAsync("ра", 2, 1);
            // Assert
            result.PreviewPainters.Should().NotBeNull();
            result.PreviewPainters.Count.Should().Be(2);
            result.Count.Should().Be(3);
        }

        /// <summary>
        /// Должен найти художников по стилю
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldSearchPaintersByStyle()
        {
            // Act
            var result = await _painterHandler.SearchByStyleAsync("а", 4, 1);
            // Assert
            result.PreviewPainters.Should().NotBeNull();
            result.PreviewPainters.Count.Should().Be(4);
            result.Count.Should().Be(5);
        }
    }
}