using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.ModelConfiguration
{
    class UserConfigure : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Login)
                .HasColumnType("nvarchar(40)");
            builder.Property(s => s.Password)
                .HasColumnType("nvarchar(100)");
            builder.Property(s => s.Salt)
                .HasColumnType("nvarchar(100)");
            builder.Property(s => s.Role)
                .HasColumnType("nvarchar(30)");
        }
    }
}
