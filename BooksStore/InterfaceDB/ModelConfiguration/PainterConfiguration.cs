using InterfaceDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterfaceDB.ModelConfiguration
{
    class PainterConfiguration : IEntityTypeConfiguration<Painter>
    {
        public void Configure(EntityTypeBuilder<Painter> builder)
        {
            builder.HasKey(a => a.PainterId);

            builder.Property(a => a.Name)
                .HasColumnType("varchar(20)");
            builder.Property(a => a.Age)
                .HasColumnType("tinyint");
            builder.Property(a => a.Style)
                .HasColumnType("tinyint");

            builder.HasMany<Book>();
        }
    }
}
