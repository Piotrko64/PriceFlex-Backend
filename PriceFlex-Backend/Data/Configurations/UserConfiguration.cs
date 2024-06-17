using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceFlex_Backend.Models;

namespace PriceFlex_Backend.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.Property(u => u.CreatedAt)
                   .IsRequired();
            builder.Property(u => u.UpdatedAt)
                   .IsRequired();
        }
    }
}