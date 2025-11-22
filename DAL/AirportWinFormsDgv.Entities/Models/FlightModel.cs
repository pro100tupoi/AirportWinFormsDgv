using System.ComponentModel.DataAnnotations;
using AirportWinFormsDgv.Constants;

namespace AirportWinFormsDgv.DAL.Entities.Models
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
        [StringLength(ValidationConstants.FlightNumberMaxLength, ErrorMessage = "{0} должен быть не более {1} символов")]
        public string FlightNumber { get; set; } = string.Empty;

        /// <inheritdoc cref="Models.AircraftType"/>
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
        [Range(ValidationConstants.NumberOfPassengersMin, ValidationConstants.NumberOfPassengersMax, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int NumberOfPassengers { get; set; }

        /// <summary>
        /// Сбор на пассажира
        /// </summary>
        [Display(Name = "Сбор на пассажира")]
        [Range(ValidationConstants.TaxPerPassengerMin, ValidationConstants.TaxPerPassengerMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal TaxPerPassenger { get; set; }

        /// <summary>
        /// Количество экипажа
        /// </summary>
        [Display(Name = "Количество экипажа")]
        [Range(ValidationConstants.NumberOfCrewMin, ValidationConstants.NumberOfCrewMax, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int NumberOfCrew { get; set; }

        /// <summary>
        /// Сбор на экипаж
        /// </summary>
        [Display(Name = "Сбор на экипаж")]
        [Range(ValidationConstants.TaxPerCrewMin, ValidationConstants.TaxPerCrewMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal TaxPerCrew { get; set; }

        /// <summary>
        /// Процент надбавки за обслуживание
        /// </summary>
        [Display(Name = "Процент надбавки за обслуживание")]
        [Range(ValidationConstants.ServicePercentageMin, ValidationConstants.ServicePercentageMax, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal ServicePercentage { get; set; }
    }
}
