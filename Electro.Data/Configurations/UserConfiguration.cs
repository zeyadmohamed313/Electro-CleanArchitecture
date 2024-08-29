using Electro.Data.Entites.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electro.Data.Entites;

namespace Electro.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure primary key
            builder.HasKey(u => u.Id);

            // Configure properties
            builder.Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Age)
                .IsRequired(false);

            builder.Property(u => u.ProfilePictureUrl)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(u => u.DateOfBirth)
                .IsRequired(false);

            builder.Property(u => u.Gender)
                .HasMaxLength(10)
                .IsRequired(false);


            builder.Property(u => u.RegistrationDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.LastLoginDate)
                .IsRequired(false);

          

            // Configure relationships
            builder.HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.FavouriteList)
                .WithOne(fl => fl.User)
                .HasForeignKey<User>(u => u.FavouriteListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.OrderList)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Here i configure it as No Action to prevent Circular Cascade

            builder.HasMany(u => u.PaymentsList)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.ReviewsList)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes and Optimizations
            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_User_Email");

            // Table mapping
            builder.ToTable("Users");
        }
    }
}