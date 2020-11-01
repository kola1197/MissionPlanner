using System.Globalization;

namespace MissionPlanner.Controls.NewControls
{
    partial class RegionsControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.regions_LB = new System.Windows.Forms.ListBox();
            this.addRegion_BUT = new System.Windows.Forms.Button();
            this.deleteRegion_BUT = new System.Windows.Forms.Button();
            this.saveRegions_BUT = new System.Windows.Forms.Button();
            this.loadRegions_BUT = new System.Windows.Forms.Button();
            this.regionsProperties_GB = new System.Windows.Forms.GroupBox();
            this.latLong_DGV = new System.Windows.Forms.DataGridView();
            this.coordiants_Label = new System.Windows.Forms.Label();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.color_Label = new System.Windows.Forms.Label();
            this.name_TB = new System.Windows.Forms.TextBox();
            this.name_Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.regionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionsProperties_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.latLong_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // regions_LB
            // 
            this.regions_LB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regions_LB.FormattingEnabled = true;
            this.regions_LB.Location = new System.Drawing.Point(16, 12);
            this.regions_LB.Name = "regions_LB";
            this.regions_LB.Size = new System.Drawing.Size(120, 251);
            this.regions_LB.TabIndex = 0;
            this.regions_LB.SelectedIndexChanged += new System.EventHandler(this.regions_LB_SelectedIndexChanged);
            // 
            // addRegion_BUT
            // 
            this.addRegion_BUT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addRegion_BUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.addRegion_BUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRegion_BUT.ForeColor = System.Drawing.Color.Black;
            this.addRegion_BUT.Location = new System.Drawing.Point(16, 275);
            this.addRegion_BUT.Name = "addRegion_BUT";
            this.addRegion_BUT.Size = new System.Drawing.Size(120, 23);
            this.addRegion_BUT.TabIndex = 1;
            this.addRegion_BUT.Text = "Добавить";
            this.addRegion_BUT.UseVisualStyleBackColor = false;
            this.addRegion_BUT.Click += new System.EventHandler(this.addRegion_BUT_Click);
            // 
            // deleteRegion_BUT
            // 
            this.deleteRegion_BUT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteRegion_BUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.deleteRegion_BUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteRegion_BUT.ForeColor = System.Drawing.Color.Black;
            this.deleteRegion_BUT.Location = new System.Drawing.Point(16, 304);
            this.deleteRegion_BUT.Name = "deleteRegion_BUT";
            this.deleteRegion_BUT.Size = new System.Drawing.Size(120, 23);
            this.deleteRegion_BUT.TabIndex = 2;
            this.deleteRegion_BUT.Text = "Удалить";
            this.deleteRegion_BUT.UseVisualStyleBackColor = false;
            this.deleteRegion_BUT.Click += new System.EventHandler(this.deleteRegion_BUT_Click);
            // 
            // saveRegions_BUT
            // 
            this.saveRegions_BUT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveRegions_BUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.saveRegions_BUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveRegions_BUT.ForeColor = System.Drawing.Color.Black;
            this.saveRegions_BUT.Location = new System.Drawing.Point(16, 362);
            this.saveRegions_BUT.Name = "saveRegions_BUT";
            this.saveRegions_BUT.Size = new System.Drawing.Size(120, 23);
            this.saveRegions_BUT.TabIndex = 3;
            this.saveRegions_BUT.Text = "Сохранить";
            this.saveRegions_BUT.UseVisualStyleBackColor = false;
            this.saveRegions_BUT.Click += new System.EventHandler(this.saveRegions_BUT_Click);
            // 
            // loadRegions_BUT
            // 
            this.loadRegions_BUT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadRegions_BUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.loadRegions_BUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadRegions_BUT.ForeColor = System.Drawing.Color.Black;
            this.loadRegions_BUT.Location = new System.Drawing.Point(16, 333);
            this.loadRegions_BUT.Name = "loadRegions_BUT";
            this.loadRegions_BUT.Size = new System.Drawing.Size(120, 23);
            this.loadRegions_BUT.TabIndex = 4;
            this.loadRegions_BUT.Text = "Загрузить";
            this.loadRegions_BUT.UseVisualStyleBackColor = false;
            this.loadRegions_BUT.Click += new System.EventHandler(this.loadRegions_BUT_Click);
            // 
            // regionsProperties_GB
            // 
            this.regionsProperties_GB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regionsProperties_GB.Controls.Add(this.latLong_DGV);
            this.regionsProperties_GB.Controls.Add(this.coordiants_Label);
            this.regionsProperties_GB.Controls.Add(this.colorPanel);
            this.regionsProperties_GB.Controls.Add(this.color_Label);
            this.regionsProperties_GB.Controls.Add(this.name_TB);
            this.regionsProperties_GB.Controls.Add(this.name_Label);
            this.regionsProperties_GB.Location = new System.Drawing.Point(142, 12);
            this.regionsProperties_GB.Name = "regionsProperties_GB";
            this.regionsProperties_GB.Size = new System.Drawing.Size(358, 373);
            this.regionsProperties_GB.TabIndex = 5;
            this.regionsProperties_GB.TabStop = false;
            this.regionsProperties_GB.Text = "Свойства";
            // 
            // latLong_DGV
            // 
            this.latLong_DGV.AllowUserToAddRows = false;
            this.latLong_DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.NullValue = "-1";
            this.latLong_DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.latLong_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.latLong_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Latitude,
            this.Longitude});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.latLong_DGV.DefaultCellStyle = dataGridViewCellStyle5;
            this.latLong_DGV.Location = new System.Drawing.Point(10, 88);
            this.latLong_DGV.Name = "latLong_DGV";
            this.latLong_DGV.RowHeadersVisible = false;
            this.latLong_DGV.Size = new System.Drawing.Size(342, 279);
            this.latLong_DGV.TabIndex = 5;
            this.latLong_DGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.latLong_DGV_CellBeginEdit);
            this.latLong_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.latLong_DGV_CellClick);
            this.latLong_DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.latLong_DGV_CellEndEdit);
            this.latLong_DGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.latLong_DGV_CellFormatting);
            this.latLong_DGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.latLong_DGV_CellValidating);
            this.latLong_DGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.latLong_DGV_CellValueChanged);
            this.latLong_DGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.latLong_DGV_EditingControlShowing);
            // 
            // coordiants_Label
            // 
            this.coordiants_Label.AutoSize = true;
            this.coordiants_Label.Location = new System.Drawing.Point(7, 71);
            this.coordiants_Label.Name = "coordiants_Label";
            this.coordiants_Label.Size = new System.Drawing.Size(72, 13);
            this.coordiants_Label.TabIndex = 4;
            this.coordiants_Label.Text = "Координаты:";
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(45, 45);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(307, 23);
            this.colorPanel.TabIndex = 3;
            this.colorPanel.Click += new System.EventHandler(this.colorPanel_Click);
            // 
            // color_Label
            // 
            this.color_Label.AutoSize = true;
            this.color_Label.Location = new System.Drawing.Point(6, 45);
            this.color_Label.Name = "color_Label";
            this.color_Label.Size = new System.Drawing.Size(35, 13);
            this.color_Label.TabIndex = 2;
            this.color_Label.Text = "Цвет:";
            // 
            // name_TB
            // 
            this.name_TB.Location = new System.Drawing.Point(45, 20);
            this.name_TB.Name = "name_TB";
            this.name_TB.Size = new System.Drawing.Size(307, 20);
            this.name_TB.TabIndex = 1;
            this.name_TB.TextChanged += new System.EventHandler(this.name_TB_TextChanged);
            // 
            // name_Label
            // 
            this.name_Label.AutoSize = true;
            this.name_Label.Location = new System.Drawing.Point(7, 20);
            this.name_Label.Name = "name_Label";
            this.name_Label.Size = new System.Drawing.Size(32, 13);
            this.name_Label.TabIndex = 0;
            this.name_Label.Text = "Имя:";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // regionsBindingSource
            // 
            this.regionsBindingSource.DataSource = typeof(MissionPlanner.GCSViews.FlightPlanner);
            // 
            // pointsBindingSource
            // 
            this.pointsBindingSource.DataSource = typeof(MissionPlanner.GCSViews.FlightPlanner);
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle2.NullValue = "-1";
            this.Num.DefaultCellStyle = dataGridViewCellStyle2;
            this.Num.HeaderText = "№";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Num.Width = 43;
            // 
            // Latitude
            // 
            this.Latitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle3.NullValue = "-1";
            this.Latitude.DefaultCellStyle = dataGridViewCellStyle3;
            this.Latitude.HeaderText = "Широта";
            this.Latitude.Name = "Latitude";
            // 
            // Longitude
            // 
            this.Longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle4.NullValue = "-1";
            this.Longitude.DefaultCellStyle = dataGridViewCellStyle4;
            this.Longitude.HeaderText = "Долгота";
            this.Longitude.Name = "Longitude";
            // 
            // RegionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.regionsProperties_GB);
            this.Controls.Add(this.loadRegions_BUT);
            this.Controls.Add(this.saveRegions_BUT);
            this.Controls.Add(this.deleteRegion_BUT);
            this.Controls.Add(this.addRegion_BUT);
            this.Controls.Add(this.regions_LB);
            this.Name = "RegionsControl";
            this.Size = new System.Drawing.Size(516, 400);
            this.regionsProperties_GB.ResumeLayout(false);
            this.regionsProperties_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.latLong_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addRegion_BUT;
        private System.Windows.Forms.Button deleteRegion_BUT;
        private System.Windows.Forms.Button saveRegions_BUT;
        private System.Windows.Forms.Button loadRegions_BUT;
        private System.Windows.Forms.GroupBox regionsProperties_GB;
        private System.Windows.Forms.DataGridView latLong_DGV;
        private System.Windows.Forms.Label coordiants_Label;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label color_Label;
        private System.Windows.Forms.TextBox name_TB;
        private System.Windows.Forms.Label name_Label;
        private System.Windows.Forms.BindingSource regionsBindingSource;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.BindingSource pointsBindingSource;
        public System.Windows.Forms.ListBox regions_LB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
    }
}
