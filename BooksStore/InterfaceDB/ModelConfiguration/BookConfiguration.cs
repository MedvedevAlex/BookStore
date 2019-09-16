using InterfaceDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterfaceDB.ModelConfiguration
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            builder.Property(b => b.Name)
                .HasColumnType("varchar(20)");
            builder.Property(t => t.PublishDate)
                .HasColumnType("Date");
            builder.Property(b => b.Cover)
                .HasColumnType("tinyint");
            builder.Property(b => b.Genre)
                .HasColumnType("tinyint");
            builder.Property(b => b.Language)
                .HasColumnType("tinyint");
            builder.Property(b => b.Description)
                .HasColumnType("varchar(200)");
            builder.Property(b => b.ISBN_10)
                .HasColumnType("char(10)");
            builder.Property(b => b.ISBN_13)
                .HasColumnType("char(13)");
            builder.Property(b => b.Dimensions)
                .HasColumnType("varchar(20)");
            builder.Property(b => b.NumbersPages)
                .HasColumnType("smallint");
            builder.Property(b => b.Price)
                .HasColumnType("numeric(8,2)");
            builder.Property(b => b.QuantityStock)
                .HasColumnType("int");
            builder.Property(b => b.Edition)
                .HasColumnType("int");
            builder.Property(b => b.AgeLimit)
                .HasColumnType("tinyint");
            builder.Property(b => b.Weight)
                .HasColumnType("numeric(5,2)");
            builder.Property(b => b.CountCustomers)
                .HasColumnType("int");
            builder.Ignore(b => b.AvgReview);

            builder.HasMany<Author>();
            builder.HasOne<Publisher>();
            builder.HasMany<Painter>();
        }
    }
}
