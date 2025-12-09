using System.Diagnostics;
using AirportWinFormsDgv.BL.Services.Contracts;
using AirportWinFormsDgv.DAL.Entities.Models;
using AirportWinFormsDgv.DAL.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace AirportWinFormsDgv.BL.Services
{
    /// <summary>
    /// Сервисный слой для работы с данными о рейсах
    /// </summary>
    public class FlightService(IStorage storage, ILoggerFactory loggerFactory) : IFlightServices
    {
        private readonly ILogger<FlightService> logger = loggerFactory.CreateLogger<FlightService>();

        /// <summary>
        /// Получить все рейсы
        /// </summary>
        public async Task<IReadOnlyCollection<FlightModel>> GetAllFlightsAsync(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var allFlights = await storage.GetAllFlightsAsync(cancellationToken);
                return allFlights;
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("FlightService.GetAllFlightsAsync выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Добавить новый рейс
        /// </summary>
        public async Task AddFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.AddFlightAsync(flight, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("FlightService.AddFlightAsync выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Обновить рейс
        /// </summary>
        public async Task UpdateFlightAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.UpdateFlightAsync(flight, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("FlightService.UpdateFlightAsync выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Удалить рейс по ID
        /// </summary>
        public async Task DeleteFlightAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.DeleteFlightAsync(id, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("FlightService.DeleteFlightAsync выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Найти рейс по ID
        /// </summary>
        public async Task<FlightModel?> GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var flight = await storage.GetFlightByIdAsync(id, cancellationToken);
                return flight;
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("FlightService.GetFlightByIdAsync выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Рассчитать выручку рейса
        /// </summary>
        public async Task<decimal> CalculateRevenueAsync(FlightModel flight, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                if (flight == null)
                {
                    logger.LogError("CalculateRevenueAsync: передан null-объект");
                    throw new ArgumentNullException(nameof(flight));
                }

                var result = (flight.NumberOfPassengers * flight.TaxPerPassenger +
                        flight.NumberOfCrew * flight.TaxPerCrew) +
                       flight.ServicePercentage;

                return result;
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("FlightService.CalculateRevenueAsync выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Получить статистику по рейсам
        /// </summary>
        public async Task<FlightStatistics> GetStatisticsAsync(CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var storageStats = await storage.GetStatisticsAsync(cancellationToken);

                // Преобразуем из FlightStorageStatistics в FlightStatistics
                var result = new FlightStatistics
                {
                    TotalFlights = storageStats.TotalFlights,
                    TotalPassengers = storageStats.TotalPassengers,
                    TotalCrew = storageStats.TotalCrew,
                    TotalRevenue = storageStats.TotalRevenue
                };

                return result;
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("FlightService.GetStatisticsAsync выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }
    }
}
