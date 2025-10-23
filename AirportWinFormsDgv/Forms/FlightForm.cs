using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirportWinFormsDgv.Classes;
// using static System.Windows.Forms.VisualStyles.VisualStyleElement; // <-- Не используется, можно удалить
// using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button; // <-- Не используется, можно удалить

namespace AirportWinFormsDgv.Forms
{
    public partial class FlightForm : Form
    {
        private readonly FlightModel targetflight;

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
                    Servicepercentage = sourceflight.Servicepercentage,
                    Revenue = sourceflight.Revenue
                };
                buttonAdd.Text = "Сохранить";
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
                    Servicepercentage = 0,
                    Revenue = 0
                };
            }

            InitializeComponent();

            // Настройка привязки данных
            comboBoxAircrafttype.DataSource = Enum.GetValues(typeof(Aircrafttype));
            comboBoxAircrafttype.AddBinding(x => x.SelectedItem, targetflight, x => x.Aircrafttype);
            textBoxFlightnumber.AddBinding(x => x.Text, targetflight, x => x.Flightnumber);

            var dateTimePickerBinding = new Binding("Value", targetflight, "Arrivaltime");
            dateTimePickerBinding.Format += new ConvertEventHandler(DateOnlyToDateTime!);
            dateTimePickerBinding.Parse += new ConvertEventHandler(DateTimeToDateOnly!);
            dateTimePickerArrivaltime.DataBindings.Add(dateTimePickerBinding);

            numericUpDownNumberofpassengers.AddBinding(x => x.Value, targetflight, x => x.Numberofpassengers);
            numericUpDownNumberofpassengers.ValueChanged += (s, e) => UpdateRevenueAndBindingSource();

            numericUpDownTaxperpassenger.AddBinding(x => x.Value, targetflight, x => x.Taxperpassenger); // Уже было, но оставим для полноты
            numericUpDownTaxperpassenger.ValueChanged += (s, e) => UpdateRevenueAndBindingSource();

            numericUpDownNumberofcrew.AddBinding(x => x.Value, targetflight, x => x.Numberofcrew);
            numericUpDownNumberofcrew.ValueChanged += (s, e) => UpdateRevenueAndBindingSource();

            numericUpDownTaxpercrew.AddBinding(x => x.Value, targetflight, x => x.Taxpercrew);
            numericUpDownTaxpercrew.ValueChanged += (s, e) => UpdateRevenueAndBindingSource();

            numericUpDownServicepercentage.AddBinding(x => x.Value, targetflight, x => x.Servicepercentage);
            numericUpDownServicepercentage.ValueChanged += (s, e) => UpdateRevenueAndBindingSource();

            UpdateRevenueAndBindingSource();
        }

        /// <summary>
        /// Возвращает текущий объект FlightModel, созданный или изменённый в этой форме.
        /// </summary>
        public FlightModel CurrentFlight => targetflight;

        private void UpdateRevenueAndBindingSource()
        {
            FlightCalculator.UpdateRevenue(targetflight);
            // bindingSource.ResetBindings(false);
        }

        private void DateOnlyToDateTime(object sender, ConvertEventArgs e)
        {
            // Проверка на null и тип e.Value
            if (e.DesiredType == typeof(DateTime) && e.Value is DateOnly dateOnlyValue)
            {
                e.Value = dateOnlyValue.ToDateTime(TimeOnly.MinValue);
            }
        }

        private void DateTimeToDateOnly(object sender, ConvertEventArgs e)
        {
            // Проверка на null и тип e.Value
            if (e.DesiredType == typeof(DateOnly) && e.Value is DateTime dateTimeValue)
            {
                e.Value = DateOnly.FromDateTime(dateTimeValue);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UpdateRevenueAndBindingSource();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonEscape_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
