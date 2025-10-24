using System.Windows.Forms;
using AirportWinFormsDgv.Classes;
using AirportWinFormsDgv.Forms;

namespace AirportWinFormsDgv
{
    public partial class MainForm : Form
    {
        private readonly List<FlightModel> items;
        private readonly BindingSource bindingSource = new();
        public MainForm()
        {
            items = new List<FlightModel>();

            items.Add(new FlightModel
            {
                Id = Guid.NewGuid(),
                Flightnumber = "SU-213",
                Aircrafttype = Aircrafttype.Airbus,
                Arrivaltime = DateTime.Now.AddDays(1),
                Numberofpassengers = 150,
                Taxperpassenger = 250.50m,
                Numberofcrew = 8,
                Taxpercrew = 120.75m,
                Servicepercentage = 15.5m
            });
            items.Add(new FlightModel
            {
                Id = Guid.NewGuid(),
                Flightnumber = "BA-456",
                Aircrafttype = Aircrafttype.Boeing,
                Arrivaltime = DateTime.Now.AddDays(2).AddHours(3),
                Numberofpassengers = 85,
                Taxperpassenger = 180.00m,
                Numberofcrew = 6,
                Taxpercrew = 100.25m,
                Servicepercentage = 12.0m
            });
            InitializeComponent();
            SetStatistic();
            dataGridViewflights.AutoGenerateColumns = false;
            bindingSource.DataSource = items;
            dataGridViewflights.DataSource = bindingSource;
        }

        private void dataGridViewflights_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверка индекса строки
            // Убедимся, что индекс строки действителен и не превышает количество строк в DataSource
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewflights.RowCount - 1) // -1 если AllowUserToAddRows = true и последняя строка - для добавления
            {
                return;
            }

            var col = dataGridViewflights.Columns[e.ColumnIndex];

            // Проверяем, что DataBoundItem не null перед приведением типа
            var dataBoundItem = dataGridViewflights.Rows[e.RowIndex].DataBoundItem;
            if (col != null && col.DataPropertyName == nameof(FlightModel.Aircrafttype) && dataBoundItem is FlightModel airplane)
            {
                switch (airplane.Aircrafttype)
                {
                    case Aircrafttype.Airbus:
                        e.Value = "Эйрбас";
                        e.FormattingApplied = true;
                        break;
                    case Aircrafttype.UAC:
                        e.Value = "ОАК";
                        e.FormattingApplied = true;
                        break;
                    case Aircrafttype.Boeing:
                        e.Value = "Боинг";
                        e.FormattingApplied = true;
                        break;
                    default:
                        e.Value = string.Empty;
                        e.FormattingApplied = true;
                        break;
                }
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new FlightForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(addForm.CurrentFlight);
                //dataGridViewflights.DataSource = null;
                //dataGridViewflights.DataSource = items;
                Vadim_GAY();
            }
        }

        private void toolStripButtonEditing_Click(object sender, EventArgs e)
        {
            if (dataGridViewflights.SelectedRows.Count == 0)
            {
                return;
            }
            var flight = (FlightModel)dataGridViewflights.SelectedRows[0].DataBoundItem;

            var addForm = new FlightForm(flight);
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                var target = items.FirstOrDefault(x => x.Id == addForm.CurrentFlight.Id);
                if (target != null)
                {
                    target.Flightnumber = addForm.CurrentFlight.Flightnumber;
                    target.Aircrafttype = addForm.CurrentFlight.Aircrafttype;
                    target.Arrivaltime = addForm.CurrentFlight.Arrivaltime;
                    target.Numberofpassengers = addForm.CurrentFlight.Numberofpassengers;
                    target.Taxperpassenger = addForm.CurrentFlight.Taxperpassenger;
                    target.Numberofcrew = addForm.CurrentFlight.Numberofcrew;
                    target.Taxpercrew = addForm.CurrentFlight.Taxpercrew;
                    target.Servicepercentage = addForm.CurrentFlight.Servicepercentage;
                    Vadim_GAY();
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
            if (target != null && MessageBox.Show($"Вы действительно хотите удалить '{target.Flightnumber}' ?", "Удаление рейса", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                items.Remove(target);
                Vadim_GAY();
            }
        }

        private void dataGridViewflights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewflights.SelectedRows.Count == 0)
            { return; }

            var flight = (FlightModel)dataGridViewflights.SelectedRows[0].DataBoundItem;
            var FlightForm = new FlightForm();
            if (FlightForm.ShowDialog(this) == DialogResult.OK)
            {
                flight.Flightnumber = FlightForm.CurrentFlight.Flightnumber;
            }
        }

        private void SetStatistic()
        {
            toolStripStatusLabelArrivingflights.Text = $"прибывающих рейсов:  {items.Count}";
            var totalCrew = items.Sum(flight => flight.Numberofcrew);
            toolStripStatusLabelTotalnumberofcrew.Text = $"общее количество экипажа: {totalCrew}";
            var totalPassengers = items.Sum(flight => flight.Numberofpassengers);
            toolStripStatusLabelTotalnumberofpassengers.Text = $"общее количество пассажиров: {totalPassengers}";
            var totalRevenue = items.Sum(flight => flight.Revenue);
            toolStripStatusLabelTotalrevenue.Text = $"сумма всей выручки: {totalRevenue:F2}";
        }

        private void Vadim_GAY()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }
    }
}
