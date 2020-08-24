using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

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
                .HasColumnType("nvarchar(100)");
            builder.Property(u => u.Role)
                .HasColumnType("nvarchar(30)");
        }
    }
}
