using AirportWinFormsDgv.BL.Services;
using AirportWinFormsDgv.BL.Services.Contracts;
using AirportWinFormsDgv.DAL.Entities.Models;

namespace AirportWinFormsDgv.App.Forms
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IFlightServices flightService;
        private readonly BindingSource bindingSource = [];

        /// <summary>
        /// Инициализирует экземпляр <see cref="MainForm"/>
        /// </summary>
        public MainForm(IFlightServices flightService)
        {
            InitializeComponent();
            this.flightService = flightService;
            dataGridViewflights.AutoGenerateColumns = false;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var item1 =
                new FlightModel
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "SU-213",
                    AircraftType = AircraftType.Airbus,
                    ArrivalTime = DateTime.Now.AddDays(1),
                    NumberOfPassengers = 150,
                    TaxPerPassenger = 250.50m,
                    NumberOfCrew = 8,
                    TaxPerCrew = 120.75m,
                    ServicePercentage = 15.5m
                };

            var item2 =
                new FlightModel
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "BA-456",
                    AircraftType = AircraftType.Boeing,
                    ArrivalTime = DateTime.Now.AddDays(2).AddHours(3),
                    NumberOfPassengers = 85,
                    TaxPerPassenger = 180.00m,
                    NumberOfCrew = 6,
                    TaxPerCrew = 100.25m,
                    ServicePercentage = 12.0m
                };

            await flightService.AddFlightAsync(item1);
            await flightService.AddFlightAsync(item2);

            await LoadData();
        }

        private async Task LoadData()
        {
            var flights = await flightService.GetAllFlightsAsync();
            bindingSource.DataSource = flights.ToList();
            dataGridViewflights.DataSource = bindingSource;
            await SetStatistic();
        }

        private async Task OnUpdate()
        {
            var flights = await flightService.GetAllFlightsAsync();
            bindingSource.DataSource = flights.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistic();
        }

        private async Task SetStatistic()
        {
            var flights = await flightService.GetAllFlightsAsync();
            var statistics = await flightService.GetStatisticsAsync();

            toolStripStatusLabelArrivingflights.Text = $"прибывающих рейсов: {statistics.TotalFlights}";
            toolStripStatusLabelTotalnumberofcrew.Text = $"общее количество экипажа: {statistics.TotalCrew}";
            toolStripStatusLabelTotalnumberofpassengers.Text = $"общее количество пассажиров: {statistics.TotalPassengers}";
            toolStripStatusLabelTotalrevenue.Text = $"сумма всей выручки: {statistics.TotalRevenue:F2}";
        }

        private async void dataGridViewFlights_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridViewflights.Columns[e.ColumnIndex];
            var flight = (FlightModel)dataGridViewflights.Rows[e.RowIndex].DataBoundItem;
            if (flight == null)
            {
                return;
            }

            if (col.DataPropertyName == nameof(FlightModel.AircraftType))
            {
                e.Value = flight.AircraftType switch
                {
                    AircraftType.Airbus => "Эйрбас",
                    AircraftType.Boeing => "Боинг",
                    AircraftType.UnitedAircraftCorporation => "ОАК",
                    _ => string.Empty,
                };
            }

            if (col.Name == "RevenueColumn")
            {
                var revenue = await flightService.CalculateRevenueAsync(flight);
                e.Value = revenue.ToString("0.00");
                e.FormattingApplied = true;
            }
        }

        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await flightService.AddFlightAsync(addForm.CurrentFlight);
                await OnUpdate();
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewflights.SelectedRows.Count == 0)
            {
                return;
            }

            var flight = (FlightModel)dataGridViewflights.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить '{flight.FlightNumber}'?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await flightService.DeleteFlightAsync(flight.Id);
                await OnUpdate();
            }
        }

        private async void toolStripButtonEditing_Click(object sender, EventArgs e)
        {
            if (dataGridViewflights.SelectedRows.Count == 0)
            {
                return;
            }

            var flight = (FlightModel)dataGridViewflights.SelectedRows[0].DataBoundItem;

            var editForm = new AddEditForm(flight);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await flightService.UpdateFlightAsync(editForm.CurrentFlight);
                await OnUpdate();
            }
        }
    }
}
