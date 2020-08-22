using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Orlan;

namespace MissionPlanner
{
    partial class ConnectionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ConnectionsForm));
            this.devices_LB = new ListBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.aircraftNumber_TB = new TextBox();
            this.addAircraft_BT = new Button();
            this.panel1 = new Panel();
            this.useSITL_CheckBox = new CheckBox();
            this.reload_BUT = new Button();
            this.CMB_baudrate = new ComboBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.CMB_serialport = new ComboBox();
            this.connectedAircraftName_TB = new TextBox();
            this.connectedAircraftNum_TB = new TextBox();
            this.label4 = new Label();
            this.label3 = new Label();
            this.connect_BUT = new Button();
            this.timer1 = new Timer(this.components);
            this.panel2 = new Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // devices_LB
            // 
            this.devices_LB.BackColor = SystemColors.WindowText;
            this.devices_LB.BorderStyle = BorderStyle.None;
            this.devices_LB.ForeColor = SystemColors.Window;
            this.devices_LB.FormattingEnabled = true;
            resources.ApplyResources(this.devices_LB, "devices_LB");
            this.devices_LB.Name = "devices_LB";
            this.devices_LB.SelectedIndexChanged += new EventHandler(this.devices_LB_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // aircraftNumber_TB
            // 
            resources.ApplyResources(this.aircraftNumber_TB, "aircraftNumber_TB");
            this.aircraftNumber_TB.Name = "aircraftNumber_TB";
            this.aircraftNumber_TB.KeyPress += new KeyPressEventHandler(this.aircraftNumber_TB_KeyPress);
            // 
            // addAircraft_BT
            // 
            resources.ApplyResources(this.addAircraft_BT, "addAircraft_BT");
            this.addAircraft_BT.Name = "addAircraft_BT";
            this.addAircraft_BT.UseVisualStyleBackColor = true;
            this.addAircraft_BT.Click += new EventHandler(this.addAircraft_BT_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.useSITL_CheckBox);
            this.panel1.Controls.Add(this.reload_BUT);
            this.panel1.Controls.Add(this.CMB_baudrate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CMB_serialport);
            this.panel1.Controls.Add(this.connectedAircraftName_TB);
            this.panel1.Controls.Add(this.connectedAircraftNum_TB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // useSITL_CheckBox
            // 
            resources.ApplyResources(this.useSITL_CheckBox, "useSITL_CheckBox");
            this.useSITL_CheckBox.Name = "useSITL_CheckBox";
            this.useSITL_CheckBox.UseVisualStyleBackColor = true;
            this.useSITL_CheckBox.CheckedChanged += new EventHandler(this.useSITL_CheckBox_CheckedChanged);
            // 
            // reload_BUT
            // 
            resources.ApplyResources(this.reload_BUT, "reload_BUT");
            this.reload_BUT.Name = "reload_BUT";
            this.reload_BUT.UseVisualStyleBackColor = true;
            this.reload_BUT.Click += new EventHandler(this.reload_BUT_Click);
            // 
            // CMB_baudrate
            // 
            this.CMB_baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CMB_baudrate.FormattingEnabled = true;
            this.CMB_baudrate.Items.AddRange(new object[] {
            resources.GetString("CMB_baudrate.Items"),
            resources.GetString("CMB_baudrate.Items1"),
            resources.GetString("CMB_baudrate.Items2"),
            resources.GetString("CMB_baudrate.Items3"),
            resources.GetString("CMB_baudrate.Items4"),
            resources.GetString("CMB_baudrate.Items5"),
            resources.GetString("CMB_baudrate.Items6"),
            resources.GetString("CMB_baudrate.Items7"),
            resources.GetString("CMB_baudrate.Items8"),
            resources.GetString("CMB_baudrate.Items9"),
            resources.GetString("CMB_baudrate.Items10"),
            resources.GetString("CMB_baudrate.Items11"),
            resources.GetString("CMB_baudrate.Items12")});
            resources.ApplyResources(this.CMB_baudrate, "CMB_baudrate");
            this.CMB_baudrate.Name = "CMB_baudrate";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // CMB_serialport
            // 
            this.CMB_serialport.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CMB_serialport.FormattingEnabled = true;
            resources.ApplyResources(this.CMB_serialport, "CMB_serialport");
            this.CMB_serialport.Name = "CMB_serialport";
            // 
            // connectedAircraftName_TB
            // 
            resources.ApplyResources(this.connectedAircraftName_TB, "connectedAircraftName_TB");
            this.connectedAircraftName_TB.Name = "connectedAircraftName_TB";
            // 
            // connectedAircraftNum_TB
            // 
            resources.ApplyResources(this.connectedAircraftNum_TB, "connectedAircraftNum_TB");
            this.connectedAircraftNum_TB.Name = "connectedAircraftNum_TB";
            this.connectedAircraftNum_TB.TextChanged += new EventHandler(this.connectedAircraftNum_TB_TextChanged);
            this.connectedAircraftNum_TB.KeyPress += new KeyPressEventHandler(this.connectedAircraftNum_TB_KeyPress);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // connect_BUT
            // 
            resources.ApplyResources(this.connect_BUT, "connect_BUT");
            this.connect_BUT.Name = "connect_BUT";
            this.connect_BUT.UseVisualStyleBackColor = true;
            this.connect_BUT.Click += new EventHandler(this.connect_BUT_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.connect_BUT);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // ConnectionsForm
            // 
            this.AutoScaleMode = AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addAircraft_BT);
            this.Controls.Add(this.aircraftNumber_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devices_LB);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Name = "ConnectionsForm";
            this.TopMost = true;
            this.FormClosing += new FormClosingEventHandler(this.ConnectionsForm_FormClosing);
            this.Paint += new PaintEventHandler(this.ConnectionsForm_Paint);
            this.MouseMove += new MouseEventHandler(this.ConnectionsForm_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox devices_LB;
        private Label label1;
        private Label label2;
        private TextBox aircraftNumber_TB;
        private Button addAircraft_BT;
        private Panel panel1;
        private Button connect_BUT;
        private TextBox connectedAircraftName_TB;
        private TextBox connectedAircraftNum_TB;
        private Label label4;
        private Label label3;
        private ComboBox CMB_serialport;
        private Label label6;
        private Label label5;
        private ComboBox CMB_baudrate;
        private Timer timer1;
        private Panel panel2;
        private Button reload_BUT;
        private CheckBox useSITL_CheckBox;
    }
}