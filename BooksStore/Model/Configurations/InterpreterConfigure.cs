using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.Configurations
{
    class InterpreterConfigure : IEntityTypeConfiguration<Interpreter>
    {
        public void Configure(EntityTypeBuilder<Interpreter> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name)
                .HasColumnType("nvarchar(40)");
            builder.Property(i => i.Age)
                .HasColumnType("tinyint");
            builder.Property(i => i.Description)
                .HasColumnType("nvarchar(1000)");

            builder.HasData(
                new { Id = Guid.Parse("9dfae902-8fd6-4551-be3a-3b8f5aa53bb8"), Name = "Павел Грушко", Age = (byte)66, Description = "Оригинальный поэт и переводчик разноликой, но всегда пылкой испанской поэзии, как нельзя лучше соответствующей его собственному пылкому темпераменту." },
                new { Id = Guid.Parse("11b6c2ed-98fe-4322-93c6-50197766fd9f"), Name = "Иннокентий Анненский", Age = (byte)45, Description = "Виднейший представитель Серебряного века, поэт-символист и пропагандист французских символистов, всё-таки как переводчик больше всего запомнился переложением античных классиков." },
                new { Id = Guid.Parse("a549b273-8114-420c-ae56-e9d9163c1668"), Name = "Борис Пастернак", Age = (byte)76, Description = "В отличие от Мандельштама и Цветаевой, к переводу обращавшихся пылко и стихийно, Пастернак был весьма трудолюбивым и продуктивным переводчиком."},
                new { Id = Guid.Parse("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e"), Name = "Рита Райт-Ковалева", Age = (byte)53, Description = "Именно с Раисой Яковлевной Ковалевой, писавшей под псевдонимом Рита Райт, связано возникновение литературного анекдота (зафиксированного или придуманного Довлатовым) о «писателях, сильно выигрывающих в переводе»."},
                new { Id = Guid.Parse("fec297d0-8287-42f3-81bd-311ae1b0c6c6"), Name = "Василий Аксёнов", Age = (byte)75, Description = "Известный писатель уверял, что взялся за перевод «Рэгтайма» Доктороу (вышел в 1976 году) только для того, чтобы подтянуть свой английский; но, кажется, всё-таки несколько лукавил."}
            );
        }
    }
}
