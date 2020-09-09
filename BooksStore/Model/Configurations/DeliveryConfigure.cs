using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using ViewModel.Enums;

namespace Model.Configurations
{
    class DeliveryConfigure : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.DateCreate)
                .HasColumnType("Date");
            builder.Property(d => d.DateDelivery)
                .HasColumnType("Date");
            builder.Property(d => d.Status)
                .HasColumnType("tinyint");

            builder.HasOne(d => d.Shop);
            builder.HasOne(d => d.Order);

            builder.HasData(
                new { Id = Guid.Parse("0fd51bef-3c0e-4cd4-946a-d1f2982d0eab"), OrderId = Guid.Parse("d8607511-c1d8-4526-8f9f-52791d4158d4"), ShopId = Guid.Parse("C99ECA84-3AA1-4A38-ABE2-6B551571246D"), DateCreate = DateTime.Parse("09.09.2020"), Status = DeliveryStatus.Error },
                new { Id = Guid.Parse("9370693c-5d3d-4bd1-9077-9d4cc9c3a23b"), OrderId = Guid.Parse("daa03cd1-33a0-4d97-88b5-408cbacfc456"), ShopId = Guid.Parse("905D9ED8-0BD5-402A-BE16-73C021176C78"), DateCreate = DateTime.Parse("06.09.2020"), Status = DeliveryStatus.Waiting },
                new { Id = Guid.Parse("97680b55-e371-4653-b017-ce128ab423d9"), OrderId = Guid.Parse("a3de7602-4018-4718-90a9-e7d0a299f315"), ShopId = Guid.Parse("06C5D83E-AC7F-4C4C-8AD5-79BB9E914EF8"), DateCreate = DateTime.Parse("11.09.2020"), DateDelivery = DateTime.Parse("21.09.2021"), Status = DeliveryStatus.Delivery },
                new { Id = Guid.Parse("8c7a2ffb-36a4-4e48-af52-b2dc4e7b810b"), OrderId = Guid.Parse("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), ShopId = Guid.Parse("BD0F8083-8072-4A25-8D13-90A85F2CAECA"), DateCreate = DateTime.Parse("25.08.2020"), DateDelivery = DateTime.Parse("09.09.2021"), Status = DeliveryStatus.Completed }
            );
        }
    }
}
