using AirportWinFormsDgv.DAL.Entities.Models;

namespace AirportWinFormsDgv.BL.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления информацией о рейсах
    /// </summary>
    public interface IFlightServices
    {
        /// <summary>
        /// Получить все рейсы
        /// </summary>
        Task<List<FlightModel>> GetAllFlightsAsync(CancellationToken cancellationToken = default);

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
        Task<FlightStatistics> GetStatisticsAsync(CancellationToken cancellationToken = default);
    }
}
