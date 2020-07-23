using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.JoinTables;
using System;

namespace Model.ModelConfiguration.References
{
    class PainterBookConfiguration : IEntityTypeConfiguration<PainterBook>
    {
        public void Configure(EntityTypeBuilder<PainterBook> builder)
        {
            builder
                .HasKey(b => new { b.BookId, b.PainterId });
            builder
                .HasOne(b => b.Book)
                .WithMany(pb => pb.PainterBooks)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(p => p.Painter)
                .WithMany(pb => pb.PainterBooks)
                .HasForeignKey(p => p.PainterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new { BookId = Guid.Parse("aa585855-0feb-418c-acc5-6e98e20b972a"), PainterId = Guid.Parse("b849554a-3b05-4aff-9f81-ac1a4abbfc01") },
                new { BookId = Guid.Parse("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), PainterId = Guid.Parse("b849554a-3b05-4aff-9f81-ac1a4abbfc01") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), PainterId = Guid.Parse("d18d0a39-9a5f-476f-8d52-bc0a23a371af") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), PainterId = Guid.Parse("8e9093a9-8f64-4ef5-8d03-090c1ed062a5") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), PainterId = Guid.Parse("549903f5-66ab-48e8-b126-8610c4bb08b9") },
                new { BookId = Guid.Parse("7db924d8-00a7-4b46-9e31-73d95c38eb31"), PainterId = Guid.Parse("8e9093a9-8f64-4ef5-8d03-090c1ed062a5") },
                new { BookId = Guid.Parse("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), PainterId = Guid.Parse("8e9093a9-8f64-4ef5-8d03-090c1ed062a5") },
                new { BookId = Guid.Parse("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), PainterId = Guid.Parse("549903f5-66ab-48e8-b126-8610c4bb08b9") },
                new { BookId = Guid.Parse("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), PainterId = Guid.Parse("549903f5-66ab-48e8-b126-8610c4bb08b9") },
                new { BookId = Guid.Parse("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), PainterId = Guid.Parse("20035c22-62c5-4688-b21a-cff0007e871e") },
                new { BookId = Guid.Parse("f0317cfb-e110-4b92-97b9-a52595cefccd"), PainterId = Guid.Parse("20035c22-62c5-4688-b21a-cff0007e871e") },
                new { BookId = Guid.Parse("4b9c14fd-7788-4c89-b778-459ee7a4415b"), PainterId = Guid.Parse("14587f65-7b1c-4171-b0f0-bf707284710f") }
            );
        }
    }
}
