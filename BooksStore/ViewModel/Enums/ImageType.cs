using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Тип картинки
    /// </summary>
    public enum ImageType
    {
        [Description("Превью")]
        Preview = 0,
        [Description("Полная")]
        View = 1,
    }
}
