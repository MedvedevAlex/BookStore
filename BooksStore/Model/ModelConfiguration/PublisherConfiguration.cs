using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace InterfaceDB.ModelConfiguration
{
    class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(a => a.PublisherId);

            builder.Property(a => a.Name)
                .HasColumnType("varchar(20)");
            builder.Property(a => a.ShortName)
                .HasColumnType("char[3]");
            builder.Property(a => a.Corporation)
                .HasColumnType("varchar(20)");

        }
    }
}
