using Electro.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(b=>b.Id).
                IsRequired();

            builder.Property(b=>b.Title).
                IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Description).
                IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Author).
                IsRequired()
                .HasMaxLength(500);

            builder.Property(b=>b.Date)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.HasIndex(b => b.Title)
                .IsClustered(false);
            builder.ToTable("Blogs");

        }
    }
}
