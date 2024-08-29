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
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            // Configure primary key
            builder.HasKey(ci => ci.Id);

            // Configure properties
            builder.Property(ci => ci.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ci => ci.Quantity)
                .IsRequired();

            builder.Property(ci => ci.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Ignore(ci => ci.TotalPrice);  // Ignoring the computed property

            // Configure relationships
            builder.HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ToTable("CartItems");

        }
    }
}
