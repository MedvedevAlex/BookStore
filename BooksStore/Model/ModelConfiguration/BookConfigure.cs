using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.ModelConfiguration
{
    class BookConfigure : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasColumnType("varchar(50)");
            builder.Property(t => t.PublishDate)
                .HasColumnType("Date");
            builder.Property(b => b.Description)
                .HasColumnType("varchar(1000)");
            builder.Property(b => b.ISBN_13)
                .HasColumnType("char(17)");
            builder.Property(b => b.Format)
                .HasColumnType("varchar(30)");
            builder.Property(b => b.CountPage)
                .HasColumnType("smallint");
            builder.Property(b => b.Price)
                .HasColumnType("numeric(8,2)");
            builder.Property(b => b.Duplicate)
                .HasColumnType("smallint");
            builder.Property(b => b.AgeLimit)
                .HasColumnType("tinyint");
            builder.Property(b => b.Weight)
                .HasColumnType("smallint");

            builder
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books);
            builder.HasOne(b => b.Language);
            builder.HasOne(g => g.Genre);
            builder.HasOne(b => b.CoverType);

            builder.HasData(
            new {
                Id = Guid.Parse("aa585855-0feb-418c-acc5-6e98e20b972a"),
                Name = "О дивный новый мир",
                PublishDate = new DateTime(2014, 5, 25),
                PublisherId = Guid.Parse("fe0f989d-1eb9-467e-8fbf-c783d70171bc"),
                CoverTypeId = Guid.Parse("f3ff3c04-893a-40bc-9854-1c2ba98c8265"),
                GenreId = Guid.Parse("cfb89ffe-f0c9-4821-a499-2fcaf38fca16"),
                LanguageId = Guid.Parse("67cbe600-e220-42c5-b526-6fe821476273"),
                Description = "О дивный новый мир - изысканная и остроумная антиутопия о генетически программируемом обществе потребления, в котором разворачивается трагическая история Дикаря - Гамлета этого мира.",
                ISBN_13 = "978-5-17-080085-8",
                Format = "18 x 11.6 x 1.9",
                CountPage = (short)350,
                Price = 212m,
                Weight = (short)200,
                Duplicate = 5000,
                AgeLimit = (byte)16
            },
            new {
                Id = Guid.Parse("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"),
                Name = "Алхимик",
                PublishDate = new DateTime(2015, 2, 2),
                PublisherId = Guid.Parse("5ec79a9a-93ac-4956-861e-ccfa8696e13d"),
                CoverTypeId = Guid.Parse("56d180ca-f9bd-4dad-87ef-af334f636be1"),
                GenreId = Guid.Parse("e8e4d3c5-1bd3-44f2-9120-5c39e44c553f"),
                LanguageId = Guid.Parse("67cbe600-e220-42c5-b526-6fe821476273"),
                Description = "Алхимик» – самый известный роман бразильского писателя Пауло Коэльо, любимая книга миллионов людей во всем мире.",
                ISBN_13 = "978-5-17-087921-2",
                Format = "18 x 11.5 x 1.3",
                CountPage = (short)220,
                Price = 250m,
                Weight = (short)160,
                Duplicate = 10000,
                AgeLimit = (byte)16
            },
            new
            {
                Id = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"),
                Name = "Найди меня",
                PublishDate = new DateTime(2020, 1, 5),
                PublisherId = Guid.Parse("6a8c18f9-b8c3-4964-8494-81c26d6af209"),
                CoverTypeId = Guid.Parse("fc4519df-a67d-4686-904b-4ee105f37d22"),
                GenreId = Guid.Parse("e36af307-b334-4074-91b4-c2e14d043743"),
                LanguageId = Guid.Parse("08fee749-b64b-4815-823a-b36b1ab6371e"),
                Description = "Андре Асимана называют одним из важнейших романистов современности. «Найди меня» — долгожданное продолжение его бестселлера «Назови меня своим именем», покорившего миллионы читателей во всем мире.",
                ISBN_13 = "978-5-6042628-9-4",
                Format = "21 x 14 x 1.9",
                CountPage = (short)320,
                Price = 363m,
                Weight = (short)330,
                Duplicate = 15000,
                AgeLimit = (byte)18
            },
            new
            {
                Id = Guid.Parse("7db924d8-00a7-4b46-9e31-73d95c38eb31"),
                Name = "Дни нашей жизни",
                PublishDate = new DateTime(2020, 5, 5),
                PublisherId = Guid.Parse("6a8c18f9-b8c3-4964-8494-81c26d6af209"),
                CoverTypeId = Guid.Parse("47b06aac-5e4a-4541-b1b6-dcb5ec8f69dc"),
                GenreId = Guid.Parse("29c1b4ad-05e6-4752-ba67-47dc45a0fe46"),
                LanguageId = Guid.Parse("f1f085b5-689c-4675-ad84-4f47a5d0883e"),
                Description = "В детстве маленького Мики было всё, как у обычных детей: любимые герои, каши по утрам, дни рождения, скучные линейки в школе и сочинения на заданные темы.",
                ISBN_13 = "978-5-6043606-3-7",
                Format = "21 x 14 x 3.2",
                CountPage = (short)400,
                Price = 330m,
                Weight = (short)380,
                Duplicate = 2000,
                AgeLimit = (byte)18
            },
            new
            {
                Id = Guid.Parse("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"),
                Name = "1984",
                PublishDate = new DateTime(2014, 3, 5),
                PublisherId = Guid.Parse("b9af4688-e273-4676-a92a-656023a2d216"),
                CoverTypeId = Guid.Parse("07b46856-7089-4d71-a07a-40068f79ff2d"),
                GenreId = Guid.Parse("cfb89ffe-f0c9-4821-a499-2fcaf38fca16"),
                LanguageId = Guid.Parse("67cbe600-e220-42c5-b526-6fe821476273"),
                Description = "Своеобразный антипод второй великой антиутопии XX века - О дивный новый мир Олдоса Хаксли. Что, в сущности, страшнее: доведенное до абсурда общество потребления - или доведенное до абсолюта общество идеи? По Оруэллу, нет и не может быть ничего ужаснее тотальной несвободы...",
                ISBN_13 = "978-5-17-080115-2",
                Format = "18.1 x 11.7 x 2",
                CountPage = (short)318,
                Price = 203m,
                Weight = (short)230,
                Duplicate = 7000,
                AgeLimit = (byte)16
            },
            new
            {
                Id = Guid.Parse("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"),
                Name = "Вторая жизнь Уве",
                PublishDate = new DateTime(2017, 11, 1),
                PublisherId = Guid.Parse("3f755440-89bf-4335-99a7-db1d9226d666"),
                CoverTypeId = Guid.Parse("33aa3511-8c70-4e19-9719-321d4b79f588"),
                GenreId = Guid.Parse("7bb337b5-6b47-4613-8657-6f78506fe117"),
                LanguageId = Guid.Parse("90b9df3b-581f-4f92-adee-251630a72a9e"),
                Description = "На первый взгляд Уве — самый угрюмый человек на свете. Он, как и многие из нас, полагает, что его окружают преимущественно идиоты — соседи, которые неправильно паркуют свои машины; продавцы в магазине, говорящие на птичьем языке; бюрократы, портящие жизнь нормальным людям.",
                ISBN_13 = "978-5-905891-97-7",
                Format = "20.5 x 13 x 2.4",
                CountPage = (short)384,
                Price = 406m,
                Weight = (short)400,
                Duplicate = 5000,
                AgeLimit = (byte)14
            },
            new
            {
                Id = Guid.Parse("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"),
                Name = "Дом, в котором…",
                PublishDate = new DateTime(2016, 9, 22),
                PublisherId = Guid.Parse("3f755440-89bf-4335-99a7-db1d9226d666"),
                CoverTypeId = Guid.Parse("56d180ca-f9bd-4dad-87ef-af334f636be1"),
                GenreId = Guid.Parse("7cf21233-4caf-4902-bcc1-85a677bf1c59"),
                LanguageId = Guid.Parse("8d13a346-389b-48b3-9299-a565bf2a6658"),
                Description = "На окраине города, среди стандартных новостроек, стоит Серый Дом, в котором живут Сфинкс, Слепой, Лорд, Табаки, Македонский, Черный и многие другие.",
                ISBN_13 = "978-5-904584-69-6",
                Format = "22 x 15 x 5",
                CountPage = (short)960,
                Price = 605m,
                Weight = (short)1050,
                Duplicate = 15000,
                AgeLimit = (byte)12
            },
            new
            {
                Id = Guid.Parse("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"),
                Name = "Сто лет одиночества",
                PublishDate = new DateTime(2015, 10, 15),
                PublisherId = Guid.Parse("94834ccb-a363-4566-bf2c-d73ff9ba958f"),
                CoverTypeId = Guid.Parse("56d180ca-f9bd-4dad-87ef-af334f636be1"),
                GenreId = Guid.Parse("7fb2db94-ebb6-4235-a3e5-182e735b8bf8"),
                LanguageId = Guid.Parse("02a20c75-b5ce-4c81-8fd4-02ba505aca1a"),
                Description = "Одна из величайших книг ХХ века. Странная, поэтичная, причудливая история города Макондо, затерянного где-то в джунглях, – от сотворения до упадка. История рода Буэндиа – семьи, в которой чудеса столь повседневны, что на них даже не обращают внимания.",
                ISBN_13 = "978-5-17-090831-8",
                Format = "18 x 11.5 x 2.6",
                CountPage = (short)544,
                Price = 377m,
                Weight = (short)330,
                Duplicate = 50000,
                AgeLimit = (byte)6
            },
            new
            {
                Id = Guid.Parse("f0317cfb-e110-4b92-97b9-a52595cefccd"),
                Name = "Цветы для Элджернона",
                PublishDate = new DateTime(2010, 7, 27),
                PublisherId = Guid.Parse("94834ccb-a363-4566-bf2c-d73ff9ba958f"),
                CoverTypeId = Guid.Parse("fc4519df-a67d-4686-904b-4ee105f37d22"),
                GenreId = Guid.Parse("7fb2db94-ebb6-4235-a3e5-182e735b8bf8"),
                LanguageId = Guid.Parse("8d13a346-389b-48b3-9299-a565bf2a6658"),
                Description = "Сорок лет назад это считалось фантастикой. Сорок лет назад это читалось как фантастика. Исследующая и расширяющая границы жанра, жадно впитывающая всевозможные новейшие веяния, примеряющая общечеловеческое лицо, отважно игнорирующая каинову печать жанрового гетто.",
                ISBN_13 = "978-5-699-41332-4",
                Format = "18 x 11.5 x 1.4",
                CountPage = (short)320,
                Price = 220m,
                Weight = (short)170,
                Duplicate = 3000,
                AgeLimit = (byte)6
            },
            new
            {
                Id = Guid.Parse("4b9c14fd-7788-4c89-b778-459ee7a4415b"),
                Name = "Атлант расправил плечи (комплект из 3 книг)",
                PublishDate = new DateTime(2018, 5, 5),
                PublisherId = Guid.Parse("94834ccb-a363-4566-bf2c-d73ff9ba958f"),
                CoverTypeId = Guid.Parse("f586ce45-08d0-46a5-931a-7a10fdab654d"),
                GenreId = Guid.Parse("6aed17e9-b4f9-4997-b115-6da1dfdcca80"),
                LanguageId = Guid.Parse("ae0cf116-c244-4997-93cd-f7760a93fe0f"),
                Description = "В первой части читатели знакомятся с главными героями, гениальными предпринимателями, которым противостоят их антиподы - бездарные государственные чиновники. Повествование начинается с вопроса: кто такой Джон Голт? И на этот вопрос будут искать ответ герои романа и его читатели.",
                ISBN_13 = "978-5-9614-6742-0",
                Format = "21.7 x 14.8 x 2",
                CountPage = (short)436,
                Price = 792m,
                Weight = (short)1700,
                Duplicate = 17000,
                AgeLimit = (byte)15
            });
        }
    }
}
