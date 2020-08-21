using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.JoinTables;
using System;

namespace Model.Configurations.References
{
    class InterpreterBookConfigure : IEntityTypeConfiguration<InterpreterBook>
    {
        public void Configure(EntityTypeBuilder<InterpreterBook> builder)
        {
            builder
                .HasKey(ib => new { ib.BookId, ib.InterpreterId });
            builder
                .HasOne(ib => ib.Book)
                .WithMany(b => b.InterpreterBooks)
                .HasForeignKey(ib => ib.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(ib => ib.Interpreter)
                .WithMany(i => i.InterpreterBooks)
                .HasForeignKey(ib => ib.InterpreterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new { BookId = Guid.Parse("aa585855-0feb-418c-acc5-6e98e20b972a"), InterpreterId = Guid.Parse("9dfae902-8fd6-4551-be3a-3b8f5aa53bb8") },
                new { BookId = Guid.Parse("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), InterpreterId = Guid.Parse("9dfae902-8fd6-4551-be3a-3b8f5aa53bb8") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), InterpreterId = Guid.Parse("11b6c2ed-98fe-4322-93c6-50197766fd9f") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), InterpreterId = Guid.Parse("a549b273-8114-420c-ae56-e9d9163c1668") },
                new { BookId = Guid.Parse("8c038acd-17db-4554-a741-de98ca121256"), InterpreterId = Guid.Parse("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e") },
                new { BookId = Guid.Parse("7db924d8-00a7-4b46-9e31-73d95c38eb31"), InterpreterId = Guid.Parse("a549b273-8114-420c-ae56-e9d9163c1668") },
                new { BookId = Guid.Parse("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), InterpreterId = Guid.Parse("a549b273-8114-420c-ae56-e9d9163c1668") },
                new { BookId = Guid.Parse("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), InterpreterId = Guid.Parse("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e") },
                new { BookId = Guid.Parse("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), InterpreterId = Guid.Parse("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e") },
                new { BookId = Guid.Parse("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), InterpreterId = Guid.Parse("fec297d0-8287-42f3-81bd-311ae1b0c6c6") },
                new { BookId = Guid.Parse("f0317cfb-e110-4b92-97b9-a52595cefccd"), InterpreterId = Guid.Parse("fec297d0-8287-42f3-81bd-311ae1b0c6c6") },
                new { BookId = Guid.Parse("4b9c14fd-7788-4c89-b778-459ee7a4415b"), InterpreterId = Guid.Parse("fec297d0-8287-42f3-81bd-311ae1b0c6c6") }
            );
        }
    }
}
