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
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Configure Key
            builder.HasKey(x => x.Id);

            // Configure Properties
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Configure Relation Ships
            builder.HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Create Index
            builder.HasIndex(x => x.Id)
                .HasDatabaseName("IX_Category_Name");

            // Naming 
            builder.ToTable("Categories");
        }
    }
}
