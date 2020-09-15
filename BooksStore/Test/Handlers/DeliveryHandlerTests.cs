using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Enums;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Deliveries;
using ViewModel.Models.References;
using ViewModel.Models.Shops;

namespace Test.Handlers
{
    /// <summary>
    /// Набор тестов для тестирования обработчика данных доставка
    /// </summary>
    [TestFixture]
    public class DeliveryHandlerTests
    {
        private readonly IDeliveryHandler _deliveryHandler;
        private readonly DateTime _defaultDate = DateTime.Parse("01.01.0001");
        private Guid _createDeliveryId;

        public DeliveryHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _deliveryHandler = _services.GetService<IDeliveryHandler>();
        }

        /// <summary>
        /// Должен добавить доставку
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldAddDelivery()
        {
            // Arrange
            var modifiedDelivery = new DeliveryCreatedModel
            {
                ShopId = Guid.Parse("27CF46B3-A2AA-4351-AF82-E33F36F1C553"),
                OrderId = Guid.Parse("F59E96BE-73A2-40FA-95B1-C931B9DF6C57"),
                DateDelivery = DateTime.Parse("29.09.2020"),
            };
            var shop = new ShopModel
            {
                Id = Guid.Parse("27CF46B3-A2AA-4351-AF82-E33F36F1C553"),
                Name = "Глубокий кошелек",
                Address = "Заельцовская 123",
                WorkShedule = new List<WorkSheduleModel>()
            };

            // Act
            var result = await _deliveryHandler.AddAsync(modifiedDelivery);
            // Assert
            result.Should().NotBeNull();
            result.DateCreate.Should().NotBe(_defaultDate);
            result.Shop.Should().BeEquivalentTo(shop);
            result.Status.Should().Be(DeliveryStatus.Waiting);
            _createDeliveryId = result.Id;
        }

        /// <summary>
        /// Должен обновить доставку
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldUpdateDelivery()
        {
            // Arrange
            var modifiedDelivery = new DeliveryModifyModel
            {
                Id = _createDeliveryId,
                DateDelivery = DateTime.Parse("14.09.2020"),
                ShopId = Guid.Parse("905D9ED8-0BD5-402A-BE16-73C021176C78"),
                Status = DeliveryStatus.Completed
            };
            var delivery = new DeliveryModel
            {
                Id = _createDeliveryId,
                DateDelivery = DateTime.Parse("14.09.2020"),
                Shop = new ShopModel
                {
                    Id = Guid.Parse("905D9ED8-0BD5-402A-BE16-73C021176C78"),
                    Name = "Теплый носок",
                    Address = "Революции 89",
                    WorkShedule = new List<WorkSheduleModel>()
                },
                DateCreate = _defaultDate,
                Status = DeliveryStatus.Completed
            };
            // Act
            var result = await _deliveryHandler.UpdateAsync(modifiedDelivery);
            // Assert
            result.Should().NotBeNull();
            result.DateCreate.Should().NotBe(_defaultDate);
            result.DateCreate = _defaultDate;
            result.Should().BeEquivalentTo(delivery);
        }

        /// <summary>
        /// Должен получить книгу
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetDelivery()
        {
            // Arrange
            var guid = Guid.Parse("97680B55-E371-4653-B017-CE128AB423D9");
            var delivery = new DeliveryModel
            {
                Id = guid,
                DateCreate = DateTime.Parse("11.09.2020"),
                DateDelivery = DateTime.Parse("21.09.2021"),
                Shop = new ShopModel
                {
                    Id = Guid.Parse("06C5D83E-AC7F-4C4C-8AD5-79BB9E914EF8"),
                    Name = "Звенящий брелок",
                    Address = "Красный проспект 234",
                    WorkShedule = new List<WorkSheduleModel>()
                },
                Status = DeliveryStatus.Delivery
            };
            // Act
            var result = await _deliveryHandler.GetAsync(guid);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(delivery);
        }
    }
}