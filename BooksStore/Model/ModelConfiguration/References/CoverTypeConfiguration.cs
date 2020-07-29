using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.References;
using System;

namespace Model.ModelConfiguration.References
{
    class CoverTypeConfiguration : IEntityTypeConfiguration<CoverType>
    {
        public void Configure(EntityTypeBuilder<CoverType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .HasColumnType("nvarchar(30)");

            builder.HasData(
                new { Id = Guid.Parse("f3ff3c04-893a-40bc-9854-1c2ba98c8265"), Name = "Мягкая бумажная" },
                new { Id = Guid.Parse("56d180ca-f9bd-4dad-87ef-af334f636be1"), Name = "Твердая бумажная" },
                new { Id = Guid.Parse("fc4519df-a67d-4686-904b-4ee105f37d22"), Name = "Мягкая картонная" },
                new { Id = Guid.Parse("47b06aac-5e4a-4541-b1b6-dcb5ec8f69dc"), Name = "Твердая картонная" },
                new { Id = Guid.Parse("07b46856-7089-4d71-a07a-40068f79ff2d"), Name = "Мягкая стеклянная" },
                new { Id = Guid.Parse("33aa3511-8c70-4e19-9719-321d4b79f588"), Name = "Твердая стеклянная" },
                new { Id = Guid.Parse("6804baa3-f2fe-4062-84e1-e3d636ade0d7"), Name = "Мягкая глянцевая" },
                new { Id = Guid.Parse("f586ce45-08d0-46a5-931a-7a10fdab654d"), Name = "Твердая глянцевая" }
            );
        }
    }
}
