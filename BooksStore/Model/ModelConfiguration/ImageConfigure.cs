using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.ModelConfiguration
{
    class ImageConfigure : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.BookId)
                .HasColumnType("uniqueidentifier");
            //вообще id составляет 33 но кто знает этот гугол что он завтра придумает
            builder.Property(s => s.GoogleFileId)
                .HasColumnType("nvarchar(40)");
            builder.Property(s => s.Name)
                .HasColumnType("nvarchar(100)");
            builder.Property(s => s.ImageType)
                .HasColumnType("tinyint");
            builder.Property(s => s.Link)
                .HasColumnType("nvarchar(1000)");
        }
    }
}
