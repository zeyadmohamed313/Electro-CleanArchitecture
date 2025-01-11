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
    public class ChatMessageConfigurations : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasKey(x => x.Id);  

            builder.Property(c=>c.Message)
                .IsRequired();

            builder.Property(b=>b.ReceiverId)
                .IsRequired();

            builder.Property(b => b.SenderId)
                .IsRequired();

            builder.Property(b => b.Timestamp)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
