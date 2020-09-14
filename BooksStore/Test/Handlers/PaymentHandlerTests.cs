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
using ViewModel.Models.Payments;

namespace Test.Handlers
{
    /// <summary>
    /// Набор тестов для тестирования обработчика данных платеж
    /// </summary>
    [TestFixture]
    public class PaymentHandlerTests
    {
        private readonly IPaymentHandler _paymentHandler;
        private readonly DateTime _defaultDate = DateTime.Parse("01.01.0001");
        private Guid _createPaymentId;

        public PaymentHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _paymentHandler = _services.GetService<IPaymentHandler>();
        }

        /// <summary>
        /// Должен добавить платеж
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldAddPayment()
        {
            // Arrange
            var createdPayment = new PaymentCreateModel
            {
                OrderId = Guid.Parse("7FAA8F3D-8557-43B3-9ACE-69259A5AC75E"),
                DatePayment = DateTime.Parse("06.02.2020"),
                Status = PaymentStatus.PaymentWait
            };
            var payment = new PaymentModel
            {
                OrderId = Guid.Parse("7FAA8F3D-8557-43B3-9ACE-69259A5AC75E"),
                DatePayment = DateTime.Parse("06.02.2020"),
                Status = PaymentStatus.PaymentWait,
                Amount = 1345.00M,
            };
            // Act
            var result = await _paymentHandler.AddAsync(createdPayment);
            _createPaymentId = result.Id;
            payment.Id = result.Id;
            // Assert
            result.Should().NotBeNull();
            result.DateCreate.Should().NotBe(_defaultDate);
            payment.DateCreate = result.DateCreate;
            result.Should().BeEquivalentTo(payment);
        }

        /// <summary>
        /// Должен обновить платеж
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldUpdatePayment()
        {
            // Arrange
            var modifiedPayment = new PaymentUpdateModel
            {
                Id = _createPaymentId,
                DatePayment = DateTime.Parse("07.02.2020"),
                Status = PaymentStatus.Paid
            };
            var payment = new PaymentModel
            {
                Id = _createPaymentId,
                OrderId = Guid.Parse("7FAA8F3D-8557-43B3-9ACE-69259A5AC75E"),
                DatePayment = DateTime.Parse("07.02.2020"),
                Status = PaymentStatus.Paid,
                Amount = 1345.00M,
            };
            // Act
            var result = await _paymentHandler.UpdateAsync(modifiedPayment);
            // Assert
            result.Should().NotBeNull();
            result.DateCreate.Should().NotBe(_defaultDate);
            payment.DateCreate = result.DateCreate;
            result.Should().BeEquivalentTo(payment);
        }

        /// <summary>
        /// Должен получить платеж
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetPayment()
        {
            // Arrange
            var paymentId = Guid.Parse("62A2D8B3-144B-49B8-8285-2C07E1D52456");
            var payment = new PaymentModel
            {
                Id = paymentId,
                OrderId = Guid.Parse("5F98D03E-B6DC-41A7-9F3D-86FDDA264F26"),
                DateCreate = DateTime.Parse("13.08.2020"),
                DatePayment = DateTime.Parse("24.08.2020"),
                Status = PaymentStatus.Paid,
                Amount = 550.00M
            };
            // Act
            var result = await _paymentHandler.GetAsync(paymentId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(payment);
        }

        /// <summary>
        /// Должен получить платеж с заказом
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetPaymentWithOrder()
        {
            // Arrange
            var paymentId = Guid.Parse("230C4B58-5F99-4279-A2D4-4AF5C3AF28DB");
            var payment = new PaymentDetailModel
            {
                Id = paymentId,
                Order = new OrderModel
                {
                    Id = Guid.Parse("D8607511-C1D8-4526-8F9F-52791D4158D4"),
                    DateCreate = DateTime.Parse("04.04.2020"),
                    Amount = 609.00M,
                    Status = OrderStatus.Error,
                    Description = null,
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
                            Id = Guid.Parse("D22D44A7-E987-4F8F-8CB2-0768CC6199C6"),
                            Name = "Вторая жизнь Уве",
                            Price = 406.00M,
                            Authors = new List<AuthorShortModel>()
                        }
                    }
                },
                DateCreate = DateTime.Parse("04.04.2020"),
                DatePayment = null,
                Status = PaymentStatus.Error,
                Amount = 303.00M
            };
            // Act
            var result = await _paymentHandler.GetWithOrderAsync(paymentId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(payment);
        }
    }
}