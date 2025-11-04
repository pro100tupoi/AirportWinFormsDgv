namespace AirportWinFormsDgv.Forms
{
    partial class FlightForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            buttonAdd = new Button();
            buttonEscape = new Button();
            labelFlightnumber = new Label();
            textBoxFlightnumber = new TextBox();
            labelAircrafttype = new Label();
            labelArrivaltime = new Label();
            labelNumberofpassengers = new Label();
            labelTaxperpassenger = new Label();
            labelNumberofcrew = new Label();
            labelTaxpercrew = new Label();
            labelServicepercentage = new Label();
            comboBoxAircrafttype = new ComboBox();
            dateTimePickerArrivaltime = new DateTimePicker();
            numericUpDownNumberofpassengers = new NumericUpDown();
            numericUpDownTaxperpassenger = new NumericUpDown();
            numericUpDownNumberofcrew = new NumericUpDown();
            numericUpDownTaxpercrew = new NumericUpDown();
            numericUpDownServicepercentage = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberofpassengers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTaxperpassenger).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberofcrew).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTaxpercrew).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownServicepercentage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(504, 100);
            panel1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(298, 503);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEscape
            // 
            buttonEscape.Location = new Point(407, 503);
            buttonEscape.Name = "buttonEscape";
            buttonEscape.Size = new Size(75, 23);
            buttonEscape.TabIndex = 2;
            buttonEscape.Text = "Отмена";
            buttonEscape.UseVisualStyleBackColor = true;
            buttonEscape.Click += buttonEscape_Click;
            // 
            // labelFlightnumber
            // 
            labelFlightnumber.AutoSize = true;
            labelFlightnumber.Location = new Point(26, 130);
            labelFlightnumber.Name = "labelFlightnumber";
            labelFlightnumber.Size = new Size(80, 15);
            labelFlightnumber.TabIndex = 3;
            labelFlightnumber.Text = "Номер рейса";
            // 
            // textBoxFlightnumber
            // 
            textBoxFlightnumber.Location = new Point(239, 127);
            textBoxFlightnumber.Name = "textBoxFlightnumber";
            textBoxFlightnumber.Size = new Size(239, 23);
            textBoxFlightnumber.TabIndex = 4;
            // 
            // labelAircrafttype
            // 
            labelAircrafttype.AutoSize = true;
            labelAircrafttype.Location = new Point(26, 170);
            labelAircrafttype.Name = "labelAircrafttype";
            labelAircrafttype.Size = new Size(82, 15);
            labelAircrafttype.TabIndex = 5;
            labelAircrafttype.Text = "Тип самолёта";
            // 
            // labelArrivaltime
            // 
            labelArrivaltime.AutoSize = true;
            labelArrivaltime.Location = new Point(26, 208);
            labelArrivaltime.Name = "labelArrivaltime";
            labelArrivaltime.Size = new Size(100, 15);
            labelArrivaltime.TabIndex = 7;
            labelArrivaltime.Text = "Время прибытия";
            // 
            // labelNumberofpassengers
            // 
            labelNumberofpassengers.AutoSize = true;
            labelNumberofpassengers.Location = new Point(26, 247);
            labelNumberofpassengers.Name = "labelNumberofpassengers";
            labelNumberofpassengers.Size = new Size(142, 15);
            labelNumberofpassengers.TabIndex = 9;
            labelNumberofpassengers.Text = "Количество пассажиров";
            // 
            // labelTaxperpassenger
            // 
            labelTaxperpassenger.AutoSize = true;
            labelTaxperpassenger.Location = new Point(26, 286);
            labelTaxperpassenger.Name = "labelTaxperpassenger";
            labelTaxperpassenger.Size = new Size(115, 15);
            labelTaxperpassenger.TabIndex = 11;
            labelTaxperpassenger.Text = "Сбор на пассажира";
            // 
            // labelNumberofcrew
            // 
            labelNumberofcrew.AutoSize = true;
            labelNumberofcrew.Location = new Point(26, 330);
            labelNumberofcrew.Name = "labelNumberofcrew";
            labelNumberofcrew.Size = new Size(122, 15);
            labelNumberofcrew.TabIndex = 13;
            labelNumberofcrew.Text = "Количество экипажа";
            // 
            // labelTaxpercrew
            // 
            labelTaxpercrew.AutoSize = true;
            labelTaxpercrew.Location = new Point(26, 374);
            labelTaxpercrew.Name = "labelTaxpercrew";
            labelTaxpercrew.Size = new Size(96, 15);
            labelTaxpercrew.TabIndex = 15;
            labelTaxpercrew.Text = "Сбор на экипаж";
            // 
            // labelServicepercentage
            // 
            labelServicepercentage.AutoSize = true;
            labelServicepercentage.Location = new Point(26, 413);
            labelServicepercentage.Name = "labelServicepercentage";
            labelServicepercentage.Size = new Size(207, 15);
            labelServicepercentage.TabIndex = 17;
            labelServicepercentage.Text = "Процент надбавки за обслуживание";
            // 
            // comboBoxAircrafttype
            // 
            comboBoxAircrafttype.FormattingEnabled = true;
            comboBoxAircrafttype.Location = new Point(239, 167);
            comboBoxAircrafttype.Name = "comboBoxAircrafttype";
            comboBoxAircrafttype.Size = new Size(239, 23);
            comboBoxAircrafttype.TabIndex = 21;
            comboBoxAircrafttype.DrawItem += comboBoxAircrafttype_DrawItem;
            // 
            // dateTimePickerArrivaltime
            // 
            dateTimePickerArrivaltime.Location = new Point(239, 202);
            dateTimePickerArrivaltime.Name = "dateTimePickerArrivaltime";
            dateTimePickerArrivaltime.Size = new Size(239, 23);
            dateTimePickerArrivaltime.TabIndex = 22;
            // 
            // numericUpDownNumberofpassengers
            // 
            numericUpDownNumberofpassengers.Location = new Point(239, 245);
            numericUpDownNumberofpassengers.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownNumberofpassengers.Name = "numericUpDownNumberofpassengers";
            numericUpDownNumberofpassengers.Size = new Size(82, 23);
            numericUpDownNumberofpassengers.TabIndex = 23;
            // 
            // numericUpDownTaxperpassenger
            // 
            numericUpDownTaxperpassenger.DecimalPlaces = 2;
            numericUpDownTaxperpassenger.Location = new Point(239, 284);
            numericUpDownTaxperpassenger.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericUpDownTaxperpassenger.Name = "numericUpDownTaxperpassenger";
            numericUpDownTaxperpassenger.Size = new Size(82, 23);
            numericUpDownTaxperpassenger.TabIndex = 24;
            // 
            // numericUpDownNumberofcrew
            // 
            numericUpDownNumberofcrew.Location = new Point(239, 328);
            numericUpDownNumberofcrew.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownNumberofcrew.Name = "numericUpDownNumberofcrew";
            numericUpDownNumberofcrew.Size = new Size(82, 23);
            numericUpDownNumberofcrew.TabIndex = 25;
            // 
            // numericUpDownTaxpercrew
            // 
            numericUpDownTaxpercrew.DecimalPlaces = 2;
            numericUpDownTaxpercrew.Location = new Point(239, 372);
            numericUpDownTaxpercrew.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownTaxpercrew.Name = "numericUpDownTaxpercrew";
            numericUpDownTaxpercrew.Size = new Size(82, 23);
            numericUpDownTaxpercrew.TabIndex = 26;
            // 
            // numericUpDownServicepercentage
            // 
            numericUpDownServicepercentage.DecimalPlaces = 2;
            numericUpDownServicepercentage.Location = new Point(239, 411);
            numericUpDownServicepercentage.Name = "numericUpDownServicepercentage";
            numericUpDownServicepercentage.Size = new Size(82, 23);
            numericUpDownServicepercentage.TabIndex = 27;
            // 
            // FlightForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 566);
            Controls.Add(numericUpDownServicepercentage);
            Controls.Add(numericUpDownTaxpercrew);
            Controls.Add(numericUpDownNumberofcrew);
            Controls.Add(numericUpDownTaxperpassenger);
            Controls.Add(numericUpDownNumberofpassengers);
            Controls.Add(dateTimePickerArrivaltime);
            Controls.Add(comboBoxAircrafttype);
            Controls.Add(labelServicepercentage);
            Controls.Add(labelTaxpercrew);
            Controls.Add(labelNumberofcrew);
            Controls.Add(labelTaxperpassenger);
            Controls.Add(labelNumberofpassengers);
            Controls.Add(labelArrivaltime);
            Controls.Add(labelAircrafttype);
            Controls.Add(textBoxFlightnumber);
            Controls.Add(labelFlightnumber);
            Controls.Add(buttonEscape);
            Controls.Add(buttonAdd);
            Controls.Add(panel1);
            Name = "FlightForm";
            Text = "Рейс";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberofpassengers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTaxperpassenger).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberofcrew).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTaxpercrew).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownServicepercentage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buttonAdd;
        private Button buttonEscape;
        private Label labelFlightnumber;
        private TextBox textBoxFlightnumber;
        private Label labelAircrafttype;
        private Label labelArrivaltime;
        private Label labelNumberofpassengers;
        private Label labelTaxperpassenger;
        private Label labelNumberofcrew;
        private Label labelTaxpercrew;
        private Label labelServicepercentage;
        private ComboBox comboBoxAircrafttype;
        private DateTimePicker dateTimePickerArrivaltime;
        private NumericUpDown numericUpDownNumberofpassengers;
        private NumericUpDown numericUpDownTaxperpassenger;
        private NumericUpDown numericUpDownNumberofcrew;
        private NumericUpDown numericUpDownTaxpercrew;
        private NumericUpDown numericUpDownServicepercentage;
    }
}
