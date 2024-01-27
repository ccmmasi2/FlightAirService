using Flight.AirService.AccessData.Data;
using Flight.AirService.AccessData.ObjectRepository.Interface;
using Flight.AirService.AccessData.Repository.Implementation;
using Flight.AirService.DTOObjects.Models;

namespace Flight.AirService.AccessData.ObjectRepository.Implementation
{
    public class TransportRepository : Repository<Transport>, ITransportRepository
    {
        private readonly AppDbContext _dbcontext;

        public TransportRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
