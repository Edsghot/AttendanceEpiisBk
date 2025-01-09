using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AttendanceEpiisBk.Modules.Research.Domain.Entity;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class ScientificArticleEntityConfiguration : IEntityTypeConfiguration<ScientificArticleEntity>
{
    public void Configure(EntityTypeBuilder<ScientificArticleEntity> builder)
    {
        builder.ToTable("ScientificArticle");
        builder.HasKey(sa => sa.Id);

        builder.Property(sa => sa.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(sa => sa.Description)
            .HasMaxLength(1000);

        builder.Property(sa => sa.Summary)
            .HasMaxLength(2000);

        builder.Property(sa => sa.Date)
            .IsRequired();

        builder.Property(sa => sa.Doi)
            .HasMaxLength(100);

        builder.Property(sa => sa.Authors)
            .HasMaxLength(500);

        builder.Property(sa => sa.Pdf)
            .HasMaxLength(500);
        builder.Property(sa => sa.IdNivel);

        builder.Property(sa => sa.Editor)
            .HasMaxLength(255);
    }
}