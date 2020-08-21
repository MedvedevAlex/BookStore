using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Configurations
{
    class GoodsOrderConfigure : IEntityTypeConfiguration<GoodsOrder>
    {
        public void Configure(EntityTypeBuilder<GoodsOrder> builder)
        {
            builder.HasKey(go => go.Id);

            builder.Property(go => go.Amount)
                .HasColumnType("numeric(8,2)");

            builder.HasOne(go => go.Order);
            builder.HasOne(go => go.Book);
        }
    }
}
