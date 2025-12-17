using System.ComponentModel.DataAnnotations;
using AirportWinFormsDgv.DAL.Entities.Models;

namespace AirportWinFormsDgv.Web.Models
{
    /// <summary>
    /// Модель представления для формы добавления/редактирования рейса.
    /// </summary>
    public class FlightFormViewModel
    {
        /// <summary>
        /// Заголовок страницы (например, "Добавление", "Изменение").
        /// </summary>
        public string PageTitle { get; set; } = "";

        /// <inheritdoc cref="FlightModel.Id"/>
        public Guid Id { get; set; }

        /// <inheritdoc cref="FlightModel.FlightNumber"/>
        [Display(Name = "Номер рейса")]
        [Required(ErrorMessage = "{0} обязателен для заполнения")]
        [StringLength(255, ErrorMessage = "{0} должен быть не более {1} символов")]
        public string FlightNumber { get; set; } = "";

        /// <inheritdoc cref="FlightModel.AircraftType"/>
        [Display(Name = "Тип воздушного судна")]
        public AircraftType AircraftType { get; set; }

        /// <inheritdoc cref="FlightModel.ArrivalTime"/>
        [Display(Name = "Время прибытия")]
        public DateTime ArrivalTime { get; set; }

        /// <inheritdoc cref="FlightModel.NumberOfPassengers"/>
        [Display(Name = "Количество пассажиров")]
        [Range(0, 255, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int NumberOfPassengers { get; set; }

        /// <inheritdoc cref="FlightModel.TaxPerPassenger"/>
        [Display(Name = "Сбор на пассажира")]
        [Range(0, 5000, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal TaxPerPassenger { get; set; }

        /// <inheritdoc cref="FlightModel.NumberOfCrew"/>
        [Display(Name = "Количество экипажа")]
        [Range(0, 50, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int NumberOfCrew { get; set; }

        /// <inheritdoc cref="FlightModel.TaxPerCrew"/>
        [Display(Name = "Сбор на экипаж")]
        [Range(0, 1000, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal TaxPerCrew { get; set; }

        /// <inheritdoc cref="FlightModel.ServicePercentage"/>
        [Display(Name = "Процент надбавки за обслуживание")]
        [Range(0, 100, ErrorMessage = "{0} должен быть от {1} до {2}")]
        public decimal ServicePercentage { get; set; }
    }
}
