using InterfaceDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterfaceDB.ModelConfiguration
{
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder.Property(a => a.Name)
                .HasColumnType("varchar(20)");
            builder.Property(a => a.Age)
                .HasColumnType("tinyint");
        }
    }
}
