using AirportWinFormsDgv.Entities.Models;

namespace AirportWinFormsDgv.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления информацией о рейсах
    /// </summary>
    public interface IFlightServices
    {
        /// <summary>
        /// Получить все рейсы
        /// </summary>
        Task<List<FlightModel>> GetAllFlightsAsync();

        /// <summary>
        /// Добавить новый рейс
        /// </summary>
        Task AddFlightAsync(FlightModel flight);

        /// <summary>
        /// Обновить рейс
        /// </summary>
        Task UpdateFlightAsync(FlightModel flight);

        /// <summary>
        /// Удалить рейс по ID
        /// </summary>
        Task DeleteFlightAsync(Guid id);

        /// <summary>
        /// Найти рейс по ID
        /// </summary>
        Task<FlightModel?> GetFlightByIdAsync(Guid id);

        /// <summary>
        /// Рассчитать выручку рейса
        /// </summary>
        Task<decimal> CalculateRevenueAsync(FlightModel flight);

        /// <summary>
        /// Получить статистику по рейсам
        /// </summary>
        Task<(int TotalFlights, int TotalPassengers, int TotalCrew, decimal TotalRevenue)> GetStatisticsAsync(IEnumerable<FlightModel> flights);
    }
}
