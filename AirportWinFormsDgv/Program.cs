using AirportWinFormsDgv.App.Forms;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
