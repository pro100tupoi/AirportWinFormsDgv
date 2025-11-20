namespace AirportWinFormsDgv.Entities.Models
{
    /// <summary>
    /// Тип самолёта
    /// </summary>
    public enum AircraftType : byte
    {
        /// <summary>
        /// Не известно
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Боинг
        /// </summary>
        Boeing = 1,

        /// <summary>
        /// Эйрбас
        /// </summary>
        Airbus = 2,

        /// <summary>
        /// Объединённая авиастроительная корпорация
        /// </summary>
        UnitedAircraftCorporation = 3,
    }
}
