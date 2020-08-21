using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.JoinTables;
using System;

namespace Model.ModelConfiguration.References
{
    class AuthorBookConfigure : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder
                .HasKey(ab => new { ab.BookId, ab.AuthorId });
            builder
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new { BookId = Guid.Parse("aa585855-0feb-418c-acc5-6e98e20b972a"), AuthorId = Guid.Parse("6be1a08c-550c-447f-bb67-d1e1f5275dbf") },
                new { BookId = Guid.Parse("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), AuthorId = Guid.Parse("6be1a08c-550c-447f-bb67-d1e1f5275dbf") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), AuthorId = Guid.Parse("6be1a08c-550c-447f-bb67-d1e1f5275dbf") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), AuthorId = Guid.Parse("d1ecb608-293b-40df-bcaf-02ada7abf05a") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), AuthorId = Guid.Parse("1157dee0-8f67-43d2-8aa1-3d7a2272e3d7") },
                new { BookId = Guid.Parse("7db924d8-00a7-4b46-9e31-73d95c38eb31"), AuthorId = Guid.Parse("6b6f819c-2a9d-4ef9-92dd-55f69097f36c") },
                new { BookId = Guid.Parse("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), AuthorId = Guid.Parse("6b6f819c-2a9d-4ef9-92dd-55f69097f36c") },
                new { BookId = Guid.Parse("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), AuthorId = Guid.Parse("6b6f819c-2a9d-4ef9-92dd-55f69097f36c") },
                new { BookId = Guid.Parse("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), AuthorId = Guid.Parse("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") },
                new { BookId = Guid.Parse("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), AuthorId = Guid.Parse("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") },
                new { BookId = Guid.Parse("f0317cfb-e110-4b92-97b9-a52595cefccd"), AuthorId = Guid.Parse("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") },
                new { BookId = Guid.Parse("4b9c14fd-7788-4c89-b778-459ee7a4415b"), AuthorId = Guid.Parse("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") }
            );
        }
    }
}
