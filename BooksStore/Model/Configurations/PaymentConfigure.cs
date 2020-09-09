using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using ViewModel.Enums;

namespace Model.Configurations
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

            builder.HasData(
                new { Id = Guid.Parse("230c4b58-5f99-4279-a2d4-4af5c3af28db"), OrderId = Guid.Parse("d8607511-c1d8-4526-8f9f-52791d4158d4"), DateCreate = DateTime.Parse("04.04.2020"), Status = PaymentStatus.Error, Amount = 303.00M },
                new { Id = Guid.Parse("3d9d3cbc-8494-4e01-9228-e686ac5658fa"), OrderId = Guid.Parse("daa03cd1-33a0-4d97-88b5-408cbacfc456"), DateCreate = DateTime.Parse("02.08.2020"), Status = PaymentStatus.PaymentWait, Amount = 1042.00M },
                new { Id = Guid.Parse("5efb4e85-c71e-4c68-ad5e-8af4cd2148f8"), OrderId = Guid.Parse("a3de7602-4018-4718-90a9-e7d0a299f315"), DateCreate = DateTime.Parse("23.04.2020"), Status = PaymentStatus.Paid, Amount = 212.00M },
                new { Id = Guid.Parse("62a2d8b3-144b-49b8-8285-2c07e1d52456"), OrderId = Guid.Parse("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), DateCreate = DateTime.Parse("13.08.2020"), Status = PaymentStatus.Paid, Amount = 550.00M }
            );
        }
    }
}
