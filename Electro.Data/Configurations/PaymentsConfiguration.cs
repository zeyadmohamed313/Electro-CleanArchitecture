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
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            // Configure primary key
            builder.HasKey(p => p.Id);


            // Configure properties
            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Method)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v))
                .HasMaxLength(20)
                .HasDefaultValue(PaymentMethod.CreditCard);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v))
                .HasMaxLength(20)
                .HasDefaultValue(PaymentStatus.Pending);

            builder.Property(p => p.PaymentDate)
                .IsRequired();

            builder.Property(p => p.ConfirmationDate)
                .IsRequired(false);

            builder.Property(p => p.TransactionId)
                .HasMaxLength(100);

            // Configure relationships
        

            builder.HasOne(p => p.User)
                .WithMany(u => u.PaymentsList)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Indexes for optimization
            builder.HasIndex(p => p.OrderId).HasDatabaseName("IX_Payments_OrderId");
            builder.HasIndex(p => p.UserId).HasDatabaseName("IX_Payments_UserId");

            // Map to table
            builder.ToTable("Payments");
        }
    }
}
