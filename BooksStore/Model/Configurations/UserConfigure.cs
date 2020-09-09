using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.Configurations
{
    class UserConfigure : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Login)
                .HasColumnType("nvarchar(40)");
            builder.Property(u => u.Password)
                .HasColumnType("nvarchar(100)");
            builder.Property(u => u.Salt)
                .HasColumnType("nvarchar(24)");
            builder.Property(u => u.Role)
                .HasColumnType("nvarchar(30)");
            builder.Property(u => u.RefreshToken)
                .HasColumnType("nvarchar(48)");

            builder.HasData(
                new { Id = Guid.Parse("30be92d8-e0db-4386-9131-93d6cc4b7c47"), Login = "Admin", Password = "zkf+O+PEIGXDH1e3QH4VxzSZ+KmyTRdEAMcdTTZG2Us=", Salt = "TZWr5bFhm/4Q9aBMIcoWHg==", Role = "Admin", RefreshToken = "6tSd7w8IIfn/hjALkg956tmNv9B4D6Hln55ex5eeaqM=" },
                new { Id = Guid.Parse("54b6722e-1e29-4cc6-ada7-8d4edd5a13e4"), Login = "User", Password = "Vw1VEVsmrCT7Tatr3BjWm6AJ6qNQuDXQRy5g37Yn5G0=", Salt = "/bcwNvLg4NREg8EO13xenw==", Role = "Common", RefreshToken = "deVLGazeUzcekUIV3z35EDt6pV83KJT6bQvBPshdb9c=" },
                new { Id = Guid.Parse("108c5883-e2b7-4937-a04d-f7c059b8acd3"), Login = "Granula", Password = "T/e1VM+cbVU1QVb/NrU7u22Ozs985MqQxlXY0vsgLqU=", Salt = "Ln6EgB8gS3TyirdJ537Z4g==", Role = "Common", RefreshToken = "0FV7lKM5tM0tGfxe37/Ka4xOnaYgdjU5/T8VPPpJBfA=" },
                new { Id = Guid.Parse("367c6b4e-8650-481c-80d5-6db6bf583095"), Login = "1", Password = "joGTNbiLAhq6eGZC/IuVZ6vBOVyWNpxtusxSuK0CFX0=", Salt = "ZbG5fC/42FHLxbnUY3UhPQ==", Role = "Common", RefreshToken = "2kYrPG5rPVJwzi6skdwjXtngll0So2C14EvA4JIoq3U=" }
            );
        }
    }
}
