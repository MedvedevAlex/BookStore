using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Enums;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;
using ViewModel.Models.Orders;

namespace Test.Handlers
{
    /// <summary>
    /// Набор тестов для тестирования обработчика данных заказ
    /// </summary>
    [TestFixture]
    public class OrderHandlerTests
    {
        private readonly IOrderHandler _orderHandler;
        private readonly DateTime _defaultDate = DateTime.Parse("01.01.0001");
        private Guid _createOrderId;

        public OrderHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _orderHandler = _services.GetService<IOrderHandler>();
        }

        /// <summary>
        /// Должен добавить заказ
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldAddOrder()
        {
            // Arrange
            var modifiedOrder = new OrderModifyModel
            {
                BooksIds = new List<Guid>
                {
                    Guid.Parse("1FFA9B7C-E021-4084-A14B-35839B9CC9D2"),
                    Guid.Parse("AA585855-0FEB-418C-ACC5-6E98E20B972A")
                },
                Description = "Положите пожалуйста книги шнуровкой наружу"
            };
            var order = new OrderModel
            {
                Id = _createOrderId,
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
                        Id = Guid.Parse("AA585855-0FEB-418C-ACC5-6E98E20B972A"),
                        Name = "О дивный новый мир",
                        Price = 212.00M,
                        Authors = new List<AuthorShortModel>()
                    }
                },
                Status = OrderStatus.NotProcessed,
                Amount = 415.00M,
                Description = "Положите пожалуйста книги шнуровкой наружу"
            };
            // Act
            var result = await _orderHandler.AddAsync(modifiedOrder);
            _createOrderId = result.Id;
            // Assert
            result.Should().NotBeNull();
            result.DateCreate.Should().NotBe(_defaultDate);
            order.Id = result.Id;
            order.DateCreate = result.DateCreate;
            result.Should().BeEquivalentTo(order);
        }

        /// <summary>
        /// Должен обновить статус заказа
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldUpdateOrder()
        {
            // Arrange
            var modifyOrder = new OrderUpdateModel
            {
                Id = _createOrderId,
                Status = OrderStatus.PartiallyCompleted
            };
            var order = new OrderModel
            {
                Id = _createOrderId,
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
                        Id = Guid.Parse("AA585855-0FEB-418C-ACC5-6E98E20B972A"),
                        Name = "О дивный новый мир",
                        Price = 212.00M,
                        Authors = new List<AuthorShortModel>()
                    }
                },
                Status = OrderStatus.PartiallyCompleted,
                Amount = 415.00M,
                DateCreate = _defaultDate,
                Description = "Положите пожалуйста книги шнуровкой наружу"
            };
            // Act
            var result = await _orderHandler.UpdateStatusAsync(modifyOrder);
            // Assert
            result.Should().NotBeNull();
            result.DateCreate.Should().NotBe(_defaultDate);
            result.DateCreate = _defaultDate;
            result.Should().BeEquivalentTo(order);
        }

        /// <summary>
        /// Должен получить заказ
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetOrder()
        {
            // Arrange
            var orderId = Guid.Parse("DAA03CD1-33A0-4D97-88B5-408CBACFC456");
            var order = new OrderModel
            {
                Id = orderId,
                DateCreate = DateTime.Parse("02.08.2020"),
                Status = OrderStatus.NotProcessed,
                Amount = 1042.00M,
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
                        Id = Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"),
                        Name = "Атлант расправил плечи (комплект из 3 книг)",
                        Price = 792.00M,
                        Authors = new List<AuthorShortModel>()
                    }
                }
            };
            // Act
            var result = await _orderHandler.GetAsync(orderId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(order);
        }
    }
}