using Flight.AirService.DTOObjects.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Flight.AirService.AccessData.Configuration
{
    public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.Client).IsRequired().HasMaxLength(100); 
            builder.Property(c => c.Origin).IsRequired().HasMaxLength(3); 
            builder.Property(c => c.Destination).IsRequired().HasMaxLength(3);
            builder.Property(c => c.TotalPrice).IsRequired();
        }
    }
}
