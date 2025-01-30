using AttendanceEpiisBk.Modules.User.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.IdUser);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Mail)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(u => u.NameUser)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Phone)
            .HasMaxLength(15);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Gender)
            .IsRequired();

        builder.Property(u => u.Dni)
            .IsRequired()
            .HasMaxLength(20);
    }
}