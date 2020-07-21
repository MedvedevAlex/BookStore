using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Языки
    /// </summary>
    public enum Language
    {
        [Description("Английский")]
        ENG = 0,
        [Description("Русский")]
        RUS = 1,
        [Description("Китайский")]
        CHI = 2,
        [Description("Испанский")]
        SPA = 3,
        [Description("Арабский")]
        ARA = 4,
        [Description("Португальский")]
        POR = 5,
        [Description("Немецкий")]
        DEU = 6,
        [Description("Французский")]
        FRA = 7,
    }
}
