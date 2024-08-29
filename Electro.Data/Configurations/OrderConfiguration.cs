using Electro.Data.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electro.Data.Enums;

namespace Electro.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Configure primary key
            builder.HasKey(o => o.Id);

            // Configure properties
            builder.Property(o => o.UserId)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Status)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<OrderStatus>(v))
                .HasMaxLength(20);

            builder.Property(o => o.ShippingAddress)
                .HasMaxLength(250);

            builder.Property(o => o.BillingAddress)
                .HasMaxLength(250);

            builder.Property(o => o.TrackingNumber)
                .HasMaxLength(50);

            // Configure indexes
            builder.HasIndex(o => o.OrderDate);  // Optimize for queries based on OrderDate
            builder.HasIndex(o => o.Status);     // Optimize for queries based on Status
            builder.HasIndex(o => o.TrackingNumber).IsUnique(); // Ensure unique tracking numbers

            // Configure relationships
            builder.HasOne(o => o.User)
                .WithMany(u => u.OrderList)  // Assuming User has a collection of Orders
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Configure the entity as a table with optimized settings
            builder.ToTable("Orders");  // Explicitly name the table
        }
    }

}
