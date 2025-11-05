using AirportWinFormsDgv.Classes;

namespace AirportWinFormsDgv.Services
{
    /// <summary>
    /// Сервис для расчёта финансовых показателей рейса.
    /// </summary>
    public static class FlightCalculator
    {
        /// <summary>
        /// Вычисляет выручку рейса по формуле: 
        /// (пассажиры * сбор за пассажира + экипаж * сбор за экипаж) + процент надбавки.
        /// </summary>
        /// <param name="flight">Модель рейса.</param>
        /// <returns>Рассчитанная выручка.</returns>
        /// <exception cref="ArgumentNullException">Если <paramref name="flight"/> равен null.</exception>
        public static decimal CalculateRevenue(FlightModel flight)
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
