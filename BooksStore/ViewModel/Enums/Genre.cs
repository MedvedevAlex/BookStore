using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Жанры
    /// </summary>
    public enum Genre
    {
        [Description("Фантастика")]
        Fantasy = 0,
        [Description("Научная фантастика")]
        Sciencefiction = 1,
        [Description("Вестерн")]
        Western = 2,
        [Description("Роман")]
        Romance = 3,
        [Description("Триллер")]
        Thriller = 4,
        [Description("Мистика")]
        Mystery = 5,
        [Description("Детектив")]
        Detective = 6,
        [Description("Антиутопия")]
        Dystopia = 7,
        [Description("Мемуары")]
        Memoir = 8,
        [Description("Биография")]
        Biography = 9,
        [Description("Пьеса")]
        Play = 10,
        [Description("Мьюзикл")]
        Musical = 11,
        [Description("Сатира")]
        Satire = 12,
        [Description("Хайку")]
        Haiku = 13,
        [Description("Ужасы")]
        Horror = 14,
    }
}
