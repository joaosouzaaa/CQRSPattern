using CQRSPattern.CrossCutting.Constants;
using CQRSPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRSPattern.DatabaseSettings.EntitiesMapping;

internal sealed class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(TableNamesConstants.Book);

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .HasColumnName("id");

        builder.Property(b => b.Title)
               .IsRequired(true)
               .HasColumnName("title")
               .HasColumnType("varchar(150)");

        builder.Property(b => b.Author)
               .IsRequired(true)
               .HasColumnName("author")
               .HasColumnType("varchar(100)");

        builder.Property(b => b.Gender)
               .IsRequired(true)
               .HasColumnName("gender");

        builder.Property(b => b.PublicationDate)
               .IsRequired(true)
               .HasColumnName("publication_date")
               .HasColumnType("datetime2");
    }
}
