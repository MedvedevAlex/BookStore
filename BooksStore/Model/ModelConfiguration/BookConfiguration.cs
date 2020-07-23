using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.ModelConfiguration
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasColumnType("varchar(20)");
            builder.Property(t => t.PublishDate)
                .HasColumnType("Date");
            builder.Property(b => b.Description)
                .HasColumnType("varchar(200)");
            builder.Property(b => b.ISBN_10)
                .HasColumnType("char(10)");
            builder.Property(b => b.ISBN_13)
                .HasColumnType("char(13)");
            builder.Property(b => b.Format)
                .HasColumnType("varchar(20)");
            builder.Property(b => b.CountPage)
                .HasColumnType("smallint");
            builder.Property(b => b.Price)
                .HasColumnType("numeric(8,2)");
            builder.Property(b => b.Duplicate)
                .HasColumnType("int");
            builder.Property(b => b.AgeLimit)
                .HasColumnType("tinyint");
            builder.Property(b => b.Weight)
                .HasColumnType("numeric(5,2)");

            builder.HasOne(p => p.Publisher);
            builder.HasOne(l => l.Language);
            builder.HasOne(g => g.Genre);
            builder.HasOne(ct => ct.CoverType);

            //builder.HasData(new Book()
            //{
            //    Id = Guid.Parse("4a55f86a-da6c-423e-bbaa-dce9b456977d"),
            //    Name = "О дивный новый мир",
            //    PublishDate = new DateTime(2014, 5, 25),
            //    TypeCoverId = Guid.Parse("43540c87-8a87-46ec-adf3-324d3d413e12"),
            //    GenreId = Guid.Parse("cf79a826-4e17-4a47-b669-97291f489597"),
            //    LanguageId = Guid.Parse("c305cd40-7471-41a2-82d7-ea4626576228")
            //});
        }
    }
}
