﻿namespace MissionPlanner.Controls.NewControls
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
            this.myTrackBar1 = new MissionPlanner.Controls.MyTrackBar();
            this.testAntButton = new System.Windows.Forms.Button();
            this.switchAntenna_CB = new System.Windows.Forms.CheckBox();
            this.antennaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toggleSwitch1 = new JCS.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.myTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antennaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reload_BUT
            // 
            this.reload_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reload_BUT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.reload_BUT.Location = new System.Drawing.Point(297, 133);
            this.reload_BUT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reload_BUT.Name = "reload_BUT";
            this.reload_BUT.Size = new System.Drawing.Size(97, 26);
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
            this.CMB_baudrate.Location = new System.Drawing.Point(105, 166);
            this.CMB_baudrate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CMB_baudrate.Name = "CMB_baudrate";
            this.CMB_baudrate.Size = new System.Drawing.Size(288, 24);
            this.CMB_baudrate.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(20, 170);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Скорость:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(20, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Порт:";
            // 
            // CMB_serialport
            // 
            this.CMB_serialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_serialport.FormattingEnabled = true;
            this.CMB_serialport.Location = new System.Drawing.Point(105, 133);
            this.CMB_serialport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CMB_serialport.Name = "CMB_serialport";
            this.CMB_serialport.Size = new System.Drawing.Size(183, 24);
            this.CMB_serialport.TabIndex = 11;
            this.CMB_serialport.DropDown += new System.EventHandler(this.CMB_serialport_DropDown);
            // 
            // connect_BUT
            // 
            this.connect_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connect_BUT.Location = new System.Drawing.Point(24, 199);
            this.connect_BUT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connect_BUT.Name = "connect_BUT";
            this.connect_BUT.Size = new System.Drawing.Size(371, 28);
            this.connect_BUT.TabIndex = 16;
            this.connect_BUT.Text = "Подключить";
            this.connect_BUT.UseVisualStyleBackColor = true;
            this.connect_BUT.Click += new System.EventHandler(this.connect_BUT_Click);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._label1.Location = new System.Drawing.Point(20, 106);
            this._label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(55, 17);
            this._label1.TabIndex = 17;
            this._label1.Text = "Режим:";
            // 
            // mode_label
            // 
            this.mode_label.AutoSize = true;
            this.mode_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mode_label.Location = new System.Drawing.Point(101, 106);
            this.mode_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mode_label.Name = "mode_label";
            this.mode_label.Size = new System.Drawing.Size(66, 17);
            this.mode_label.TabIndex = 18;
            this.mode_label.Text = "Unknown";
            // 
            // autoMode_BUT
            // 
            this.autoMode_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.autoMode_BUT.Location = new System.Drawing.Point(24, 235);
            this.autoMode_BUT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.autoMode_BUT.Name = "autoMode_BUT";
            this.autoMode_BUT.Size = new System.Drawing.Size(119, 28);
            this.autoMode_BUT.TabIndex = 19;
            this.autoMode_BUT.Text = "AUTO";
            this.autoMode_BUT.UseVisualStyleBackColor = true;
            this.autoMode_BUT.Click += new System.EventHandler(this.autoMode_BUT_Click);
            // 
            // stopMode_BUT
            // 
            this.stopMode_BUT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopMode_BUT.Location = new System.Drawing.Point(151, 235);
            this.stopMode_BUT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopMode_BUT.Name = "stopMode_BUT";
            this.stopMode_BUT.Size = new System.Drawing.Size(119, 28);
            this.stopMode_BUT.TabIndex = 20;
            this.stopMode_BUT.Text = "STOP";
            this.stopMode_BUT.UseVisualStyleBackColor = true;
            this.stopMode_BUT.Click += new System.EventHandler(this.stopMode_BUT_Click);
            // 
            // _label2
            // 
            this._label2.AutoSize = true;
            this._label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._label2.Location = new System.Drawing.Point(20, 79);
            this._label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(161, 17);
            this._label2.TabIndex = 22;
            this._label2.Text = "Количество спутников:";
            // 
            // satNum_label
            // 
            this.satNum_label.AutoSize = true;
            this.satNum_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.satNum_label.Location = new System.Drawing.Point(193, 79);
            this.satNum_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.satNum_label.Name = "satNum_label";
            this.satNum_label.Size = new System.Drawing.Size(16, 17);
            this.satNum_label.TabIndex = 23;
            this.satNum_label.Text = "0";
            // 
            // heading_label
            // 
            this.heading_label.AutoSize = true;
            this.heading_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.heading_label.Location = new System.Drawing.Point(132, 50);
            this.heading_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.heading_label.Name = "heading_label";
            this.heading_label.Size = new System.Drawing.Size(16, 17);
            this.heading_label.TabIndex = 25;
            this.heading_label.Text = "0";
            // 
            // _label3
            // 
            this._label3.AutoSize = true;
            this._label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._label3.Location = new System.Drawing.Point(20, 50);
            this._label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(101, 17);
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
            this.lbl_yawpwm.Location = new System.Drawing.Point(353, 277);
            this.lbl_yawpwm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_yawpwm.Name = "lbl_yawpwm";
            this.lbl_yawpwm.Size = new System.Drawing.Size(40, 17);
            this.lbl_yawpwm.TabIndex = 28;
            this.lbl_yawpwm.Text = "1500";
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.myTrackBar1.LargeChange = 0.005F;
            this.myTrackBar1.Location = new System.Drawing.Point(24, 271);
            this.myTrackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myTrackBar1.Maximum = 2000F;
            this.myTrackBar1.Minimum = 1000F;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(321, 56);
            this.myTrackBar1.SmallChange = 5F;
            this.myTrackBar1.TabIndex = 26;
            this.myTrackBar1.TickFrequency = 100F;
            this.myTrackBar1.Value = 1500F;
            // 
            // testAntButton
            // 
            this.testAntButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.testAntButton.Location = new System.Drawing.Point(276, 235);
            this.testAntButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.testAntButton.Name = "testAntButton";
            this.testAntButton.Size = new System.Drawing.Size(119, 28);
            this.testAntButton.TabIndex = 29;
            this.testAntButton.Text = "TEST";
            this.testAntButton.UseVisualStyleBackColor = true;
            this.testAntButton.Click += new System.EventHandler(this.BUT_test_yaw_Click);
            // 
            // switchAntenna_CB
            // 
            this.switchAntenna_CB.AutoSize = true;
            this.switchAntenna_CB.Location = new System.Drawing.Point(24, 305);
            this.switchAntenna_CB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.switchAntenna_CB.Name = "switchAntenna_CB";
            this.switchAntenna_CB.Size = new System.Drawing.Size(212, 21);
            this.switchAntenna_CB.TabIndex = 30;
            this.switchAntenna_CB.Text = "Переключиться на антенну";
            this.switchAntenna_CB.UseVisualStyleBackColor = true;
            this.switchAntenna_CB.CheckedChanged += new System.EventHandler(this.switchAntenna_CB_CheckedChanged);
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.AnimationInterval = 5;
            this.toggleSwitch1.AnimationStep = 60;
            this.toggleSwitch1.Location = new System.Drawing.Point(23, 334);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toggleSwitch1.OffText = "Переключиться на антенну";
            this.toggleSwitch1.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toggleSwitch1.OnText = "Переключиться на борт";
            this.toggleSwitch1.Size = new System.Drawing.Size(370, 29);
            this.toggleSwitch1.TabIndex = 31;
            // 
            // AntennaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.switchAntenna_CB);
            this.Controls.Add(this.testAntButton);
            this.Controls.Add(this.lbl_yawpwm);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AntennaControl";
            this.Size = new System.Drawing.Size(415, 492);
            ((System.ComponentModel.ISupportInitialize)(this.myTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antennaBindingSource)).EndInit();
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
        private MyTrackBar myTrackBar1;
        private System.Windows.Forms.Button testAntButton;
        private System.Windows.Forms.BindingSource antennaBindingSource;
        // private ToggleSwitch MetroStyleToggleSwitch;
        public System.Windows.Forms.CheckBox switchAntenna_CB;
        private JCS.ToggleSwitch toggleSwitch1;
    }
}
