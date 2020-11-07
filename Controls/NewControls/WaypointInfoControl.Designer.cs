namespace MissionPlanner.NewForms
{
    partial class WaypointInfoControl
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
            this.wpInfo_GB = new System.Windows.Forms.GroupBox();
            this.lng_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lat_label = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.homeDist_label = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.alt_label = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.type_label = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wpInfo_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // wpInfo_GB
            // 
            this.wpInfo_GB.Controls.Add(this.lng_label);
            this.wpInfo_GB.Controls.Add(this.label4);
            this.wpInfo_GB.Controls.Add(this.lat_label);
            this.wpInfo_GB.Controls.Add(this.label123);
            this.wpInfo_GB.Controls.Add(this.homeDist_label);
            this.wpInfo_GB.Controls.Add(this.label14);
            this.wpInfo_GB.Controls.Add(this.alt_label);
            this.wpInfo_GB.Controls.Add(this.label13);
            this.wpInfo_GB.Controls.Add(this.type_label);
            this.wpInfo_GB.Controls.Add(this.label12);
            this.wpInfo_GB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.wpInfo_GB.Location = new System.Drawing.Point(3, 3);
            this.wpInfo_GB.Name = "wpInfo_GB";
            this.wpInfo_GB.Size = new System.Drawing.Size(153, 143);
            this.wpInfo_GB.TabIndex = 1;
            this.wpInfo_GB.TabStop = false;
            this.wpInfo_GB.Text = "wpno";
            // 
            // lng_label
            // 
            this.lng_label.AutoSize = true;
            this.lng_label.Location = new System.Drawing.Point(73, 48);
            this.lng_label.Name = "lng_label";
            this.lng_label.Size = new System.Drawing.Size(21, 13);
            this.lng_label.TabIndex = 9;
            this.lng_label.Text = "lng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Долгота:";
            // 
            // lat_label
            // 
            this.lat_label.AutoSize = true;
            this.lat_label.Location = new System.Drawing.Point(73, 25);
            this.lat_label.Name = "lat_label";
            this.lat_label.Size = new System.Drawing.Size(18, 13);
            this.lat_label.TabIndex = 7;
            this.lat_label.Text = "lat";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(6, 25);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(48, 13);
            this.label123.TabIndex = 6;
            this.label123.Text = "Широта:";
            // 
            // homeDist_label
            // 
            this.homeDist_label.AutoSize = true;
            this.homeDist_label.Location = new System.Drawing.Point(73, 124);
            this.homeDist_label.Name = "homeDist_label";
            this.homeDist_label.Size = new System.Drawing.Size(51, 13);
            this.homeDist_label.TabIndex = 5;
            this.homeDist_label.Text = "homeDist";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "До дома:";
            // 
            // alt_label
            // 
            this.alt_label.AutoSize = true;
            this.alt_label.Location = new System.Drawing.Point(73, 71);
            this.alt_label.Name = "alt_label";
            this.alt_label.Size = new System.Drawing.Size(18, 13);
            this.alt_label.TabIndex = 3;
            this.alt_label.Text = "alt";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Высота:";
            // 
            // type_label
            // 
            this.type_label.AutoSize = true;
            this.type_label.Location = new System.Drawing.Point(73, 97);
            this.type_label.Name = "type_label";
            this.type_label.Size = new System.Drawing.Size(27, 13);
            this.type_label.TabIndex = 1;
            this.type_label.Text = "type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Тип: ";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WaypointInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wpInfo_GB);
            this.DoubleBuffered = true;
            this.Name = "WaypointInfoControl";
            this.Size = new System.Drawing.Size(159, 149);
            this.wpInfo_GB.ResumeLayout(false);
            this.wpInfo_GB.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.GroupBox wpInfo_GB;
        public System.Windows.Forms.Label homeDist_label;
        public System.Windows.Forms.Label alt_label;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label type_label;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lng_label;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lat_label;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Timer timer1;
    }
}
