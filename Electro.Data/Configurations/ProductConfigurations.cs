using Electro.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Electro.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Configure primary key
            builder.HasKey(p => p.Id);

            // Configure properties
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired()
                .HasDefaultValue("Hello");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Decimal is not Nullable

            builder.Property(p => p.StockQuantity)
                .IsRequired();

            builder.Property(p => p.SKU)
                .IsRequired(false)
                .HasMaxLength(100); // Ensure SKU is unique

            builder.Property(p => p.TopSelling)
                .HasDefaultValue(false);

            builder.Property(p => p.IsAvailable)
                .HasDefaultValue(true)
                .IsRequired(); // Assuming products are available by default

            builder.Property(p => p.ImageURL)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(p => p.DateAdded)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date/time

            builder.Property(p => p.LastUpdated)
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValue("Unknown");

            builder.Property(p => p.Brand)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.Dimensions)
                .HasMaxLength(50)
                .HasDefaultValue("4x4");

            builder.Property(p => p.Weight)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.Color)
                .HasMaxLength(50)
                .IsRequired(false);
            
            builder.Property(p => p.Material)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.Discount)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.FinalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ShippingWeight)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.ShippingCost)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Rating)
                .HasDefaultValue(0)
                .HasMaxLength(5)
                .IsRequired();

            // Configure relationships
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.CartItemsList)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.FavouriteItemsList)
                .WithOne(fi => fi.Product)
                .HasForeignKey(fi => fi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.OrderItemsList)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ReviewsList)
                .WithOne(pr => pr.Product)
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Database Optimization

            // Create index on Name property for faster search operations
            builder.HasIndex(p => p.Name)
                .HasDatabaseName("IX_Product_Name");

            // Create Index on CategoryId for optimized filtering by category
            builder.HasIndex(p => p.CategoryId)
                .HasDatabaseName("IX_Product_CategoryId");

            // Create composite index on Price and StockQuantity to optimize sorting and filtering
            builder.HasIndex(p => new { p.Price, p.StockQuantity })
                .HasDatabaseName("IX_Product_Price_StockQuantity");

            // Configure table name
            builder.ToTable("Products");
        }
    }
}
