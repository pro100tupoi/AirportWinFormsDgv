using AirportWinFormsDgv.DAL.Entities.Models;
using AirportWinFormsDgv.DAL.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AirportWinFormsDgv.DAL.DatabaseStorage
{
    /// <summary>
    /// Хранилище в виде базы данных.
    /// </summary>
    public class FlightDatabaseStorage : IStorage
    {
        /// <inheritdoc />
        public async Task AddFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            using var database = new FlightDatabaseContext();
            database.Flights.Add(flight);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<FlightModel>> GetAllFlightsAsync(CancellationToken cancellationToken = default)
        {
            using var database = new FlightDatabaseContext();
            var flights = await database.Flights.AsNoTracking().ToListAsync(cancellationToken);
            return flights;
        }

        /// <inheritdoc />
        public async Task DeleteFlightAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var database = new FlightDatabaseContext();
            var flight = await database.Flights.FindAsync([id], cancellationToken); // Используем FindAsync для поиска по ID
            if (flight != null)
            {
                database.Flights.Remove(flight);
                await database.SaveChangesAsync(cancellationToken);
            }
        }

        /// <inheritdoc />
        public async Task UpdateFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            using var database = new FlightDatabaseContext();
            database.Flights.Update(flight);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<FlightModel?> GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var database = new FlightDatabaseContext();
            var flight = await database.Flights.FindAsync([id], cancellationToken);
            return flight;
        }

        /// <inheritdoc />
        public async Task<FlightStorageStatistics> GetStatisticsAsync(CancellationToken cancellationToken = default)
        {
            using var database = new FlightDatabaseContext();
            var flights = await database.Flights.AsNoTracking().ToListAsync(cancellationToken);

            // Вычисляем статистику
            var stats = new FlightStorageStatistics
            {
                TotalFlights = flights.Count,
                TotalPassengers = flights.Sum(f => f.NumberOfPassengers),
                TotalCrew = flights.Sum(f => f.NumberOfCrew),
                TotalRevenue = flights.Sum(f => (f.NumberOfPassengers * f.TaxPerPassenger + f.NumberOfCrew * f.TaxPerCrew) + f.ServicePercentage)
            };

            return stats;
        }

        /// <inheritdoc />
        public async Task<decimal> CalculateRevenueAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            var result = (flight.NumberOfPassengers * flight.TaxPerPassenger +
                          flight.NumberOfCrew * flight.TaxPerCrew) +
                         flight.ServicePercentage;

            return result;
        }
    }
}
