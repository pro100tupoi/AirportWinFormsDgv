using AirportWinFormsDgv.Classes;
using AirportWinFormsDgv.Forms;
using AirportWinFormsDgv.Services;

namespace AirportWinFormsDgv
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly List<FlightModel> items = new();
        private readonly BindingSource bindingSource = new();
        /// <summary>
        /// Инициализирует главную форму
        /// </summary>
        public MainForm()
        {
            var flight1 = new FlightModel
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
            flight1.Revenue = FlightCalculator.CalculateRevenue(flight1);
            items.Add(flight1);

            var flight2 = new FlightModel
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
            flight2.Revenue = FlightCalculator.CalculateRevenue(flight2);
            items.Add(flight2);

            InitializeComponent();
            SetStatistic();
            dataGridViewflights.AutoGenerateColumns = false;
            bindingSource.DataSource = items;
            dataGridViewflights.DataSource = bindingSource;
        }

        private void dataGridViewFlights_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Пропускаем заголовки и недопустимые строки
            if (e.RowIndex < 0)
            {
                return;
            }

            // Проверяем, что форматируем именно колонку AircraftType
            if (dataGridViewflights.Columns[e.ColumnIndex].DataPropertyName == nameof(FlightModel.AircraftType))
            {
                // e.Value уже содержит значение AircraftType
                if (e.Value is AircraftType aircraftType)
                {
                    e.Value = aircraftType switch
                    {
                        AircraftType.Airbus => "Эйрбас",
                        AircraftType.Boeing => "Боинг",
                        AircraftType.UnitedAircraftCorporation => "ОАК",
                        _ => string.Empty
                    };
                    e.FormattingApplied = true;
                }
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(addForm.CurrentFlight);
                RefreshDisplay();
            }
        }

        private void toolStripButtonEditing_Click(object sender, EventArgs e)
        {
            if (dataGridViewflights.SelectedRows.Count == 0)
            {
                return;
            }
            var flight = (FlightModel)dataGridViewflights.SelectedRows[0].DataBoundItem;

            var editForm = new AddEditForm(flight);
            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                var target = items.FirstOrDefault(x => x.Id == editForm.CurrentFlight.Id);
                if (target != null)
                {
                    target.FlightNumber = editForm.CurrentFlight.FlightNumber;
                    target.AircraftType = editForm.CurrentFlight.AircraftType;
                    target.ArrivalTime = editForm.CurrentFlight.ArrivalTime;
                    target.NumberOfPassengers = editForm.CurrentFlight.NumberOfPassengers;
                    target.TaxPerPassenger = editForm.CurrentFlight.TaxPerPassenger;
                    target.NumberOfCrew = editForm.CurrentFlight.NumberOfCrew;
                    target.TaxPerCrew = editForm.CurrentFlight.TaxPerCrew;
                    target.ServicePercentage = editForm.CurrentFlight.ServicePercentage;

                    target.Revenue = FlightCalculator.CalculateRevenue(target);
                    RefreshDisplay();
                }
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewflights.SelectedRows.Count == 0)
            {
                return;
            }

            var flight = (FlightModel)dataGridViewflights.SelectedRows[0].DataBoundItem;
            var target = items.FirstOrDefault(x => x.Id == flight.Id);
            if (target != null && MessageBox.Show($"Вы действительно хотите удалить '{target.FlightNumber}' ?", "Удаление рейса", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                items.Remove(target);
                RefreshDisplay();
            }
        }

        private void dataGridViewflights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewflights.SelectedRows.Count == 0)
            {
                return;
            }

            var flight = (FlightModel)dataGridViewflights.SelectedRows[0].DataBoundItem;
            var flightForm = new AddEditForm();
            if (flightForm.ShowDialog(this) == DialogResult.OK)
            {
                flight.FlightNumber = flightForm.CurrentFlight.FlightNumber;
            }
        }

        private void SetStatistic()
        {
            toolStripStatusLabelArrivingflights.Text = $"прибывающих рейсов:  {items.Count}";
            var totalCrew = items.Sum(flight => flight.NumberOfCrew);
            toolStripStatusLabelTotalnumberofcrew.Text = $"общее количество экипажа: {totalCrew}";
            var totalPassengers = items.Sum(flight => flight.NumberOfPassengers);
            toolStripStatusLabelTotalnumberofpassengers.Text = $"общее количество пассажиров: {totalPassengers}";
            var totalRevenue = items.Sum(flight => flight.Revenue);
            toolStripStatusLabelTotalrevenue.Text = $"сумма всей выручки: {totalRevenue:F2}";
        }

        private void RefreshDisplay()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }
    }
}
