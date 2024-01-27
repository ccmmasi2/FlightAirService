using Flight.AirService.AccessData.Data;
using Flight.AirService.AccessData.ObjectRepository.Interface;
using Flight.AirService.AccessData.Repository.Implementation;
using Flight.AirService.DTOObjects.Models;
using Newtonsoft.Json;

namespace Flight.AirService.AccessData.ObjectRepository.Implementation
{
    public class FlightDTLRepository : Repository<FlightDTL>, IFlightDTLRepository
    {
        private readonly AppDbContext _dbcontext;

        public FlightDTLRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task GetServiceData()
        {
            string url = "https://recruiting-api.newshore.es/api/flights/2";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        var flights = JsonConvert.DeserializeObject<FlightNewShoreDTO[]>(jsonContent);

                        foreach (var flight in flights)
                        {
                            Console.WriteLine($"Salida: {flight.DepartureStation}, Llegada: {flight.ArrivalStation}, " +
                                              $"Aerolínea: {flight.FlightCarrier}, Número de Vuelo: {flight.FlightNumber}, " +
                                              $"Precio: {flight.Price}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error al obtener los datos. Código de estado: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
