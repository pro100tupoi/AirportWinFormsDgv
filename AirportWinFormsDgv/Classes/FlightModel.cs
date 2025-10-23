using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirportWinFormsDgv.Classes
{
    /// <summary>
    /// Рейс
    /// </summary>
    public class FlightModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер рейса
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Flightnumber { get; set; } = string.Empty;

        /// <inheritdoc cref="Classes.Aircrafttype"/>
        public Aircrafttype Aircrafttype { get; set; }

        /// <summary>
        /// Время прибытия
        /// </summary>
        public DateTime Arrivaltime { get; set; }

        /// <summary>
        /// Количество пассажиров
        /// </summary>
        [Range(0, 255)]
        public int Numberofpassengers { get; set; }

        /// <summary>
        /// Сбор на пассажира
        /// </summary>
        [Range(0, 5000)]
        public decimal Taxperpassenger { get; set; }

        /// <summary>
        /// Количество экипажа
        /// </summary>
        [Range(0, 50)]
        public int Numberofcrew { get; set; }

        /// <summary>
        /// Сбор на экипаж
        /// </summary>
        [Range(0, 1000)]
        public decimal Taxpercrew { get; set; }

        /// <summary>
        /// Процент надбавки за обслуживание
        /// </summary>
        [Range(0, 100)]
        public decimal Servicepercentage { get; set; }

        /// <summary>
        /// Выручка ((пассажиры * сбор + экипаж * сбор) + процент надбавки
        /// </summary>
        public decimal Revenue { get; set; }
    }
}
