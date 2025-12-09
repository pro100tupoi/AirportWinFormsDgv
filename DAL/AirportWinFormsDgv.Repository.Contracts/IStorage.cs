using AirportWinFormsDgv.DAL.Entities.Models;

namespace AirportWinFormsDgv.DAL.Repository.Contracts
{
    /// <summary>
    /// Интерфейс хранилища сущностей
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Получить все рейсы
        /// </summary>
        Task<IReadOnlyCollection<FlightModel>> GetAllFlightsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Добавить новый рейс
        /// </summary>
        Task AddFlightAsync(FlightModel flight, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить рейс
        /// </summary>
        Task UpdateFlightAsync(FlightModel flight, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удалить рейс по ID
        /// </summary>
        Task DeleteFlightAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Найти рейс по ID
        /// </summary>
        Task<FlightModel?> GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Рассчитать выручку рейса
        /// </summary>
        Task<decimal> CalculateRevenueAsync(FlightModel flight, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить статистику по рейсам
        /// </summary>
        Task<FlightStorageStatistics> GetStatisticsAsync(CancellationToken cancellationToken = default);
    }
}
