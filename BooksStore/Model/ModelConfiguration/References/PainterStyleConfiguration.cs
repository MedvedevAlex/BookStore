using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.References;
using System;

namespace Model.ModelConfiguration.References
{
    class PainterStyleConfiguration : IEntityTypeConfiguration<PainterStyle>
    {
        public void Configure(EntityTypeBuilder<PainterStyle> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .HasColumnType("nvarchar(30)");

            builder.HasData(
                new { Id = Guid.Parse("018c691d-5f4a-47fe-8fee-19d45877dabd"), Name = "Абстракция" },
                new { Id = Guid.Parse("fe4bb701-b2c2-40b5-ae4e-4e46edad36d1"), Name = "Абстракция Импрессионизм" },
                new { Id = Guid.Parse("6801a5c4-fc35-468d-884f-75af47a288d6"), Name = "Авангард" },
                new { Id = Guid.Parse("603e8dca-6fe7-440a-821a-a27086742778"), Name = "Академизм" },
                new { Id = Guid.Parse("791ddbdc-05ee-4a15-afbb-f866a978d5e7"), Name = "Искусство действия" },
                new { Id = Guid.Parse("d680babb-53dc-430e-a267-11669c07fa5c"), Name = "Империализм" },
                new { Id = Guid.Parse("d6247b75-b2fc-4c7f-926c-bf2e0b011cf0"), Name = "Аналитический кубизм" },
                new { Id = Guid.Parse("e2dec289-43bb-4087-9b67-bfde445587db"), Name = "Аналитическое искусство" },
                new { Id = Guid.Parse("27078d1d-666a-4827-8f61-2683ae305f4d"), Name = "Анахронизм" },
                new { Id = Guid.Parse("af18c5dc-800c-485b-ab1a-16b15dcded18"), Name = "Подземный" },
                new { Id = Guid.Parse("f0c8630d-2e1b-4536-b0d1-f2e4a0e1da81"), Name = "Модерн" },
                new { Id = Guid.Parse("a713584e-be49-4b35-8dac-c114213c1a2b"), Name = "Арт-Брут" },
                new { Id = Guid.Parse("b08f1f01-d09c-42c7-9a6d-4e355c3fb599"), Name = "Бедное искусство" },
                new { Id = Guid.Parse("128bc5f7-3842-4a74-91d0-dd62064f9802"), Name = "Арт-Деко" }
                );
        }
    }
}
