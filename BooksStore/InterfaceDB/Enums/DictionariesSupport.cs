using System.Collections.Generic;

namespace InterfaceDB.Enums
{
    public static class DictionariesSupport
    {
        public static readonly Dictionary<Genre, string> ConvertGenreRus = new Dictionary<Genre, string>()
        {
            [Genre.Fantasy] = "Фантастика",
            [Genre.Sciencefiction] = "Научная фантастика",
            [Genre.Western] = "Вестерн",
            [Genre.Romance] = "Роман",
            [Genre.Thriller] = "Триллер",
            [Genre.Mystery] = "Мистика",
            [Genre.Detective] = "Детектив",
            [Genre.Dystopia] = "Антиутопия",
            [Genre.Memoir] = "Мемуары",
            [Genre.Biography] = "Биография",
            [Genre.Play] = "Пьеса",
            [Genre.Musical] = "Мьюзикл",
            [Genre.Satire] = "Сатира",
            [Genre.Haiku] = "Хайку",
            [Genre.Horror] = "Ужасы",
        };
    }
}
