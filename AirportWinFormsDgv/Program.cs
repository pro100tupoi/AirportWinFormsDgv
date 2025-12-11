using AirportWinFormsDgv.App.Forms;
using AirportWinFormsDgv.BL.Services;
using AirportWinFormsDgv.DAL.DatabaseStorage;
using AirportWinFormsDgv.DAL.Repository;
using Serilog;
using Serilog.Extensions.Logging;

namespace AirportWinFormsDgv.App
{
    /// <summary>
    /// Класс точки входа в приложение.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Класс точки входа в приложение.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Seq("http://localhost:5341",
                apiKey: "0GUsqcpXOHLJXZh6vDne")
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
            .CreateLogger();

            var loggerFactory = new SerilogLoggerFactory(Log.Logger, dispose: true);

            var storage = new FlightDatabaseStorage();
            var service = new FlightService(storage, loggerFactory);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}
