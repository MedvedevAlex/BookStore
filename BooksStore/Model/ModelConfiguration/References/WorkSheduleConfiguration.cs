using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities.References;
using System;
using ViewModel.Enums;

namespace Model.ModelConfiguration.References
{
    class WorkSheduleConfiguration : IEntityTypeConfiguration<WorkShedule>
    {
        public void Configure(EntityTypeBuilder<WorkShedule> builder)
        {
            builder.HasKey(ws => ws.Id);

            builder.Property(ws => ws.StartTime)
                .HasColumnType("time");
            builder.Property(ws => ws.EndTime)
                .HasColumnType("time");
            builder.Property(ws => ws.Weekday)
                .HasColumnType("tinyint");

            builder.HasData(
                // Книжная штучка
                new { Id = Guid.Parse("905d9ed8-0bd5-402a-be16-73c021176c78"), ShopId = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(16, 0, 0), Weekday = Weekday.Monday },
                new { Id = Guid.Parse("da0a5d81-8a06-495e-be79-71cc5973b2b7"), ShopId = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Tuesday },
                new { Id = Guid.Parse("39e04286-1a37-4e7e-b00e-5b255b83fc10"), ShopId = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Wednesday },
                new { Id = Guid.Parse("b3e031f0-73c0-4d37-94a9-bd82339882d8"), ShopId = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Thursday },
                new { Id = Guid.Parse("d549b3f0-775b-45af-b425-d207b5afb637"), ShopId = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Friday },
                new { Id = Guid.Parse("e1137b08-edf1-4159-b0a1-0484e28eac72"), ShopId = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(14, 0, 0), Weekday = Weekday.Saturday },
                new { Id = Guid.Parse("e416bca8-0534-42a2-9002-46b3bf016d44"), ShopId = Guid.Parse("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(14, 0, 0), Weekday = Weekday.Sunday },
                // Большая закладка
                new { Id = Guid.Parse("d8fa07de-df5d-46e6-abe1-eb3552f083f4"), ShopId = Guid.Parse("c99eca84-3aa1-4a38-abe2-6b551571246d"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(16, 0, 0), Weekday = Weekday.Monday },
                new { Id = Guid.Parse("f99f1587-e3b0-4ac7-8b97-a552b2bb9423"), ShopId = Guid.Parse("c99eca84-3aa1-4a38-abe2-6b551571246d"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Tuesday },
                new { Id = Guid.Parse("2b832724-0faa-4e71-9af5-373052d6c368"), ShopId = Guid.Parse("c99eca84-3aa1-4a38-abe2-6b551571246d"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Wednesday },
                new { Id = Guid.Parse("d5d62b05-72c2-45ec-841a-3f1fb3c05938"), ShopId = Guid.Parse("c99eca84-3aa1-4a38-abe2-6b551571246d"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Thursday },
                new { Id = Guid.Parse("17a51ded-63d8-4eb7-9286-cced1e0a03ce"), ShopId = Guid.Parse("c99eca84-3aa1-4a38-abe2-6b551571246d"), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Friday },
                // Скрытая обложка
                new { Id = Guid.Parse("e750f5d4-b698-4196-8337-4551a672a4f4"), ShopId = Guid.Parse("bd0f8083-8072-4a25-8d13-90a85f2caeca"), StartTime = new TimeSpan(10, 30, 0), EndTime = new TimeSpan(16, 0, 0), Weekday = Weekday.Monday },
                new { Id = Guid.Parse("5bab269a-e2be-45d1-a867-ea7295bb6671"), ShopId = Guid.Parse("bd0f8083-8072-4a25-8d13-90a85f2caeca"), StartTime = new TimeSpan(10, 30, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Wednesday },
                new { Id = Guid.Parse("f4c53bb7-ff07-4be6-8657-72c5e54ed18d"), ShopId = Guid.Parse("bd0f8083-8072-4a25-8d13-90a85f2caeca"), StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(20, 0, 0), Weekday = Weekday.Thursday },
                new { Id = Guid.Parse("49efd4d4-624f-4a55-bf22-198b9e6924ac"), ShopId = Guid.Parse("bd0f8083-8072-4a25-8d13-90a85f2caeca"), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(18, 0, 0), Weekday = Weekday.Friday },
                new { Id = Guid.Parse("39dc4a1a-0bfc-4c7c-8d6b-77274d0d2947"), ShopId = Guid.Parse("bd0f8083-8072-4a25-8d13-90a85f2caeca"), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(15, 0, 0), Weekday = Weekday.Saturday }
            );
        }
    }
}
