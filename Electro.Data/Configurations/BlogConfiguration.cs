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
                IsRequired();
            builder.Property(b => b.Description).
                IsRequired();
            builder.Property(b=>b.Author).
                IsRequired();

            builder.HasIndex(b => b.Title);


            builder.ToTable("Blogs");

        }
    }
}
