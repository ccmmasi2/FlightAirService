using Flight.AirService.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Flight.AirService.AccessData.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Transport> Transport { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<FlightDTL> FlightDTL { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
