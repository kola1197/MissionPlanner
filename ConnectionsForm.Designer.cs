namespace MissionPlanner
{
    partial class ConnectionsForm
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
            this.components = new System.ComponentModel.Container();
            this.devices_LB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aircraftNumber_TB = new System.Windows.Forms.TextBox();
            this.addAircraft_BT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CMB_baudrate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CMB_serialport = new System.Windows.Forms.ComboBox();
            this.connect_BUT = new System.Windows.Forms.Button();
            this.sitl_BUT = new System.Windows.Forms.Button();
            this.connectedAircraftName_TB = new System.Windows.Forms.TextBox();
            this.connectedAircraftNum_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // devices_LB
            // 
            this.devices_LB.BackColor = System.Drawing.SystemColors.WindowText;
            this.devices_LB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.devices_LB.ForeColor = System.Drawing.SystemColors.Window;
            this.devices_LB.FormattingEnabled = true;
            this.devices_LB.Location = new System.Drawing.Point(12, 33);
            this.devices_LB.Name = "devices_LB";
            this.devices_LB.Size = new System.Drawing.Size(120, 182);
            this.devices_LB.TabIndex = 0;
            this.devices_LB.SelectedIndexChanged += new System.EventHandler(this.devices_LB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(137, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Борт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Список бортов:";
            // 
            // aircraftNumber_TB
            // 
            this.aircraftNumber_TB.Location = new System.Drawing.Point(12, 221);
            this.aircraftNumber_TB.Name = "aircraftNumber_TB";
            this.aircraftNumber_TB.Size = new System.Drawing.Size(120, 20);
            this.aircraftNumber_TB.TabIndex = 3;
            // 
            // addAircraft_BT
            // 
            this.addAircraft_BT.Location = new System.Drawing.Point(12, 248);
            this.addAircraft_BT.Name = "addAircraft_BT";
            this.addAircraft_BT.Size = new System.Drawing.Size(120, 23);
            this.addAircraft_BT.TabIndex = 4;
            this.addAircraft_BT.Text = "Добавить";
            this.addAircraft_BT.UseVisualStyleBackColor = true;
            this.addAircraft_BT.Click += new System.EventHandler(this.addAircraft_BT_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CMB_baudrate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CMB_serialport);
            this.panel1.Controls.Add(this.connect_BUT);
            this.panel1.Controls.Add(this.sitl_BUT);
            this.panel1.Controls.Add(this.connectedAircraftName_TB);
            this.panel1.Controls.Add(this.connectedAircraftNum_TB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(140, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 238);
            this.panel1.TabIndex = 5;
            // 
            // CMB_baudrate
            // 
            this.CMB_baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_baudrate.FormattingEnabled = true;
            this.CMB_baudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.CMB_baudrate.Location = new System.Drawing.Point(68, 83);
            this.CMB_baudrate.Name = "CMB_baudrate";
            this.CMB_baudrate.Size = new System.Drawing.Size(217, 21);
            this.CMB_baudrate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Скорость:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Порт:";
            // 
            // CMB_serialport
            // 
            this.CMB_serialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_serialport.FormattingEnabled = true;
            this.CMB_serialport.Location = new System.Drawing.Point(68, 56);
            this.CMB_serialport.Name = "CMB_serialport";
            this.CMB_serialport.Size = new System.Drawing.Size(217, 21);
            this.CMB_serialport.TabIndex = 6;
            // 
            // connect_BUT
            // 
            this.connect_BUT.Location = new System.Drawing.Point(149, 208);
            this.connect_BUT.Name = "connect_BUT";
            this.connect_BUT.Size = new System.Drawing.Size(139, 23);
            this.connect_BUT.TabIndex = 5;
            this.connect_BUT.Text = "Подключить борт";
            this.connect_BUT.UseVisualStyleBackColor = true;
            this.connect_BUT.Click += new System.EventHandler(this.connect_BUT_Click);
            // 
            // sitl_BUT
            // 
            this.sitl_BUT.Location = new System.Drawing.Point(6, 208);
            this.sitl_BUT.Name = "sitl_BUT";
            this.sitl_BUT.Size = new System.Drawing.Size(137, 23);
            this.sitl_BUT.TabIndex = 4;
            this.sitl_BUT.Text = "Подключить SITL";
            this.sitl_BUT.UseVisualStyleBackColor = true;
            this.sitl_BUT.Click += new System.EventHandler(this.sitl_BUT_Click);
            // 
            // connectedAircraftName_TB
            // 
            this.connectedAircraftName_TB.Location = new System.Drawing.Point(68, 30);
            this.connectedAircraftName_TB.Name = "connectedAircraftName_TB";
            this.connectedAircraftName_TB.Size = new System.Drawing.Size(217, 20);
            this.connectedAircraftName_TB.TabIndex = 3;
            // 
            // connectedAircraftNum_TB
            // 
            this.connectedAircraftNum_TB.Location = new System.Drawing.Point(68, 4);
            this.connectedAircraftNum_TB.Name = "connectedAircraftNum_TB";
            this.connectedAircraftNum_TB.Size = new System.Drawing.Size(217, 20);
            this.connectedAircraftNum_TB.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Номер:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ConnectionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 283);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addAircraft_BT);
            this.Controls.Add(this.aircraftNumber_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devices_LB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectionsForm";
            this.Text = "Подключиться к борту";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionsForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConnectionsForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ConnectionsForm_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox devices_LB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox aircraftNumber_TB;
        private System.Windows.Forms.Button addAircraft_BT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button connect_BUT;
        private System.Windows.Forms.Button sitl_BUT;
        private System.Windows.Forms.TextBox connectedAircraftName_TB;
        private System.Windows.Forms.TextBox connectedAircraftNum_TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CMB_serialport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMB_baudrate;
        private System.Windows.Forms.Timer timer1;
    }
}