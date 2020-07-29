using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.References;
using System;

namespace Model.ModelConfiguration.References
{
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .HasColumnType("nvarchar(20)");

            builder.HasData(
                new { Id = Guid.Parse("e8e4d3c5-1bd3-44f2-9120-5c39e44c553f"), Name = "Фантастика" },
                new { Id = Guid.Parse("7fb2db94-ebb6-4235-a3e5-182e735b8bf8"), Name = "Научная фантастика" },
                new { Id = Guid.Parse("cc169b1e-d765-4186-8d2a-7b52700c6920"), Name = "Вестерн" },
                new { Id = Guid.Parse("e36af307-b334-4074-91b4-c2e14d043743"), Name = "Роман" },
                new { Id = Guid.Parse("29c1b4ad-05e6-4752-ba67-47dc45a0fe46"), Name = "Триллер" },
                new { Id = Guid.Parse("a333d616-ee40-4f7c-a08f-f6542bacc1e1"), Name = "Мистика" },
                new { Id = Guid.Parse("4edb8ea0-d704-4e41-babb-c90017b0abed"), Name = "Детектив" },
                new { Id = Guid.Parse("cfb89ffe-f0c9-4821-a499-2fcaf38fca16"), Name = "Антиутопия" },
                new { Id = Guid.Parse("7bb337b5-6b47-4613-8657-6f78506fe117"), Name = "Мемуары" },
                new { Id = Guid.Parse("081e6e09-02df-4942-b799-c7235de02793"), Name = "Биография" },
                new { Id = Guid.Parse("8171d6b3-425a-40d9-a7dc-0bf26d3576bc"), Name = "Пьеса" },
                new { Id = Guid.Parse("29388b16-5322-4b77-bd19-eb6844a05e27"), Name = "Мьюзикл" },
                new { Id = Guid.Parse("0adc9006-ccc6-4d89-87ae-f9373d08152f"), Name = "Сатира" },
                new { Id = Guid.Parse("2916347b-080c-4196-8585-6de05fbc430f"), Name = "Хайку" },
                new { Id = Guid.Parse("7cf21233-4caf-4902-bcc1-85a677bf1c59"), Name = "Ужасы" },
                new { Id = Guid.Parse("6aed17e9-b4f9-4997-b115-6da1dfdcca80"), Name = "Классика" }
                );
        }
    }
}
