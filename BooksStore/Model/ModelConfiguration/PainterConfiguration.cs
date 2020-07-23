using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace InterfaceDB.ModelConfiguration
{
    class PainterConfiguration : IEntityTypeConfiguration<Painter>
    {
        public void Configure(EntityTypeBuilder<Painter> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasColumnType("varchar(20)");
            builder.Property(a => a.Age)
                .HasColumnType("tinyint");
            builder.Property(a => a.Description)
                .HasColumnType("varchar(255)");

            builder.HasOne(s => s.Style);
        }
    }
}
