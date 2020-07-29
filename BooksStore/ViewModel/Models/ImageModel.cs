using Microsoft.AspNetCore.Http;
using ViewModel.Enums;

namespace ViewModel.Models
{
    /// <summary>
    /// Модель для получения файлов с фронта
    /// </summary>
    public class ImageModel
    {
        /// <summary>
        /// Файл
        /// </summary>
        public IFormFile File { get; set; }
        /// <summary>
        /// Тип картинки
        /// </summary>
        public ImageType ImageType { get; set; }
    }
}
