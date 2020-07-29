using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.ModelConfiguration
{
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasColumnType("nvarchar(40)");
            builder.Property(a => a.Age)
                .HasColumnType("tinyint");
            builder.Property(a => a.Description)
                .HasColumnType("nvarchar(1000)");

            builder.HasData(
                new { Id = Guid.Parse("6be1a08c-550c-447f-bb67-d1e1f5275dbf"), Name = "Рэй Дуглас Брэдбери", Age = (byte)91, Description = "В 1937 году Брэдбери вступил в лос-анджелесскую «Лигу научных фантастов», которая была одним из многих объединений молодых писателей, активно возникавших в возрождающейся после Великой Депрессии Америке." },
                new { Id = Guid.Parse("d1ecb608-293b-40df-bcaf-02ada7abf05a"), Name = "Джордж Оруэлл", Age = (byte)46, Description = "Начиная с основанной на автобиографическом материале повести «Фунты лиха в Париже и Лондоне» (1933), публиковался под псевдонимом «Джордж Оруэлл», взятом в честь реки Оруэлл, одного из его любимых мест в Англии." },
                new { Id = Guid.Parse("1157dee0-8f67-43d2-8aa1-3d7a2272e3d7"), Name = "Грегори Дэвид Робертс", Age = (byte)68, Description = "Во время своего второго пребывания в австралийской тюрьме Робертс начинает работу над романом «Шантарам». Дважды рукописи уничтожались тюремными надзирателями." },
                new { Id = Guid.Parse("11476765-e104-4900-bea9-17100d084ed6"), Name = "Михаил Афанасьевич Булгаков", Age = (byte)48, Description = "В 1923 году Булгаков вступил во Всероссийский союз писателей. В 1924 году он познакомился с недавно вернувшейся из-за границы Любовью Евгеньевной Белозерской (1895—1987), которая в 1925 году стала его женой." },
                new { Id = Guid.Parse("6b6f819c-2a9d-4ef9-92dd-55f69097f36c"), Name = "Эрих Мария Ремарк", Age = (byte)72, Description = "В 1929 году вышел в свет роман «На Западном фронте без перемен», описывающий жестокость войны с точки зрения 20-летнего солдата. Роман мгновенно стал настоящей сенсацией. За год было продано полтора миллиона экземпляров. Позднее он был переведён на 36 языков мира." },
                new { Id = Guid.Parse("bc72faf4-f5ea-41b4-b85b-835731bdb0f7"), Name = "Антуан де Сент-Экзюпери", Age = (byte)44, Description = "В апреле 1935 года, в качестве корреспондента газеты «Пари-Суар», Сент-Экзюпери посетил СССР и описал этот визит в пяти очерках. Очерк «Преступление и наказание перед лицом советского правосудия» стал одним из первых произведений писателей Запада, в котором делалась попытка осмыслить сталинизм." }
            );
        }
    }
}
