using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.References;
using System;

namespace Model.ModelConfiguration.References
{
    class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .HasColumnType("nvarchar(20)");

            builder.HasData(
                new { Id = Guid.Parse("67cbe600-e220-42c5-b526-6fe821476273"), Name = "Английский" },
                new { Id = Guid.Parse("f1f085b5-689c-4675-ad84-4f47a5d0883e"), Name = "Немецкий" },
                new { Id = Guid.Parse("08fee749-b64b-4815-823a-b36b1ab6371e"), Name = "Русский" },
                new { Id = Guid.Parse("ae0cf116-c244-4997-93cd-f7760a93fe0f"), Name = "Японский" },
                new { Id = Guid.Parse("3206ceea-d1f4-4659-a0cd-3f7b5100c73d"), Name = "Китайский" },
                new { Id = Guid.Parse("90b9df3b-581f-4f92-adee-251630a72a9e"), Name = "Бразильский" },
                new { Id = Guid.Parse("8d13a346-389b-48b3-9299-a565bf2a6658"), Name = "Французский" },
                new { Id = Guid.Parse("02a20c75-b5ce-4c81-8fd4-02ba505aca1a"), Name = "Португальский" }
                );
        }
    }
}
