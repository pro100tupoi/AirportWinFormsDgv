namespace AirportWinFormsDgv.Constants
{
    /// <summary>
    /// Общие константы приложения
    /// </summary>
    public class ValidationConstants
    {
        /// <summary>
        /// Максимальная длина строки для номера рейса.
        /// </summary>
        public const int FlightNumberMaxLength = 255;

        /// <summary>
        /// Минимальное значение для количества пассажиров.
        /// </summary>
        public const int NumberOfPassengersMin = 1;

        /// <summary>
        /// Максимальное значение для количества пассажиров.
        /// </summary>
        public const int NumberOfPassengersMax = 255;

        /// <summary>
        /// Минимальное значение для сбора на пассажира.
        /// </summary>
        ///
        public const double TaxPerPassengerMin = 1;

        /// <summary>
        /// Максимальное значение для сбора на пассажира.
        /// </summary>
        public const double TaxPerPassengerMax = 5000;

        /// <summary>
        /// Минимальное значение для количества экипажа.
        /// </summary>
        public const int NumberOfCrewMin = 1;

        /// <summary>
        /// Максимальное значение для количества экипажа.
        /// </summary>
        public const int NumberOfCrewMax = 50;

        /// <summary>
        /// Минимальное значение для сбора на экипаж.
        /// </summary>
        public const double TaxPerCrewMin = 1;

        /// <summary>
        /// Максимальное значение для сбора на экипаж.
        /// </summary>
        public const double TaxPerCrewMax = 1000;

        /// <summary>
        /// Минимальное значение для процента надбавки за обслуживание.
        /// </summary>
        public const double ServicePercentageMin = 1;

        /// <summary>
        /// Максимальное значение для процента надбавки за обслуживание.
        /// </summary>
        public const double ServicePercentageMax = 100;
    }
}
