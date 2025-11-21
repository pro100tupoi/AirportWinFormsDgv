using AirportWinFormsDgv.BL.Services.Contracts;
using AirportWinFormsDgv.DAL.Entities.Models;

namespace AirportWinFormsDgv.BL.Services
{
    /// <summary>
    /// Реализация IFlightServices с хранением данных в памяти
    /// </summary>
    public class FlightStorage : IFlightServices
    {
        private readonly List<FlightModel> items = new List<FlightModel>();

        Task<List<FlightModel>> IFlightServices.GetAllFlightsAsync(CancellationToken cancellationToken = default) => Task.FromResult(items);

        Task IFlightServices.AddFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            items.Add(flight);
            return Task.CompletedTask;
        }

        Task IFlightServices.UpdateFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            var index = items.FindIndex(f => f.Id == flight.Id);
            if (index >= 0)
            {
                items[index] = flight;
            }
            return Task.CompletedTask;
        }

        Task IFlightServices.DeleteFlightAsync(Guid id, CancellationToken cancellationToken = default)
        {
            items.RemoveAll(f => f.Id == id);
            return Task.CompletedTask;
        }

        Task<FlightModel?> IFlightServices.GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default) => Task.FromResult(items.FirstOrDefault(f => f.Id == id));

        Task<decimal> IFlightServices.CalculateRevenueAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            var result = (flight.NumberOfPassengers * flight.TaxPerPassenger +
                    flight.NumberOfCrew * flight.TaxPerCrew) +
                   flight.ServicePercentage;

            return Task.FromResult(result);
        }

        async Task<FlightStatistics> IFlightServices.GetStatisticsAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            return new FlightStatistics
            {
                TotalFlights = items.Count,
                TotalPassengers = items.Sum(f => f.NumberOfPassengers),
                TotalCrew = items.Sum(f => f.NumberOfCrew),
                TotalRevenue = items.Sum(f => CalculateRevenue(f))
            };
        }

        // Вспомогательный метод для CalculateRevenue, чтобы не дублировать логику
        private decimal CalculateRevenue(FlightModel flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            return (flight.NumberOfPassengers * flight.TaxPerPassenger +
                    flight.NumberOfCrew * flight.TaxPerCrew) +
                   flight.ServicePercentage;
        }
    }
}
