﻿using System;

namespace ViewModel.Models.Deliveries
{
    /// <summary>
    /// Модель для создания доставки
    /// </summary>
    public class DeliveryCreatedModel
    {
        /// <summary>
        /// Идентификатор магазина
        /// </summary>
        public Guid ShopId { get; set; }
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public Guid OrderId { get; set; }
        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTime DateDelivery { get; set; }
    }
}