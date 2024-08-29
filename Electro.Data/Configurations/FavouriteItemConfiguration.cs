using Electro.Data.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Configurations
{
    public class FavouriteItemConfiguration : IEntityTypeConfiguration<FavouriteItem>
    {
        public void Configure(EntityTypeBuilder<FavouriteItem> builder)
        {
            // Configure primary key
            builder.HasKey(fi => fi.Id);

            // Configure properties
            builder.Property(fi => fi.FavoriteListId)
                .IsRequired();

            builder.Property(fi => fi.ProductId)
                .IsRequired();

            builder.Property(fi => fi.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(fi => fi.AddedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Configure relationships
            builder.HasOne(fi => fi.FavoriteList)
                .WithMany(fl => fl.FavoriteItems)
                .HasForeignKey(fi => fi.FavoriteListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fi => fi.Product)
                .WithMany(p => p.FavouriteItemsList)
                .HasForeignKey(fi => fi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes and Optimizations
            builder.HasIndex(fi => fi.FavoriteListId).HasDatabaseName("IX_FavouriteItem_FavoriteListId");
            builder.HasIndex(fi => fi.ProductId).HasDatabaseName("IX_FavouriteItem_ProductId");

            // Table mapping
            builder.ToTable("FavouriteItems");
        }
    }
}