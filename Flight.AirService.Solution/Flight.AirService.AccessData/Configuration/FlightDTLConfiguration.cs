using Flight.AirService.DTOObjects.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Flight.AirService.AccessData.Configuration
{
    public class FlightDTLConfiguration : IEntityTypeConfiguration<FlightDTL>
    {
        public void Configure(EntityTypeBuilder<FlightDTL> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.IDTransport).IsRequired();
            builder.Property(c => c.IDJourney).IsRequired();
            builder.Property(c => c.Origin).IsRequired().HasMaxLength(3);
            builder.Property(c => c.Destination).IsRequired().HasMaxLength(3);
            builder.Property(c => c.Price).IsRequired();

            builder.HasOne(e => e.Transport).WithMany().HasForeignKey(e => e.IDTransport);
            builder.HasOne(e => e.Journey).WithMany().HasForeignKey(e => e.IDJourney);
        }
    }
}
