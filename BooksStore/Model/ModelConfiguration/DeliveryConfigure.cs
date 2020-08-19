using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.ModelConfiguration
{
    class DeliveryConfigure : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.DateCreate)
                .HasColumnType("Date");
            builder.Property(d => d.DateDelivery)
                .HasColumnType("Date")
                .IsRequired(false);
            builder.Property(d => d.Status)
                .HasColumnType("tinyint");

            builder.HasOne(d => d.Shop);
            builder.HasOne(d => d.Order);
        }
    }
}
