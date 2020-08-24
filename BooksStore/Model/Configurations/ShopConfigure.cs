using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.Configurations
{
    class ShopConfigure : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasColumnType("varchar(30)");
            builder.Property(s => s.Address)
                .HasColumnType("varchar(40)");

            builder
                .HasMany(s => s.WorkShedule)
                .WithOne(ws => ws.Shop);

            builder.HasData(
                new { Id = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), Name = "Книжная штучка", Address = "Советская 65" },
                new { Id = Guid.Parse("c99eca84-3aa1-4a38-abe2-6b551571246d"), Name = "Большая закладка", Address = "Мира 22" },
                new { Id = Guid.Parse("bd0f8083-8072-4a25-8d13-90a85f2caeca"), Name = "Скрытая обложка", Address = "Маркса проспект 3" },
                new { Id = Guid.Parse("27cf46b3-a2aa-4351-af82-e33f36f1c553"), Name = "Глубокий кошелек", Address = "Заельцовская 123" },
                new { Id = Guid.Parse("06c5d83e-ac7f-4c4c-8ad5-79bb9e914ef8"), Name = "Звенящий брелок", Address = "Красный проспект 234" },
                new { Id = Guid.Parse("905d9ed8-0bd5-402a-be16-73c021176c78"), Name = "Теплый носок", Address = "Революции 89" }
            );
        }
    }
}
