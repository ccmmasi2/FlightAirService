using Flight.AirService.AccessData.Data;
using Flight.AirService.AccessData.ObjectRepository.Interface;
using Flight.AirService.AccessData.Repository.Implementation;
using Flight.AirService.DTOObjects.Models;

namespace Flight.AirService.AccessData.ObjectRepository.Implementation
{
    public class FlightDTLRepository : Repository<FlightDTL>, IFlightDTLRepository
    {
        private readonly AppDbContext _dbcontext;

        public FlightDTLRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
