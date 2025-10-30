using System.ComponentModel.DataAnnotations;
using AirportWinFormsDgv.Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirportWinFormsDgv.Forms
{
    /// <summary>
    /// Форма добавления или редактирования рейса
    /// </summary>
    public partial class FlightForm : Form
    {
        private readonly FlightModel targetflight;

        /// <summary>
        /// Создаёт форму добавления или редактирования рейса
        /// </summary>
        /// <param name="sourceflight"></param>
        public FlightForm(FlightModel? sourceflight = null)
        {
            if (sourceflight != null)
            {
                targetflight = new FlightModel
                {
                    Id = sourceflight.Id,
                    Flightnumber = sourceflight.Flightnumber,
                    Aircrafttype = sourceflight.Aircrafttype,
                    Arrivaltime = sourceflight.Arrivaltime,
                    Numberofpassengers = sourceflight.Numberofpassengers,
                    Taxperpassenger = sourceflight.Taxperpassenger,
                    Numberofcrew = sourceflight.Numberofcrew,
                    Taxpercrew = sourceflight.Taxpercrew,
                    Servicepercentage = sourceflight.Servicepercentage
                };
            }
            else
            {
                // Создаём новый пустой объект
                targetflight = new FlightModel
                {
                    Id = Guid.NewGuid(),
                    Flightnumber = "",
                    Aircrafttype = Aircrafttype.Unknown,
                    Arrivaltime = DateTime.Now,
                    Numberofpassengers = 0,
                    Taxperpassenger = 0,
                    Numberofcrew = 0,
                    Taxpercrew = 0,
                    Servicepercentage = 0
                };
            }

            InitializeComponent();
            comboBoxAircrafttype.DrawMode = DrawMode.OwnerDrawFixed;

            if (sourceflight != null)
            {
                buttonAdd.Text = "Сохранить";
            }

            // Настройка привязки данных
            comboBoxAircrafttype.DataSource = Enum.GetValues(typeof(Aircrafttype));

            comboBoxAircrafttype.AddBinding(x => x.SelectedItem, targetflight, x => x.Aircrafttype, errorProvider);
            textBoxFlightnumber.AddBinding(x => x.Text, targetflight, x => x.Flightnumber, errorProvider);
            dateTimePickerArrivaltime.AddBinding(x => x.Value, targetflight, x => x.Arrivaltime, errorProvider);
            numericUpDownNumberofpassengers.AddBinding(x => x.Value, targetflight, x => x.Numberofpassengers, errorProvider);
            numericUpDownTaxperpassenger.AddBinding(x => x.Value, targetflight, x => x.Taxperpassenger, errorProvider);
            numericUpDownNumberofcrew.AddBinding(x => x.Value, targetflight, x => x.Numberofcrew, errorProvider);
            numericUpDownTaxpercrew.AddBinding(x => x.Value, targetflight, x => x.Taxpercrew, errorProvider);
            numericUpDownServicepercentage.AddBinding(x => x.Value, targetflight, x => x.Servicepercentage, errorProvider);
        }

        /// <summary>
        /// Возвращает текущий объект FlightModel, созданный или изменённый в этой форме
        /// </summary>
        public FlightModel CurrentFlight => targetflight;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            var context = new ValidationContext(targetflight);
            var results = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(targetflight, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                foreach (var error in results)
                {
                    foreach (var memberName in error.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(FlightModel.Flightnumber) => textBoxFlightnumber,
                            nameof(FlightModel.Aircrafttype) => comboBoxAircrafttype,
                            nameof(FlightModel.Numberofpassengers) => numericUpDownNumberofpassengers,
                            nameof(FlightModel.Taxperpassenger) => numericUpDownTaxperpassenger,
                            nameof(FlightModel.Numberofcrew) => numericUpDownNumberofcrew,
                            nameof(FlightModel.Taxpercrew) => numericUpDownTaxpercrew,
                            nameof(FlightModel.Servicepercentage) => numericUpDownServicepercentage,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider.SetError(control, error.ErrorMessage);
                        }
                    }
                }
            }
        }

        private void buttonEscape_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxAircrafttype_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                var value = comboBoxAircrafttype.Items[e.Index];
                if (value is Aircrafttype aircrafttypeValue)
                {
                    var valueString = string.Empty;
                    switch (aircrafttypeValue)
                    {
                        case Aircrafttype.Airbus:
                            valueString = "Эйрбас";
                            break;
                        case Aircrafttype.UnitedAircraftCorporation:
                            valueString = "ОАК";
                            break;
                        case Aircrafttype.Boeing:
                            valueString = "Боенг";
                            break;
                        case Aircrafttype.Unknown:
                            valueString = "Неизвестно";
                            break;
                        default:
                            valueString = "-";
                            break;
                    }
                    var brush = SystemBrushes.ControlText;
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        brush = SystemBrushes.HighlightText;
                    }
                    e.Graphics.DrawString(valueString, e.Font!, brush,
                       new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                }
            }
        }
    }
}
