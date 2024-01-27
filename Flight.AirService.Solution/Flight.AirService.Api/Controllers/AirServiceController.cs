using Flight.AirService.AccessData.ObjectRepository.Interface;
using Flight.AirService.DTOObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet("GetAsociatedFlights")]
        public async Task<IActionResult> GetAsociatedFlights(string origin, string destination)
        {
            try
            {
                if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
                {
                    return BadRequest("parameters 'origin' y 'destination' are required.");
                }

                FlightNewShoreDTO[] LFlights = await GetServiceData();
                Transport objectTransportIn = new Transport();
                Journey objectJourneyIn = new Journey();
                FlightDTL objectFlightDTLIn = new FlightDTL();

                FlightNewShoreDTO[] matchingFlights = LFlights
                                                       .Where(flight => flight.DepartureStation == origin && flight.ArrivalStation == destination)
                                                       .ToArray();

                objectJourneyIn = new Journey();
                objectJourneyIn.Client = "web";
                objectJourneyIn.Date = DateTime.Now;
                objectJourneyIn.Destination = destination;
                objectJourneyIn.Origin = origin;
                objectJourneyIn.TotalPrice = 0;
                int objectJourneyIn_ID = _journeyRepository.InsertSink(objectJourneyIn, entity => entity.ID);

                foreach (FlightNewShoreDTO item in matchingFlights)
                {
                    objectTransportIn = new Transport();
                    objectTransportIn.FlightCarrier = item.FlightCarrier;
                    objectTransportIn.FlightNumber = item.FlightNumber;
                    int objectTransportIn_ID = _transportRepository.InsertIfNotExistSink(objectTransportIn, entity => entity.ID);

                    objectFlightDTLIn = new FlightDTL();
                    objectFlightDTLIn.Origin = item.DepartureStation;
                    objectFlightDTLIn.Destination = item.ArrivalStation;
                    objectFlightDTLIn.Price = item.Price;
                    objectFlightDTLIn.IDTransport = objectTransportIn_ID;
                    objectFlightDTLIn.IDJourney = objectJourneyIn_ID;
                    int objectFlightDTLIn_ID = _flightDTLRepository.InsertSink(objectFlightDTLIn, entity => entity.ID);
                }

                return Ok("Evento ViajesAsociados ejecutado correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al ejecutar el evento ViajesAsociados: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
        } 


        public async Task<FlightNewShoreDTO[]> GetServiceData()
        {
            string url = "https://recruiting-api.newshore.es/api/flights/2";
            FlightNewShoreDTO[] flights = null;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    flights = JsonConvert.DeserializeObject<FlightNewShoreDTO[]>(jsonContent);
                }
            }

            return flights;
        }
    }
}
