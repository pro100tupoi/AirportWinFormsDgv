namespace AirportWinFormsDgv
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelArrivingflights = new ToolStripStatusLabel();
            toolStripStatusLabelTotalnumberofpassengers = new ToolStripStatusLabel();
            toolStripStatusLabelTotalnumberofcrew = new ToolStripStatusLabel();
            toolStripStatusLabelTotalrevenue = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEditing = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            dataGridViewflights = new DataGridView();
            FlightnumberColumn = new DataGridViewTextBoxColumn();
            AircrafttypeColumn = new DataGridViewTextBoxColumn();
            ArrivaltimeColumn = new DataGridViewTextBoxColumn();
            NumberofpassengersColumn = new DataGridViewTextBoxColumn();
            TaxperpassengerColumn = new DataGridViewTextBoxColumn();
            NumberofcrewColumn = new DataGridViewTextBoxColumn();
            TaxpercrewColumn = new DataGridViewTextBoxColumn();
            ServicepercentageColumn = new DataGridViewTextBoxColumn();
            RevenueColumn = new DataGridViewTextBoxColumn();
            errorProvider = new ErrorProvider(components);
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewflights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelArrivingflights, toolStripStatusLabelTotalnumberofpassengers, toolStripStatusLabelTotalnumberofcrew, toolStripStatusLabelTotalrevenue });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(943, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelArrivingflights
            // 
            toolStripStatusLabelArrivingflights.Name = "toolStripStatusLabelArrivingflights";
            toolStripStatusLabelArrivingflights.Size = new Size(138, 17);
            toolStripStatusLabelArrivingflights.Text = "прибывающих рейсов: ";
            // 
            // toolStripStatusLabelTotalnumberofpassengers
            // 
            toolStripStatusLabelTotalnumberofpassengers.Name = "toolStripStatusLabelTotalnumberofpassengers";
            toolStripStatusLabelTotalnumberofpassengers.Size = new Size(187, 17);
            toolStripStatusLabelTotalnumberofpassengers.Text = "общее количество пассажиров: ";
            // 
            // toolStripStatusLabelTotalnumberofcrew
            // 
            toolStripStatusLabelTotalnumberofcrew.Name = "toolStripStatusLabelTotalnumberofcrew";
            toolStripStatusLabelTotalnumberofcrew.Size = new Size(167, 17);
            toolStripStatusLabelTotalnumberofcrew.Text = "общее количество экипажа: ";
            // 
            // toolStripStatusLabelTotalrevenue
            // 
            toolStripStatusLabelTotalrevenue.Name = "toolStripStatusLabelTotalrevenue";
            toolStripStatusLabelTotalrevenue.Size = new Size(128, 17);
            toolStripStatusLabelTotalrevenue.Text = "сумма всей выручки: ";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEditing, toolStripButtonDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(943, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.BackColor = Color.LawnGreen;
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(23, 22);
            toolStripButtonAdd.Text = "toolStripButton1";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonEditing
            // 
            toolStripButtonEditing.BackColor = Color.Gold;
            toolStripButtonEditing.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEditing.Image = (Image)resources.GetObject("toolStripButtonEditing.Image");
            toolStripButtonEditing.ImageTransparentColor = Color.Magenta;
            toolStripButtonEditing.Name = "toolStripButtonEditing";
            toolStripButtonEditing.Size = new Size(23, 22);
            toolStripButtonEditing.Text = "toolStripButton2";
            toolStripButtonEditing.Click += toolStripButtonEditing_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.BackColor = Color.Red;
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Image = (Image)resources.GetObject("toolStripButtonDelete.Image");
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(23, 22);
            toolStripButtonDelete.Text = "toolStripButton3";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // dataGridViewflights
            // 
            dataGridViewflights.AllowUserToAddRows = false;
            dataGridViewflights.AllowUserToDeleteRows = false;
            dataGridViewflights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewflights.Columns.AddRange(new DataGridViewColumn[] { FlightnumberColumn, AircrafttypeColumn, ArrivaltimeColumn, NumberofpassengersColumn, TaxperpassengerColumn, NumberofcrewColumn, TaxpercrewColumn, ServicepercentageColumn, RevenueColumn });
            dataGridViewflights.Dock = DockStyle.Fill;
            dataGridViewflights.Location = new Point(0, 25);
            dataGridViewflights.Name = "dataGridViewflights";
            dataGridViewflights.ReadOnly = true;
            dataGridViewflights.Size = new Size(943, 403);
            dataGridViewflights.TabIndex = 2;
            dataGridViewflights.CellContentClick += dataGridViewflights_CellContentClick;
            dataGridViewflights.CellFormatting += dataGridViewflights_CellFormatting;
            // 
            // FlightnumberColumn
            // 
            FlightnumberColumn.DataPropertyName = "Flightnumber";
            FlightnumberColumn.HeaderText = "Номер рейса";
            FlightnumberColumn.Name = "FlightnumberColumn";
            FlightnumberColumn.ReadOnly = true;
            // 
            // AircrafttypeColumn
            // 
            AircrafttypeColumn.DataPropertyName = "Aircrafttype";
            AircrafttypeColumn.HeaderText = "Тип самолёта";
            AircrafttypeColumn.Name = "AircrafttypeColumn";
            AircrafttypeColumn.ReadOnly = true;
            // 
            // ArrivaltimeColumn
            // 
            ArrivaltimeColumn.DataPropertyName = "Arrivaltime";
            ArrivaltimeColumn.HeaderText = "Время прибытия";
            ArrivaltimeColumn.Name = "ArrivaltimeColumn";
            ArrivaltimeColumn.ReadOnly = true;
            // 
            // NumberofpassengersColumn
            // 
            NumberofpassengersColumn.DataPropertyName = "Numberofpassengers";
            NumberofpassengersColumn.HeaderText = "Количество пассажиров";
            NumberofpassengersColumn.Name = "NumberofpassengersColumn";
            NumberofpassengersColumn.ReadOnly = true;
            // 
            // TaxperpassengerColumn
            // 
            TaxperpassengerColumn.DataPropertyName = "Taxperpassenger";
            TaxperpassengerColumn.HeaderText = "Сбор на пассажира";
            TaxperpassengerColumn.Name = "TaxperpassengerColumn";
            TaxperpassengerColumn.ReadOnly = true;
            // 
            // NumberofcrewColumn
            // 
            NumberofcrewColumn.DataPropertyName = "Numberofcrew";
            NumberofcrewColumn.HeaderText = "Количество экипажа";
            NumberofcrewColumn.Name = "NumberofcrewColumn";
            NumberofcrewColumn.ReadOnly = true;
            // 
            // TaxpercrewColumn
            // 
            TaxpercrewColumn.DataPropertyName = "Taxpercrew";
            TaxpercrewColumn.HeaderText = "Сбор на экипаж";
            TaxpercrewColumn.Name = "TaxpercrewColumn";
            TaxpercrewColumn.ReadOnly = true;
            // 
            // ServicepercentageColumn
            // 
            ServicepercentageColumn.DataPropertyName = "Servicepercentage";
            ServicepercentageColumn.HeaderText = "Процент надбавки за обслуживание";
            ServicepercentageColumn.Name = "ServicepercentageColumn";
            ServicepercentageColumn.ReadOnly = true;
            // 
            // RevenueColumn
            // 
            RevenueColumn.DataPropertyName = "Revenue";
            RevenueColumn.HeaderText = "Выручка";
            RevenueColumn.Name = "RevenueColumn";
            RevenueColumn.ReadOnly = true;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 450);
            Controls.Add(dataGridViewflights);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewflights).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private DataGridView dataGridViewflights;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripStatusLabel toolStripStatusLabelArrivingflights;
        private ToolStripStatusLabel toolStripStatusLabelTotalnumberofpassengers;
        private ToolStripStatusLabel toolStripStatusLabelTotalnumberofcrew;
        private ToolStripStatusLabel toolStripStatusLabelTotalrevenue;
        private ToolStripButton toolStripButtonEditing;
        private ToolStripButton toolStripButtonDelete;
        private ErrorProvider errorProvider;
        private DataGridViewTextBoxColumn FlightnumberColumn;
        private DataGridViewTextBoxColumn AircrafttypeColumn;
        private DataGridViewTextBoxColumn ArrivaltimeColumn;
        private DataGridViewTextBoxColumn NumberofpassengersColumn;
        private DataGridViewTextBoxColumn TaxperpassengerColumn;
        private DataGridViewTextBoxColumn NumberofcrewColumn;
        private DataGridViewTextBoxColumn TaxpercrewColumn;
        private DataGridViewTextBoxColumn ServicepercentageColumn;
        private DataGridViewTextBoxColumn RevenueColumn;
    }
}
