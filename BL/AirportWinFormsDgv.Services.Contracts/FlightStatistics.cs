namespace AirportWinFormsDgv.BL.Services.Contracts
{
    /// <summary>
    /// Статистика по рейсам
    /// </summary>
    public class FlightStatistics
    {
        /// <summary>
        /// Общее количество рейсов
        /// </summary>
        public int TotalFlights { get; set; }

        /// <summary>
        /// Общее количество пассажиров
        /// </summary>
        public int TotalPassengers { get; set; }

        /// <summary>
        /// Общее количество экипажа
        /// </summary>
        public int TotalCrew { get; set; }

        /// <summary>
        /// Сумма всей выручки
        /// </summary>
        public decimal TotalRevenue { get; set; }
    }
}
