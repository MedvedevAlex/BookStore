using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Переплет
    /// </summary>
    public enum Cover
    {
        [Description("Мягкий")]
        Paperback = 0,
        [Description("Твердый")]
        Hardback = 1
    }
}
