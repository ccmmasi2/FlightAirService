using Flight.AirService.AccessData.ObjectRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight.AirService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirServiceController : ControllerBase
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IJourneyRepository _journeyRepository;
        private readonly IFlightDTLRepository _flightDTLRepository;
        private readonly ILogger<AirServiceController> _logger;

        public AirServiceController(ITransportRepository transportRepository, IJourneyRepository journeyRepository, IFlightDTLRepository flightDTLRepository, ILogger<AirServiceController> logger)
        {
            _transportRepository = transportRepository;
            _journeyRepository = journeyRepository;
            _flightDTLRepository = flightDTLRepository;
            _logger = logger;
        }
    }
}
