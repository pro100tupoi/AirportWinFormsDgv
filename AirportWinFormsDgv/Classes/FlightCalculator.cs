using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportWinFormsDgv.Classes
{
    public static class FlightCalculator
    {
        /// <summary>
        /// Вычисляет и возвращает выручку на основе значений в модели рейса.
        /// </summary>
        /// <param name="flight">Модель рейса.</param>
        /// <returns>Вычисленная выручка.</returns>
        public static decimal CalculateRevenue(FlightModel flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            // Формула: (пассажиры * сбор + экипаж * сбор) + процент надбавки
            return (flight.Numberofpassengers * flight.Taxperpassenger + flight.Numberofcrew * flight.Taxpercrew) + flight.Servicepercentage;
        }

        /// <summary>
        /// Обновляет свойство Revenue в модели рейса, вызывая CalculateRevenue.
        /// </summary>
        /// <param name="flight">Модель рейса для обновления.</param>
        public static void UpdateRevenue(FlightModel flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight));
            }

            flight.Revenue = CalculateRevenue(flight);
        }
    }
}
