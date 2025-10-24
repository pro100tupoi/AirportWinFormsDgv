using System.ComponentModel.DataAnnotations;
using AirportWinFormsDgv.Constants;

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
        [Display(Name = "Номер рейса")]
        [Required(ErrorMessage = "{0} обязателен для заполнения")]
        [StringLength(VadimConstants.FlightNumberMaxLength, ErrorMessage = "{0} должен быть не более {1} символов")]
        public string Flightnumber { get; set; } = string.Empty;

        /// <inheritdoc cref="Classes.Aircrafttype"/>
        [Display(Name = "Тип воздушного судна")]
        public Aircrafttype Aircrafttype { get; set; }

        /// <summary>
        /// Время прибытия
        /// </summary>
        [Display(Name = "Время прибытия")]
        public DateTime Arrivaltime { get; set; }

        /// <summary>
        /// Количество пассажиров
        /// </summary>
        [Display(Name = "Количество пассажиров")]
        [Range(VadimConstants.NumberOfPassengersMin, VadimConstants.NumberOfPassengersMax, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int Numberofpassengers { get; set; }

        /// <summary>
        /// Сбор на пассажира
        /// </summary>
        [Display(Name = "Сбор на пассажира")]
        [Range(VadimConstants.TaxPerPassengerMin, VadimConstants.TaxPerPassengerMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal Taxperpassenger { get; set; }

        /// <summary>
        /// Количество экипажа
        /// </summary>
        [Display(Name = "Количество экипажа")]
        [Range(VadimConstants.NumberOfCrewMin, VadimConstants.NumberOfCrewMax, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int Numberofcrew { get; set; }

        /// <summary>
        /// Сбор на экипаж
        /// </summary>
        [Display(Name = "Сбор на экипаж")]
        [Range(VadimConstants.TaxPerCrewMin, VadimConstants.TaxPerCrewMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal Taxpercrew { get; set; }

        /// <summary>
        /// Процент надбавки за обслуживание
        /// </summary>
        [Display(Name = "Процент надбавки за обслуживание")]
        [Range(VadimConstants.ServicePercentageMin, VadimConstants.ServicePercentageMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal Servicepercentage { get; set; }

        /// <summary>
        /// Выручка ((пассажиры * сбор + экипаж * сбор) + процент надбавки
        /// </summary>
        [Display(Name = "Выручка")]
        public decimal Revenue =>
            (Numberofpassengers * Taxperpassenger + Numberofcrew * Taxpercrew) + Servicepercentage;
    }
}
