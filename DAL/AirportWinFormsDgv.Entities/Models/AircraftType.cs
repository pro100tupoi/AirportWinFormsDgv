using System.ComponentModel.DataAnnotations;

namespace AirportWinFormsDgv.DAL.Entities.Models
{
    /// <summary>
    /// Тип самолёта
    /// </summary>
    public enum AircraftType : byte
    {
        /// <summary>
        /// Не известно
        /// </summary>
        [Display(Name = "Неизвестно")]
        Unknown = 0,

        /// <summary>
        /// Боинг
        /// </summary>
        [Display(Name = "Боинг")]
        Boeing = 1,

        /// <summary>
        /// Эйрбас
        /// </summary>
        [Display(Name = "Эйрбас")]
        Airbus = 2,

        /// <summary>
        /// Объединённая авиастроительная корпорация
        /// </summary>
        [Display(Name = "ОАК")]
        UnitedAircraftCorporation = 3,
    }
}
