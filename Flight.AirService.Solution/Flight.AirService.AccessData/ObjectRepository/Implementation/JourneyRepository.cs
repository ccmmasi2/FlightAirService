using Flight.AirService.AccessData.Data;
using Flight.AirService.AccessData.ObjectRepository.Interface;
using Flight.AirService.AccessData.Repository.Implementation;
using Flight.AirService.DTOObjects.Models;

namespace Flight.AirService.AccessData.ObjectRepository.Implementation
{
    public class JourneyRepository : Repository<Journey>, IJourneyRepository
    {
        private readonly AppDbContext _dbcontext;

        public JourneyRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
