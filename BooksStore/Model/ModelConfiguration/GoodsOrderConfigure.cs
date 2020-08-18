using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.ModelConfiguration
{
    class GoodsOrderConfigure : IEntityTypeConfiguration<GoodsOrder>
    {
        public void Configure(EntityTypeBuilder<GoodsOrder> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Amount)
                .HasColumnType("numeric(8,2)");

            builder.HasOne(g => g.Order);
            builder.HasOne(g => g.Book);
        }
    }
}
