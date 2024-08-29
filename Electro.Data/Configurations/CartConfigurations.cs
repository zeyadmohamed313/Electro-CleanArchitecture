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
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            // Configure Primary Key 
            builder.HasKey(c => c.Id);

            // Configure Properties 
            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.Property(c => c.LastUpdated)
                .IsRequired(false);

            // Configure relationships
            builder.HasOne(c => c.User)
                .WithOne(c=>c.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);


            // Assuming a scalar function GetTotalAmount exists in the database
            // Optional: Configure TotalAmount as computed column
            //builder.Property(c => c.TotalAmount)
            // .HasComputedColumnSql("[dbo].[GetTotalAmount](Id)");  

            builder.ToTable("Carts");
        }
    }
}
