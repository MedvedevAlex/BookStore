using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using ViewModel.Enums;

namespace Model.Configurations
{
    class OrderConfigure : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id); 

            builder.Property(o => o.DateCreate)
                .HasColumnType("Date");
            builder.Property(o => o.Status)
                .HasColumnType("tinyint");
            builder.Property(o => o.Amount)
                .HasColumnType("numeric(8,2)");
            builder.Property(b => b.Description)
                .HasColumnType("nvarchar(255)")
                .IsRequired(false);

            builder
                .HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<Delivery>(d => d.OrderId);
            builder
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);
            builder.HasOne(o => o.User);

            builder.HasData(
                new { Id = Guid.Parse("d8607511-c1d8-4526-8f9f-52791d4158d4"), UserId = Guid.Parse("30be92d8-e0db-4386-9131-93d6cc4b7c47"), DateCreate = DateTime.Parse("04.04.2020"), Status = OrderStatus.Error, Amount = 609.00M },
                new { Id = Guid.Parse("daa03cd1-33a0-4d97-88b5-408cbacfc456"), UserId = Guid.Parse("30be92d8-e0db-4386-9131-93d6cc4b7c47"), DateCreate = DateTime.Parse("02.08.2020"), Status = OrderStatus.NotProcessed, Amount = 1042.00M },
                
                new { Id = Guid.Parse("a3de7602-4018-4718-90a9-e7d0a299f315"), UserId = Guid.Parse("54b6722e-1e29-4cc6-ada7-8d4edd5a13e4"), DateCreate = DateTime.Parse("22.04.2020"), Status = OrderStatus.InWork, Amount = 212.00M },
                new { Id = Guid.Parse("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), UserId = Guid.Parse("54b6722e-1e29-4cc6-ada7-8d4edd5a13e4"), DateCreate = DateTime.Parse("11.08.2020"), Status = OrderStatus.FullyСompleted, Amount = 550.00M },
                
                new { Id = Guid.Parse("7faa8f3d-8557-43b3-9ace-69259a5ac75e"), UserId = Guid.Parse("108c5883-e2b7-4937-a04d-f7c059b8acd3"), DateCreate = DateTime.Parse("05.02.2020"), Status = OrderStatus.PartiallyCompleted, Amount = 1345.00M },
                new { Id = Guid.Parse("f59e96be-73a2-40fa-95b1-c931b9df6c57"), UserId = Guid.Parse("108c5883-e2b7-4937-a04d-f7c059b8acd3"), DateCreate = DateTime.Parse("08.08.2020"), Status = OrderStatus.FailureCustomer, Amount = 305.00M },
                
                new { Id = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), UserId = Guid.Parse("367c6b4e-8650-481c-80d5-6db6bf583095"), DateCreate = DateTime.Parse("30.06.2020"), Status = OrderStatus.FailureCompany, Amount = 3758.00M }
            );
        }
    }
}
