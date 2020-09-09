using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.Configurations
{
    class PainterConfigure : IEntityTypeConfiguration<Painter>
    {
        public void Configure(EntityTypeBuilder<Painter> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(40)");
            builder.Property(p => p.Age)
                .HasColumnType("tinyint");
            builder.Property(p => p.Description)
                .HasColumnType("nvarchar(1000)");

            builder.HasOne(p => p.Style);

            builder.HasData(
                new { Id = Guid.Parse("b849554a-3b05-4aff-9f81-ac1a4abbfc01"), Name = "Леонардо да Винчи", Age = (byte)67, StyleId = Guid.Parse("018c691d-5f4a-47fe-8fee-19d45877dabd"), Description = "Благодаря его картинам мировая живопись вышла на новый качественный уровень. Он двигался в сторону реализма, постигая законы перспективы и разбираясь в анатомическом строении человека." },
                new { Id = Guid.Parse("d18d0a39-9a5f-476f-8d52-bc0a23a371af"), Name = "Иероним Босх", StyleId = Guid.Parse("018c691d-5f4a-47fe-8fee-19d45877dabd"), Age = (byte)66, Description = "Полулюди-полумутанты, громадные птицы и рыбы, невиданные растения и толпы обнаженных грешников… Всё это перемешано и сплетено в многофигурные композиции." },
                new { Id = Guid.Parse("8e9093a9-8f64-4ef5-8d03-090c1ed062a5"), Name = "Рафаэль Санти", StyleId = Guid.Parse("fe4bb701-b2c2-40b5-ae4e-4e46edad36d1"), Age = (byte)37, Description = "Самый знаменитый представитель Эпохи Возрождения поражает гармоничными композициями и лиризмом." },
                new { Id = Guid.Parse("549903f5-66ab-48e8-b126-8610c4bb08b9"), Name = "Рембрандт Ха́рменс ван Рейн", StyleId = Guid.Parse("6801a5c4-fc35-468d-884f-75af47a288d6"), Age = (byte)63, Description = "Рембрандт изображал мир таким, какой он был. Без прикрас и лакировок. Но получалось у него это очень душевно." },
                new { Id = Guid.Parse("20035c22-62c5-4688-b21a-cff0007e871e"), Name = "Франсиско Хосе де Гойя-и-Лусьентес", StyleId = Guid.Parse("27078d1d-666a-4827-8f61-2683ae305f4d"), Age = (byte)82, Description = "Гойя начал свой творческий путь с юношеской пылкостью и идеализмом. Даже стал придворным художником при испанском дворе. Но вскоре пресытился жизнью, увидев алчность мира, тупость, ханжество." },
                new { Id = Guid.Parse("14587f65-7b1c-4171-b0f0-bf707284710f"), Name = "Иван Константинович Айвазовский", StyleId = Guid.Parse("791ddbdc-05ee-4a15-afbb-f866a978d5e7"), Age = (byte)82, Description = "йвазовский по праву находится в рейтинге самых известных художников. Его «Девятый вал» поражает своим масштабом." }
            );
        }
    }
}
