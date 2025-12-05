using AirportWinFormsDgv.DAL.Entities.Models;
using AirportWinFormsDgv.DAL.Repository.Contracts;

namespace AirportWinFormsDgv.DAL.Repository
{
    /// <summary>
    /// Класс inMemory хранилища в виде списка <see cref="List{FlightModel}"/> для 
    /// объектов класса <see cref="FlightModel"/>
    /// </summary>
    public class InMemoryStorage : IStorage
    {
        private readonly List<FlightModel> items = new List<FlightModel>();

        Task<IReadOnlyCollection<FlightModel>> IStorage.GetAllFlightsAsync(CancellationToken cancellationToken = default) => Task.FromResult<IReadOnlyCollection<FlightModel>>(items);

        Task IStorage.AddFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            items.Add(flight);
            return Task.CompletedTask;
        }

        Task IStorage.UpdateFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            var index = items.FindIndex(f => f.Id == flight.Id);
            if (index >= 0)
            {
                items[index] = flight;
            }
            return Task.CompletedTask;
        }

        Task IStorage.DeleteFlightAsync(Guid id, CancellationToken cancellationToken = default)
        {
            items.RemoveAll(f => f.Id == id);
            return Task.CompletedTask;
        }

        Task<FlightModel?> IStorage.GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default) => Task.FromResult(items.FirstOrDefault(f => f.Id == id));

        Task<decimal> IStorage.CalculateRevenueAsync(FlightModel flight, CancellationToken cancellationToken = default)
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

        async Task<FlightStorageStatistics> IStorage.GetStatisticsAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            return new FlightStorageStatistics
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
