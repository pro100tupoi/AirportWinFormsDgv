using AirportWinFormsDgv.DAL.Entities.Models;
using AirportWinFormsDgv.DAL.Repository.Contracts;

namespace AirportWinFormsDgv.Web.Models
{
    /// <summary>
    /// Модель представления для главной страницы рейсов.
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Список рейсов для отображения.
        /// </summary>
        public IEnumerable<FlightModel> Flights { get; set; } = new List<FlightModel>();

        /// <summary>
        /// Статистика по рейсам.
        /// </summary>
        public FlightStorageStatistics Statistics { get; set; } = new();
    }
}
