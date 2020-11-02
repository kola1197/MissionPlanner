using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner;

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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionsForm));
            this.devices_LB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aircraftNumber_TB = new System.Windows.Forms.TextBox();
            this.addAircraft_BT = new System.Windows.Forms.Button();
            this.connectionParams_panel = new System.Windows.Forms.Panel();
            this.useSITL_CheckBox = new JCS.ToggleSwitch();
            this.useAntenna_CheckBox = new JCS.ToggleSwitch();
            this.antennaPanel = new System.Windows.Forms.Panel();
            this.updateSysId_BUT = new System.Windows.Forms.Button();
            this.sysid_cmb = new System.Windows.Forms.ComboBox();
            this.reload_BUT = new System.Windows.Forms.Button();
            this.CMB_baudrate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CMB_serialport = new System.Windows.Forms.ComboBox();
            this.connectedAircraftName_TB = new System.Windows.Forms.TextBox();
            this.connectedAircraftNum_TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.connect_BUT = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.aircraftsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.airInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dictValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.connection_GB = new System.Windows.Forms.GroupBox();
            this.connectionParams_panel.SuspendLayout();
            this.antennaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.aircraftsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.airInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dictValueBindingSource)).BeginInit();
            this.connection_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // devices_LB
            // 
            this.devices_LB.BackColor = System.Drawing.SystemColors.WindowText;
            this.devices_LB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.devices_LB.ForeColor = System.Drawing.SystemColors.Window;
            this.devices_LB.FormattingEnabled = true;
            resources.ApplyResources(this.devices_LB, "devices_LB");
            this.devices_LB.Name = "devices_LB";
            this.devices_LB.SelectedIndexChanged += new System.EventHandler(this.devices_LB_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // aircraftNumber_TB
            // 
            resources.ApplyResources(this.aircraftNumber_TB, "aircraftNumber_TB");
            this.aircraftNumber_TB.Name = "aircraftNumber_TB";
            this.aircraftNumber_TB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.aircraftNumber_TB_KeyDown);
            this.aircraftNumber_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aircraftNumber_TB_KeyPress);
            // 
            // addAircraft_BT
            // 
            this.addAircraft_BT.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            resources.ApplyResources(this.addAircraft_BT, "addAircraft_BT");
            this.addAircraft_BT.ForeColor = System.Drawing.Color.Black;
            this.addAircraft_BT.Name = "addAircraft_BT";
            this.addAircraft_BT.UseVisualStyleBackColor = false;
            this.addAircraft_BT.Click += new System.EventHandler(this.addAircraft_BT_Click);
            // 
            // connectionParams_panel
            // 
            this.connectionParams_panel.Controls.Add(this.useSITL_CheckBox);
            this.connectionParams_panel.Controls.Add(this.useAntenna_CheckBox);
            this.connectionParams_panel.Controls.Add(this.antennaPanel);
            this.connectionParams_panel.Controls.Add(this.reload_BUT);
            this.connectionParams_panel.Controls.Add(this.CMB_baudrate);
            this.connectionParams_panel.Controls.Add(this.label6);
            this.connectionParams_panel.Controls.Add(this.label5);
            this.connectionParams_panel.Controls.Add(this.CMB_serialport);
            this.connectionParams_panel.Controls.Add(this.connectedAircraftName_TB);
            this.connectionParams_panel.Controls.Add(this.connectedAircraftNum_TB);
            this.connectionParams_panel.Controls.Add(this.label4);
            this.connectionParams_panel.Controls.Add(this.label3);
            resources.ApplyResources(this.connectionParams_panel, "connectionParams_panel");
            this.connectionParams_panel.Name = "connectionParams_panel";
            // 
            // useSITL_CheckBox
            // 
            this.useSITL_CheckBox.AnimationStep = 40;
            resources.ApplyResources(this.useSITL_CheckBox, "useSITL_CheckBox");
            this.useSITL_CheckBox.Name = "useSITL_CheckBox";
            this.useSITL_CheckBox.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.useSITL_CheckBox.OffText = "Использовать симуляцию";
            this.useSITL_CheckBox.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.useSITL_CheckBox.OnText = "Использовать симуляцию";
            this.useSITL_CheckBox.UseAnimation = false;
            this.useSITL_CheckBox.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.useSITL_CheckBox_CheckedChanged);
            // 
            // useAntenna_CheckBox
            // 
            this.useAntenna_CheckBox.AnimationStep = 40;
            resources.ApplyResources(this.useAntenna_CheckBox, "useAntenna_CheckBox");
            this.useAntenna_CheckBox.Name = "useAntenna_CheckBox";
            this.useAntenna_CheckBox.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.useAntenna_CheckBox.OffText = "Использовать антенну";
            this.useAntenna_CheckBox.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.useAntenna_CheckBox.OnText = "Использовать антенну";
            this.useAntenna_CheckBox.UseAnimation = false;
            this.useAntenna_CheckBox.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.useAntenna_CheckBox_CheckedChanged);
            // 
            // antennaPanel
            // 
            this.antennaPanel.Controls.Add(this.updateSysId_BUT);
            this.antennaPanel.Controls.Add(this.sysid_cmb);
            resources.ApplyResources(this.antennaPanel, "antennaPanel");
            this.antennaPanel.Name = "antennaPanel";
            // 
            // updateSysId_BUT
            // 
            this.updateSysId_BUT.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            this.updateSysId_BUT.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.updateSysId_BUT, "updateSysId_BUT");
            this.updateSysId_BUT.Name = "updateSysId_BUT";
            this.updateSysId_BUT.UseVisualStyleBackColor = false;
            this.updateSysId_BUT.Click += new System.EventHandler(this.updateSysId_BUT_Click);
            // 
            // sysid_cmb
            // 
            this.sysid_cmb.BackColor = System.Drawing.Color.Black;
            this.sysid_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sysid_cmb.DropDownWidth = 160;
            this.sysid_cmb.ForeColor = System.Drawing.Color.White;
            this.sysid_cmb.FormattingEnabled = true;
            resources.ApplyResources(this.sysid_cmb, "sysid_cmb");
            this.sysid_cmb.Name = "sysid_cmb";
            this.sysid_cmb.DropDown += new System.EventHandler(this.sysid_cmb_DropDown);
            this.sysid_cmb.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.sysid_cmb_Format);
            // 
            // reload_BUT
            // 
            this.reload_BUT.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            resources.ApplyResources(this.reload_BUT, "reload_BUT");
            this.reload_BUT.ForeColor = System.Drawing.Color.Black;
            this.reload_BUT.Name = "reload_BUT";
            this.reload_BUT.UseVisualStyleBackColor = false;
            this.reload_BUT.Click += new System.EventHandler(this.reload_BUT_Click);
            // 
            // CMB_baudrate
            // 
            this.CMB_baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_baudrate.FormattingEnabled = true;
            this.CMB_baudrate.Items.AddRange(new object[] {resources.GetString("CMB_baudrate.Items"), resources.GetString("CMB_baudrate.Items1"), resources.GetString("CMB_baudrate.Items2"), resources.GetString("CMB_baudrate.Items3"), resources.GetString("CMB_baudrate.Items4"), resources.GetString("CMB_baudrate.Items5"), resources.GetString("CMB_baudrate.Items6"), resources.GetString("CMB_baudrate.Items7"), resources.GetString("CMB_baudrate.Items8"), resources.GetString("CMB_baudrate.Items9"), resources.GetString("CMB_baudrate.Items10"), resources.GetString("CMB_baudrate.Items11"), resources.GetString("CMB_baudrate.Items12")});
            resources.ApplyResources(this.CMB_baudrate, "CMB_baudrate");
            this.CMB_baudrate.Name = "CMB_baudrate";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // CMB_serialport
            // 
            this.CMB_serialport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_serialport.FormattingEnabled = true;
            resources.ApplyResources(this.CMB_serialport, "CMB_serialport");
            this.CMB_serialport.Name = "CMB_serialport";
            // 
            // connectedAircraftName_TB
            // 
            resources.ApplyResources(this.connectedAircraftName_TB, "connectedAircraftName_TB");
            this.connectedAircraftName_TB.Name = "connectedAircraftName_TB";
            this.connectedAircraftName_TB.TextChanged += new System.EventHandler(this.connectedAircraftName_TB_TextChanged);
            // 
            // connectedAircraftNum_TB
            // 
            resources.ApplyResources(this.connectedAircraftNum_TB, "connectedAircraftNum_TB");
            this.connectedAircraftNum_TB.Name = "connectedAircraftNum_TB";
            this.connectedAircraftNum_TB.TextChanged += new System.EventHandler(this.connectedAircraftNum_TB_TextChanged);
            this.connectedAircraftNum_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.connectedAircraftNum_TB_KeyPress);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // connect_BUT
            // 
            this.connect_BUT.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (196)))), ((int) (((byte) (196)))), ((int) (((byte) (196)))));
            resources.ApplyResources(this.connect_BUT, "connect_BUT");
            this.connect_BUT.ForeColor = System.Drawing.Color.Black;
            this.connect_BUT.Name = "connect_BUT";
            this.connect_BUT.UseVisualStyleBackColor = false;
            this.connect_BUT.Click += new System.EventHandler(this.connect_BUT_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // connection_GB
            // 
            this.connection_GB.Controls.Add(this.connect_BUT);
            resources.ApplyResources(this.connection_GB, "connection_GB");
            this.connection_GB.Name = "connection_GB";
            this.connection_GB.TabStop = false;
            // 
            // ConnectionsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.connectionParams_panel);
            this.Controls.Add(this.connection_GB);
            this.Controls.Add(this.addAircraft_BT);
            this.Controls.Add(this.aircraftNumber_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.devices_LB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectionsForm";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.ConnectionsForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionsForm_FormClosing);
            this.Shown += new System.EventHandler(this.ConnectionsForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConnectionsForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ConnectionsForm_MouseMove);
            this.connectionParams_panel.ResumeLayout(false);
            this.connectionParams_panel.PerformLayout();
            this.antennaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.aircraftsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.airInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dictValueBindingSource)).EndInit();
            this.connection_GB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button updateSysId_BUT;

        #endregion

        private ListBox devices_LB;
        private Label label2;
        private TextBox aircraftNumber_TB;
        private Button addAircraft_BT;
        private Panel connectionParams_panel;
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
        private Button reload_BUT;
        private Panel antennaPanel;
        public ComboBox sysid_cmb;
        private BindingSource aircraftsBindingSource;
        private BindingSource airInfoBindingSource;
        private BindingSource dictValueBindingSource;
        private GroupBox connection_GB;
        private JCS.ToggleSwitch useSITL_CheckBox;
        private JCS.ToggleSwitch useAntenna_CheckBox;
    }
}