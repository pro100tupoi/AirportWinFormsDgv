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
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер рейса
        /// </summary>
        [Display(Name = "Номер рейса")]
        [Required(ErrorMessage = "{0} обязателен для заполнения")]
        [StringLength(AppConstants.FlightNumberMaxLength, ErrorMessage = "{0} должен быть не более {1} символов")]
        public string FlightNumber { get; set; } = string.Empty;

        /// <inheritdoc cref="Classes.Aircrafttype"/>
        [Display(Name = "Тип воздушного судна")]
        public AircraftType AircraftType { get; set; }

        /// <summary>
        /// Время прибытия
        /// </summary>
        [Display(Name = "Время прибытия")]
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Количество пассажиров
        /// </summary>
        [Display(Name = "Количество пассажиров")]
        [Range(AppConstants.NumberOfPassengersMin, AppConstants.NumberOfPassengersMax, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int NumberOfPassengers { get; set; }

        /// <summary>
        /// Сбор на пассажира
        /// </summary>
        [Display(Name = "Сбор на пассажира")]
        [Range(AppConstants.TaxPerPassengerMin, AppConstants.TaxPerPassengerMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal TaxPerPassenger { get; set; }

        /// <summary>
        /// Количество экипажа
        /// </summary>
        [Display(Name = "Количество экипажа")]
        [Range(AppConstants.NumberOfCrewMin, AppConstants.NumberOfCrewMax, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int NumberOfCrew { get; set; }

        /// <summary>
        /// Сбор на экипаж
        /// </summary>
        [Display(Name = "Сбор на экипаж")]
        [Range(AppConstants.TaxPerCrewMin, AppConstants.TaxPerCrewMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal TaxPerCrew { get; set; }

        /// <summary>
        /// Процент надбавки за обслуживание
        /// </summary>
        [Display(Name = "Процент надбавки за обслуживание")]
        [Range(AppConstants.ServicePercentageMin, AppConstants.ServicePercentageMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal ServicePercentage { get; set; }

        /// <summary>
        /// Выручка ((пассажиры * сбор + экипаж * сбор) + процент надбавки
        /// </summary>
        [Display(Name = "Выручка")]
        public decimal Revenue { get; set; }
    }
}
