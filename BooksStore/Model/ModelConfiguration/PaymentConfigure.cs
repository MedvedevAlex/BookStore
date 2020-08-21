using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.ModelConfiguration
{
    class PaymentConfigure : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DateCreate)
                .HasColumnType("Date");
            builder.Property(p => p.DatePayment)
                .HasColumnType("Date")
                .IsRequired(false);
            builder.Property(p => p.Status)
                .HasColumnType("tinyint");
            builder.Property(p => p.Amount)
                .HasColumnType("numeric(8,2)");

            builder.HasOne(p => p.Order);
        }
    }
}
