namespace MissionPlanner.Controls.NewControls
{
    partial class AntennaControl
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
            this.reload_BUT = new System.Windows.Forms.Button();
            this.CMB_baudrate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CMB_serialport = new System.Windows.Forms.ComboBox();
            this.connect_BUT = new System.Windows.Forms.Button();
            this._label1 = new System.Windows.Forms.Label();
            this.mode_label = new System.Windows.Forms.Label();
            this.autoMode_BUT = new System.Windows.Forms.Button();
            this.stopMode_BUT = new System.Windows.Forms.Button();
            this._label2 = new System.Windows.Forms.Label();
            this.satNum_label = new System.Windows.Forms.Label();
            this.heading_label = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_yawpwm = new System.Windows.Forms.Label();
            this.BUT_test_yaw = new MissionPlanner.Controls.MyButton();
            this.myTrackBar1 = new MissionPlanner.Controls.MyTrackBar();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myTrackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // reload_BUT
            // 
            this.reload_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reload_BUT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.reload_BUT.Location = new System.Drawing.Point(223, 108);
            this.reload_BUT.Name = "reload_BUT";
            this.reload_BUT.Size = new System.Drawing.Size(73, 21);
            this.reload_BUT.TabIndex = 15;
            this.reload_BUT.Text = "Обновить";
            this.reload_BUT.UseVisualStyleBackColor = true;
            this.reload_BUT.Click += new System.EventHandler(this.reload_BUT_Click);
            // 
            // CMB_baudrate
            // 
            this.CMB_baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_baudrate.FormattingEnabled = true;
            this.CMB_baudrate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "111100",
            "115200",
            "500000",
            "625000",
            "921600",
            "1500000"});
            this.CMB_baudrate.Location = new System.Drawing.Point(79, 135);
            this.CMB_baudrate.Name = "CMB_baudrate";
            this.CMB_baudrate.Size = new System.Drawing.Size(217, 21);
            this.CMB_baudrate.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(15, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Скорость:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(15, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Порт:";
            // 
            // CMB_serialport
            // 
            this.CMB_serialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_serialport.FormattingEnabled = true;
            this.CMB_serialport.Location = new System.Drawing.Point(79, 108);
            this.CMB_serialport.Name = "CMB_serialport";
            this.CMB_serialport.Size = new System.Drawing.Size(138, 21);
            this.CMB_serialport.TabIndex = 11;
            this.CMB_serialport.DropDown += new System.EventHandler(this.CMB_serialport_DropDown);
            // 
            // connect_BUT
            // 
            this.connect_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connect_BUT.Location = new System.Drawing.Point(18, 162);
            this.connect_BUT.Name = "connect_BUT";
            this.connect_BUT.Size = new System.Drawing.Size(278, 23);
            this.connect_BUT.TabIndex = 16;
            this.connect_BUT.Text = "Подключить";
            this.connect_BUT.UseVisualStyleBackColor = true;
            this.connect_BUT.Click += new System.EventHandler(this.connect_BUT_Click);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._label1.Location = new System.Drawing.Point(15, 86);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(45, 13);
            this._label1.TabIndex = 17;
            this._label1.Text = "Режим:";
            // 
            // mode_label
            // 
            this.mode_label.AutoSize = true;
            this.mode_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mode_label.Location = new System.Drawing.Point(76, 86);
            this.mode_label.Name = "mode_label";
            this.mode_label.Size = new System.Drawing.Size(53, 13);
            this.mode_label.TabIndex = 18;
            this.mode_label.Text = "Unknown";
            // 
            // autoMode_BUT
            // 
            this.autoMode_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.autoMode_BUT.Location = new System.Drawing.Point(18, 191);
            this.autoMode_BUT.Name = "autoMode_BUT";
            this.autoMode_BUT.Size = new System.Drawing.Size(89, 23);
            this.autoMode_BUT.TabIndex = 19;
            this.autoMode_BUT.Text = "AUTO";
            this.autoMode_BUT.UseVisualStyleBackColor = true;
            this.autoMode_BUT.Click += new System.EventHandler(this.autoMode_BUT_Click);
            // 
            // stopMode_BUT
            // 
            this.stopMode_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopMode_BUT.Location = new System.Drawing.Point(113, 191);
            this.stopMode_BUT.Name = "stopMode_BUT";
            this.stopMode_BUT.Size = new System.Drawing.Size(89, 23);
            this.stopMode_BUT.TabIndex = 20;
            this.stopMode_BUT.Text = "STOP";
            this.stopMode_BUT.UseVisualStyleBackColor = true;
            this.stopMode_BUT.Click += new System.EventHandler(this.stopMode_BUT_Click);
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._label2.Location = new System.Drawing.Point(15, 64);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(124, 13);
            this._label2.TabIndex = 22;
            this._label2.Text = "Количество спутников:";
            // 
            // satNum_label
            // 
            this.satNum_label.AutoSize = true;
            this.satNum_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.satNum_label.Location = new System.Drawing.Point(145, 64);
            this.satNum_label.Name = "satNum_label";
            this.satNum_label.Size = new System.Drawing.Size(13, 13);
            this.satNum_label.TabIndex = 23;
            this.satNum_label.Text = "0";
            // 
            // heading_label
            // 
            this.heading_label.AutoSize = true;
            this.heading_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.heading_label.Location = new System.Drawing.Point(99, 41);
            this.heading_label.Name = "heading_label";
            this.heading_label.Size = new System.Drawing.Size(13, 13);
            this.heading_label.TabIndex = 25;
            this.heading_label.Text = "0";
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._label3.Location = new System.Drawing.Point(15, 41);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(78, 13);
            this._label3.TabIndex = 24;
            this._label3.Text = "Направление:";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_yawpwm
            // 
            this.lbl_yawpwm.AutoSize = true;
            this.lbl_yawpwm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_yawpwm.Location = new System.Drawing.Point(168, 225);
            this.lbl_yawpwm.Name = "lbl_yawpwm";
            this.lbl_yawpwm.Size = new System.Drawing.Size(31, 13);
            this.lbl_yawpwm.TabIndex = 28;
            this.lbl_yawpwm.Text = "1500";
            // 
            // BUT_test_yaw
            // 
            this.BUT_test_yaw.BGGradBot = System.Drawing.SystemColors.Control;
            this.BUT_test_yaw.BGGradTop = System.Drawing.SystemColors.Control;
            this.BUT_test_yaw.DefaultTheme = false;
            this.BUT_test_yaw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BUT_test_yaw.Location = new System.Drawing.Point(168, 271);
            this.BUT_test_yaw.Name = "BUT_test_yaw";
            this.BUT_test_yaw.Size = new System.Drawing.Size(88, 23);
            this.BUT_test_yaw.TabIndex = 27;
            this.BUT_test_yaw.Text = "Test";
            this.BUT_test_yaw.UseVisualStyleBackColor = true;
            this.BUT_test_yaw.Visible = false;
            this.BUT_test_yaw.Click += new System.EventHandler(this.BUT_test_yaw_Click);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.myTrackBar1.LargeChange = 0.005F;
            this.myTrackBar1.Location = new System.Drawing.Point(18, 220);
            this.myTrackBar1.Maximum = 2000F;
            this.myTrackBar1.Minimum = 1000F;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(144, 45);
            this.myTrackBar1.SmallChange = 5F;
            this.myTrackBar1.TabIndex = 26;
            this.myTrackBar1.TickFrequency = 100F;
            this.myTrackBar1.Value = 1500F;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BUT_test_yaw_Click);
            // 
            // AntennaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_yawpwm);
            this.Controls.Add(this.BUT_test_yaw);
            this.Controls.Add(this.myTrackBar1);
            this.Controls.Add(this.heading_label);
            this.Controls.Add(this._label3);
            this.Controls.Add(this.satNum_label);
            this.Controls.Add(this._label2);
            this.Controls.Add(this.stopMode_BUT);
            this.Controls.Add(this.autoMode_BUT);
            this.Controls.Add(this.mode_label);
            this.Controls.Add(this._label1);
            this.Controls.Add(this.connect_BUT);
            this.Controls.Add(this.reload_BUT);
            this.Controls.Add(this.CMB_baudrate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CMB_serialport);
            this.Name = "AntennaControl";
            this.Size = new System.Drawing.Size(311, 400);
            ((System.ComponentModel.ISupportInitialize)(this.myTrackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button connect_BUT;

        #endregion

        private System.Windows.Forms.Button reload_BUT;
        private System.Windows.Forms.ComboBox CMB_baudrate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMB_serialport;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Label mode_label;
        private System.Windows.Forms.Button autoMode_BUT;
        private System.Windows.Forms.Button stopMode_BUT;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.Label satNum_label;
        private System.Windows.Forms.Label heading_label;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_yawpwm;
        private MyButton BUT_test_yaw;
        private MyTrackBar myTrackBar1;
        private System.Windows.Forms.Button button1;
    }
}
