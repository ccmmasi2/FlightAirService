using Flight.AirService.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.AirService.AccessData.Configuration
{
    public class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.FlightCarrier).IsRequired().HasMaxLength(4);
            builder.Property(c => c.FlightNumber).IsRequired().HasMaxLength(4);
        }
    }
}
