namespace MissionPlanner.Controls.NewControls
{
    partial class GskControl
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.regionsProperties_GB = new System.Windows.Forms.GroupBox();
            this.latLong_DGV = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordiants_Label = new System.Windows.Forms.Label();
            this.name_TB = new System.Windows.Forms.TextBox();
            this.name_Label = new System.Windows.Forms.Label();
            this.loadRegions_BUT = new System.Windows.Forms.Button();
            this.saveRegions_BUT = new System.Windows.Forms.Button();
            this.deleteRegion_BUT = new System.Windows.Forms.Button();
            this.addRegion_BUT = new System.Windows.Forms.Button();
            this.regions_LB = new System.Windows.Forms.ListBox();
            this.regionsProperties_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.latLong_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // regionsProperties_GB
            // 
            this.regionsProperties_GB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regionsProperties_GB.Controls.Add(this.latLong_DGV);
            this.regionsProperties_GB.Controls.Add(this.coordiants_Label);
            this.regionsProperties_GB.Controls.Add(this.name_TB);
            this.regionsProperties_GB.Controls.Add(this.name_Label);
            this.regionsProperties_GB.ForeColor = System.Drawing.Color.White;
            this.regionsProperties_GB.Location = new System.Drawing.Point(142, 12);
            this.regionsProperties_GB.Name = "regionsProperties_GB";
            this.regionsProperties_GB.Size = new System.Drawing.Size(358, 373);
            this.regionsProperties_GB.TabIndex = 11;
            this.regionsProperties_GB.TabStop = false;
            this.regionsProperties_GB.Text = "Свойства";
            // 
            // latLong_DGV
            // 
            this.latLong_DGV.AllowUserToAddRows = false;
            this.latLong_DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.NullValue = "-1";
            this.latLong_DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.latLong_DGV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.latLong_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.latLong_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Latitude,
            this.Longitude});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.latLong_DGV.DefaultCellStyle = dataGridViewCellStyle10;
            this.latLong_DGV.Location = new System.Drawing.Point(10, 88);
            this.latLong_DGV.Name = "latLong_DGV";
            this.latLong_DGV.RowHeadersVisible = false;
            this.latLong_DGV.Size = new System.Drawing.Size(342, 279);
            this.latLong_DGV.TabIndex = 5;
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle7.NullValue = "-1";
            this.Num.DefaultCellStyle = dataGridViewCellStyle7;
            this.Num.HeaderText = "№";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Num.Width = 43;
            // 
            // Latitude
            // 
            this.Latitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Format = "N6";
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle8.NullValue = "-1";
            this.Latitude.DefaultCellStyle = dataGridViewCellStyle8;
            this.Latitude.HeaderText = "Широта";
            this.Latitude.Name = "Latitude";
            // 
            // Longitude
            // 
            this.Longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Format = "N6";
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle9.NullValue = "-1";
            this.Longitude.DefaultCellStyle = dataGridViewCellStyle9;
            this.Longitude.HeaderText = "Долгота";
            this.Longitude.Name = "Longitude";
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
            // name_TB
            // 
            this.name_TB.Location = new System.Drawing.Point(45, 20);
            this.name_TB.Name = "name_TB";
            this.name_TB.Size = new System.Drawing.Size(307, 20);
            this.name_TB.TabIndex = 1;
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
            // loadRegions_BUT
            // 
            this.loadRegions_BUT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadRegions_BUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.loadRegions_BUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadRegions_BUT.ForeColor = System.Drawing.Color.Black;
            this.loadRegions_BUT.Location = new System.Drawing.Point(16, 333);
            this.loadRegions_BUT.Name = "loadRegions_BUT";
            this.loadRegions_BUT.Size = new System.Drawing.Size(120, 23);
            this.loadRegions_BUT.TabIndex = 10;
            this.loadRegions_BUT.Text = "Загрузить";
            this.loadRegions_BUT.UseVisualStyleBackColor = false;
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
            this.saveRegions_BUT.TabIndex = 9;
            this.saveRegions_BUT.Text = "Сохранить";
            this.saveRegions_BUT.UseVisualStyleBackColor = false;
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
            this.deleteRegion_BUT.TabIndex = 8;
            this.deleteRegion_BUT.Text = "Удалить";
            this.deleteRegion_BUT.UseVisualStyleBackColor = false;
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
            this.addRegion_BUT.TabIndex = 7;
            this.addRegion_BUT.Text = "Добавить";
            this.addRegion_BUT.UseVisualStyleBackColor = false;
            // 
            // regions_LB
            // 
            this.regions_LB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regions_LB.FormattingEnabled = true;
            this.regions_LB.Location = new System.Drawing.Point(16, 12);
            this.regions_LB.Margin = new System.Windows.Forms.Padding(16, 12, 3, 3);
            this.regions_LB.Name = "regions_LB";
            this.regions_LB.Size = new System.Drawing.Size(120, 251);
            this.regions_LB.TabIndex = 6;
            // 
            // GskControl
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
            this.Name = "GskControl";
            this.Size = new System.Drawing.Size(516, 400);
            this.regionsProperties_GB.ResumeLayout(false);
            this.regionsProperties_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.latLong_DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox regionsProperties_GB;
        private System.Windows.Forms.DataGridView latLong_DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.Label coordiants_Label;
        private System.Windows.Forms.TextBox name_TB;
        private System.Windows.Forms.Label name_Label;
        private System.Windows.Forms.Button loadRegions_BUT;
        private System.Windows.Forms.Button saveRegions_BUT;
        private System.Windows.Forms.Button deleteRegion_BUT;
        private System.Windows.Forms.Button addRegion_BUT;
        public System.Windows.Forms.ListBox regions_LB;
    }
}
