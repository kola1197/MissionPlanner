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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.regions_LB = new System.Windows.Forms.ListBox();
            this.addRegion_BUT = new System.Windows.Forms.Button();
            this.deleteRegion_BUT = new System.Windows.Forms.Button();
            this.saveRegions_BUT = new System.Windows.Forms.Button();
            this.loadRegions_BUT = new System.Windows.Forms.Button();
            this.regionsProperties_GB = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.coordiants_Label = new System.Windows.Forms.Label();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.color_Label = new System.Windows.Forms.Label();
            this.name_TB = new System.Windows.Forms.TextBox();
            this.name_Label = new System.Windows.Forms.Label();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionsProperties_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // regions_LB
            // 
            this.regions_LB.FormattingEnabled = true;
            this.regions_LB.Location = new System.Drawing.Point(3, 3);
            this.regions_LB.Name = "regions_LB";
            this.regions_LB.Size = new System.Drawing.Size(120, 251);
            this.regions_LB.TabIndex = 0;
            // 
            // addRegion_BUT
            // 
            this.addRegion_BUT.Location = new System.Drawing.Point(3, 266);
            this.addRegion_BUT.Name = "addRegion_BUT";
            this.addRegion_BUT.Size = new System.Drawing.Size(75, 23);
            this.addRegion_BUT.TabIndex = 1;
            this.addRegion_BUT.Text = "Добавить";
            this.addRegion_BUT.UseVisualStyleBackColor = true;
            // 
            // deleteRegion_BUT
            // 
            this.deleteRegion_BUT.Location = new System.Drawing.Point(3, 295);
            this.deleteRegion_BUT.Name = "deleteRegion_BUT";
            this.deleteRegion_BUT.Size = new System.Drawing.Size(75, 23);
            this.deleteRegion_BUT.TabIndex = 2;
            this.deleteRegion_BUT.Text = "Удалить";
            this.deleteRegion_BUT.UseVisualStyleBackColor = true;
            // 
            // saveRegions_BUT
            // 
            this.saveRegions_BUT.Location = new System.Drawing.Point(3, 353);
            this.saveRegions_BUT.Name = "saveRegions_BUT";
            this.saveRegions_BUT.Size = new System.Drawing.Size(75, 23);
            this.saveRegions_BUT.TabIndex = 3;
            this.saveRegions_BUT.Text = "Сохранить";
            this.saveRegions_BUT.UseVisualStyleBackColor = true;
            // 
            // loadRegions_BUT
            // 
            this.loadRegions_BUT.Location = new System.Drawing.Point(3, 324);
            this.loadRegions_BUT.Name = "loadRegions_BUT";
            this.loadRegions_BUT.Size = new System.Drawing.Size(75, 23);
            this.loadRegions_BUT.TabIndex = 4;
            this.loadRegions_BUT.Text = "Загрузить";
            this.loadRegions_BUT.UseVisualStyleBackColor = true;
            // 
            // regionsProperties_GB
            // 
            this.regionsProperties_GB.Controls.Add(this.dataGridView1);
            this.regionsProperties_GB.Controls.Add(this.coordiants_Label);
            this.regionsProperties_GB.Controls.Add(this.colorPanel);
            this.regionsProperties_GB.Controls.Add(this.color_Label);
            this.regionsProperties_GB.Controls.Add(this.name_TB);
            this.regionsProperties_GB.Controls.Add(this.name_Label);
            this.regionsProperties_GB.Location = new System.Drawing.Point(129, 3);
            this.regionsProperties_GB.Name = "regionsProperties_GB";
            this.regionsProperties_GB.Size = new System.Drawing.Size(358, 373);
            this.regionsProperties_GB.TabIndex = 5;
            this.regionsProperties_GB.TabStop = false;
            this.regionsProperties_GB.Text = "Свойства";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Latitude,
            this.Longitude});
            this.dataGridView1.Location = new System.Drawing.Point(10, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(342, 279);
            this.dataGridView1.TabIndex = 5;
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
            // Latitude
            // 
            this.Latitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Latitude.HeaderText = "Широта";
            this.Latitude.Name = "Latitude";
            this.Latitude.ReadOnly = true;
            // 
            // Longitude
            // 
            this.Longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Longitude.HeaderText = "Долгота";
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            // 
            // RegionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.regionsProperties_GB);
            this.Controls.Add(this.loadRegions_BUT);
            this.Controls.Add(this.saveRegions_BUT);
            this.Controls.Add(this.deleteRegion_BUT);
            this.Controls.Add(this.addRegion_BUT);
            this.Controls.Add(this.regions_LB);
            this.Name = "RegionsControl";
            this.Size = new System.Drawing.Size(490, 400);
            this.regionsProperties_GB.ResumeLayout(false);
            this.regionsProperties_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox regions_LB;
        private System.Windows.Forms.Button addRegion_BUT;
        private System.Windows.Forms.Button deleteRegion_BUT;
        private System.Windows.Forms.Button saveRegions_BUT;
        private System.Windows.Forms.Button loadRegions_BUT;
        private System.Windows.Forms.GroupBox regionsProperties_GB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label coordiants_Label;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label color_Label;
        private System.Windows.Forms.TextBox name_TB;
        private System.Windows.Forms.Label name_Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
    }
}
