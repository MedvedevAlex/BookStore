using ViewModel.Enums;

namespace ViewModel.Models
{
    /// <summary>
    /// Художник
    /// </summary>
    public class PainterModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PainterId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Стиль рисования
        /// </summary>
        public Style Style { get; set; }
    }
}
