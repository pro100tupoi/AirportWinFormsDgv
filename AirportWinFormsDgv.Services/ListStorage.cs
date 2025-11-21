using AirportWinFormsDgv.Entities.Models;
using AirportWinFormsDgv.Services.Contracts;

namespace AirportWinFormsDgv.Services
{
    /// <summary>
    /// Реализация IFlightServices с хранением данных в памяти
    /// </summary>
    public class ListStorage : IFlightServices
    {
        private readonly List<FlightModel> items;

        /// <summary>
        /// Инициализирует хранилище тестовыми данными
        /// </summary>
        public ListStorage()
        {
            items =
            [
                new FlightModel
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "SU-213",
                    AircraftType = AircraftType.Airbus,
                    ArrivalTime = DateTime.Now.AddDays(1),
                    NumberOfPassengers = 150,
                    TaxPerPassenger = 250.50m,
                    NumberOfCrew = 8,
                    TaxPerCrew = 120.75m,
                    ServicePercentage = 15.5m
                },

                new FlightModel
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "BA-456",
                    AircraftType = AircraftType.Boeing,
                    ArrivalTime = DateTime.Now.AddDays(2).AddHours(3),
                    NumberOfPassengers = 85,
                    TaxPerPassenger = 180.00m,
                    NumberOfCrew = 6,
                    TaxPerCrew = 100.25m,
                    ServicePercentage = 12.0m
                },
            ];
        }

        /// <summary>
        /// Асинхронно получить все рейсы
        /// </summary>
        /// <returns>Список всех рейсов</returns>
        public async Task<List<FlightModel>> GetAllFlightsAsync() => await Task.FromResult(items);

        /// <summary>
        /// Асинхронно добавить новый рейс
        /// </summary>
        /// <param name="flight">Рейс для добавления</param>
        public async Task AddFlightAsync(FlightModel flight)
        {
            await Task.CompletedTask;
            items.Add(flight);
        }

        /// <summary>
        /// Асинхронно обновить существующий рейс
        /// </summary>
        /// <param name="flight">Рейс с обновлёнными данными</param>
        public async Task UpdateFlightAsync(FlightModel flight)
        {
            await Task.CompletedTask;
            var index = items.FindIndex(f => f.Id == flight.Id);
            if (index >= 0)
            {
                items[index] = flight;
            }
        }

        /// <summary>
        /// Асинхронно удалить рейс по ID
        /// </summary>
        /// <param name="id">ID рейса для удаления</param>
        public async Task DeleteFlightAsync(Guid id)
        {
            await Task.CompletedTask;
            items.RemoveAll(f => f.Id == id);
        }

        /// <summary>
        /// Асинхронно найти рейс по ID
        /// </summary>
        /// <param name="id">ID рейса</param>
        /// <returns>Найденный рейс или null, если не найден</returns>
        public async Task<FlightModel?> GetFlightByIdAsync(Guid id) => await Task.FromResult(items.FirstOrDefault(f => f.Id == id));

        /// <summary>
        /// Асинхронно рассчитать выручку рейса
        /// </summary>
        /// <param name="flight">Рейс, для которого рассчитывается выручка</param>
        /// <returns>Вычисленная выручка</returns>
        /// <exception cref="ArgumentNullException">Если flight равен null</exception>
        public async Task<decimal> CalculateRevenueAsync(FlightModel flight)
        {
            await Task.CompletedTask;
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            return (flight.NumberOfPassengers * flight.TaxPerPassenger +
                    flight.NumberOfCrew * flight.TaxPerCrew) +
                   flight.ServicePercentage;
        }

        /// <summary>
        /// Асинхронно получить статистику по рейсам
        /// </summary>
        /// <param name="flights">Коллекция рейсов для расчёта статистики</param>
        /// <returns>Объект с данными статистики</returns>
        public async Task<(int TotalFlights, int TotalPassengers, int TotalCrew, decimal TotalRevenue)> GetStatisticsAsync(IEnumerable<FlightModel> flights)
        {
            await Task.CompletedTask;
            var list = flights.ToList();
            return (
                TotalFlights: list.Count,
                TotalPassengers: list.Sum(f => f.NumberOfPassengers),
                TotalCrew: list.Sum(f => f.NumberOfCrew),
                TotalRevenue: list.Sum(f => CalculateRevenue(f))
            );
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
