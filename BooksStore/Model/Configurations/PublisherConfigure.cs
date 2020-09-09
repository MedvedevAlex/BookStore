using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.Configurations
{
    class PublisherConfigure : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(30)");

            builder.HasData(
                new { Id = Guid.Parse("fe0f989d-1eb9-467e-8fbf-c783d70171bc"), Name = "Эксмо" },
                new { Id = Guid.Parse("94834ccb-a363-4566-bf2c-d73ff9ba958f"), Name = "Детская литература" },
                new { Id = Guid.Parse("5ec79a9a-93ac-4956-861e-ccfa8696e13d"), Name = "Азбука" },
                new { Id = Guid.Parse("6a8c18f9-b8c3-4964-8494-81c26d6af209"), Name = "Вече" },
                new { Id = Guid.Parse("b9af4688-e273-4676-a92a-656023a2d216"), Name = "Рипол Классик" },
                new { Id = Guid.Parse("3f755440-89bf-4335-99a7-db1d9226d666"), Name = "Амфора" }
            );
        }
    }
}
