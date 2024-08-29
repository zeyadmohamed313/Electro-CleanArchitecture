using Electro.Data.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electro.Data.Entites.Identity;

namespace Electro.Data.Configurations
{
    public class FavouriteListConfiguration : IEntityTypeConfiguration<FavouriteList>
    {
        public void Configure(EntityTypeBuilder<FavouriteList> builder)
        {
            // Configure primary key
            builder.HasKey(fl => fl.Id);

            // Configure properties
            builder.Property(fl => fl.UserId)
                .IsRequired();

            builder.Property(fl => fl.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(fl => fl.LastUpdated)
                .IsRequired(false);

            // Configure relationships
            builder.HasOne(fl => fl.User)
                .WithOne(u=>u.FavouriteList) 
                .HasForeignKey<User>(u => u.FavouriteListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(fl => fl.FavoriteItems)
                .WithOne(fi => fi.FavoriteList)
                .HasForeignKey(fi => fi.FavoriteListId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes and Optimizations
            builder.HasIndex(fl => fl.UserId)
                .HasDatabaseName("IX_FavouriteList_UserId");

            // Table mapping
            builder.ToTable("FavouriteLists");
        }
    }
}
