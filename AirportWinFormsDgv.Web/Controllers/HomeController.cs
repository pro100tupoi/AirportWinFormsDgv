using System.Diagnostics;
using AirportWinFormsDgv.BL.Services.Contracts;
using AirportWinFormsDgv.DAL.Entities.Models;
using AirportWinFormsDgv.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportWinFormsDgv.Web.Controllers
{
    /// <summary>
    /// Контроллер для главной страницы.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IFlightServices flightServices;
        private readonly CancellationTokenSource cancellationTokenSource = new();

        public HomeController(IFlightServices flightServices)
        {
            this.flightServices = flightServices;
        }

        /// <summary>
        /// Отображает главную страницу со списком рейсов и статистикой.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var flightsTask = flightServices.GetAllFlightsAsync(cancellationTokenSource.Token);
            var statisticsTask = flightServices.GetStatisticsAsync(cancellationTokenSource.Token);

            var model = new IndexViewModel
            {
                Flights = (await flightsTask).ToList(),
                Statistics = await statisticsTask
            };

            return View(model);
        }

        /// <summary>
        /// Отображает форму для добавления нового рейса.
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new FlightModel
            {
                Id = Guid.NewGuid(),
                ArrivalTime = DateTime.Now,
                AircraftType = AircraftType.Airbus
            };
            return View(model);
        }

        /// <summary>
        /// Принимает данные нового рейса из формы и добавляет его.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(FlightModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await flightServices.AddFlightAsync(model, cancellationTokenSource.Token);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму редактирования существующего рейса.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var flight = await flightServices.GetFlightByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        /// <summary>
        /// Принимает изменения рейса из формы и сохраняет их.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(FlightModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await flightServices.UpdateFlightAsync(model, cancellationTokenSource.Token);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу подтверждения удаления рейса.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var flight = await flightServices.GetFlightByIdAsync(id, cancellationTokenSource.Token);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        /// <summary>
        /// Выполняет удаление рейса после подтверждения.
        /// </summary>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await flightServices.DeleteFlightAsync(id, cancellationTokenSource.Token);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу ошибки.
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
