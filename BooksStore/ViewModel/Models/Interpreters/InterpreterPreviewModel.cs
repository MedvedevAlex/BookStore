using System;

namespace ViewModel.Models.Interpreters
{
    /// <summary>
    /// Модель Переводчик
    /// </summary>
    public class InterpreterPreviewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя переводчика
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
    }
}