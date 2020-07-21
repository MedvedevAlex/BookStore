using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Стили книг
    /// </summary>
    public enum Style
    {
        [Description("Абстракция")]
        Abstractio = 0,
        [Description("Абстракция Импрессионизм")]
        AbstractioImpressionism = 1,
        [Description("Авангард")]
        Avantgarde = 2,
        [Description("Академизм")]
        Academisme = 3,
        [Description("Искусство действия")]
        Actionart = 4,
        [Description("Империализм")]
        Empire = 5,
        [Description("Аналитический куб")]
        Analyticalcube = 6,
        [Description("Аналитическое искусство")]
        Analyticalart = 7,
        [Description("Анахронизм")]
        Anahronos = 8,
        [Description("Подземный")]
        Undergruond = 9,
        [Description("Модерн")]
        Nouveau = 10,
        [Description("Арт-Брут")]
        Artbrut = 11,
        [Description("Бедное искусство")]
        Artepovera = 12,
        [Description("Арт-деко")]
        Artdeco = 13
    }
}
