using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.ModelConfiguration
{
    class OrderConfigure : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Status)
                .HasColumnType("tinyint");
            builder.Property(o => o.Amount)
                .HasColumnType("numeric(8,2)");

            builder
                .HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<Delivery>(d => d.OrderId);
            builder
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);
            builder.HasOne(o => o.User);
            builder.HasOne(o => o.Book);
        }
    }
}
