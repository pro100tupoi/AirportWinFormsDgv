using System.ComponentModel.DataAnnotations;
using AirportWinFormsDgv.Classes;

namespace AirportWinFormsDgv.Forms
{
    /// <summary>
    /// Форма добавления или редактирования рейса
    /// </summary>
    public partial class AddEditForm : Form
    {
        /// <summary>
        /// Возвращает текущий объект FlightModel, созданный или изменённый в этой форме
        /// </summary>
        public FlightModel CurrentFlight => targetFlight;

        private readonly FlightModel targetFlight;
        private readonly ErrorProvider errorProvider = new ErrorProvider();
        /// <summary>
        /// Создаёт форму добавления или редактирования рейса
        /// </summary>
        /// <param name="sourceFlight">Модель рейса для редактирования или для создания нового.</param>
        public AddEditForm(FlightModel? sourceFlight = null)
        {
            if (sourceFlight != null)
            {
                targetFlight = new FlightModel
                {
                    Id = sourceFlight.Id,
                    FlightNumber = sourceFlight.FlightNumber,
                    AircraftType = sourceFlight.AircraftType,
                    ArrivalTime = sourceFlight.ArrivalTime,
                    NumberOfPassengers = sourceFlight.NumberOfPassengers,
                    TaxPerPassenger = sourceFlight.TaxPerPassenger,
                    NumberOfCrew = sourceFlight.NumberOfCrew,
                    TaxPerCrew = sourceFlight.TaxPerCrew,
                    ServicePercentage = sourceFlight.ServicePercentage,
                };
            }
            else
            {
                // Создаём новый пустой объект
                targetFlight = new FlightModel
                {
                    Id = Guid.NewGuid(),
                    FlightNumber = "",
                    AircraftType = AircraftType.Airbus,
                    ArrivalTime = DateTime.Now,
                    NumberOfPassengers = 0,
                    TaxPerPassenger = 0,
                    NumberOfCrew = 0,
                    TaxPerCrew = 0,
                    ServicePercentage = 0,
                };
            }

            InitializeComponent();
            comboBoxAircrafttype.DrawMode = DrawMode.OwnerDrawFixed;

            if (sourceFlight != null)
            {
                buttonAdd.Text = "Сохранить";
            }

            var aircraftTypes = Enum.GetValues<AircraftType>()
        .Where(x => x != AircraftType.Unknown)
        .ToArray();
            comboBoxAircrafttype.DataSource = aircraftTypes;

            comboBoxAircrafttype.AddBinding(x => x.SelectedItem!, targetFlight, x => x.AircraftType, errorProvider);
            textBoxFlightnumber.AddBinding(x => x.Text, targetFlight, x => x.FlightNumber, errorProvider);
            dateTimePickerArrivaltime.AddBinding(x => x.Value, targetFlight, x => x.ArrivalTime, errorProvider);
            numericUpDownNumberofpassengers.AddBinding(x => x.Value, targetFlight, x => x.NumberOfPassengers, errorProvider);
            numericUpDownTaxperpassenger.AddBinding(x => x.Value, targetFlight, x => x.TaxPerPassenger, errorProvider);
            numericUpDownNumberofcrew.AddBinding(x => x.Value, targetFlight, x => x.NumberOfCrew, errorProvider);
            numericUpDownTaxpercrew.AddBinding(x => x.Value, targetFlight, x => x.TaxPerCrew, errorProvider);
            numericUpDownServicepercentage.AddBinding(x => x.Value, targetFlight, x => x.ServicePercentage, errorProvider);

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var context = new ValidationContext(targetFlight);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(targetFlight, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в форме перед сохранением.",
               "Ошибки валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEscape_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxAircraftType_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                if (comboBoxAircrafttype.Items[e.Index] is AircraftType aircraftType)
                {
                    var text = aircraftType switch
                    {
                        AircraftType.Airbus => "Эйрбас",
                        AircraftType.Boeing => "Боинг",
                        AircraftType.UnitedAircraftCorporation => "ОАК",
                        _ => "-"
                    };

                    Brush brush = (e.State & DrawItemState.Selected) != 0
                        ? SystemBrushes.HighlightText
                        : SystemBrushes.ControlText;

                    e.Graphics.DrawString(text, e.Font!, brush, e.Bounds);
                }
            }
        }
    }
}
