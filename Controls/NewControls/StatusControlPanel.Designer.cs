﻿using System.ComponentModel;
using MissionPlanner.Controls.NewControls;

namespace MissionPlanner.Controls
{
    partial class StatusControlPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusControlPanel));
            this.rpmICE_label = new System.Windows.Forms.Label();
            this.flightMode_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fuel_label = new System.Windows.Forms.Label();
            this.voltage_label = new System.Windows.Forms.Label();
            this.airspeed_label = new System.Windows.Forms.Label();
            this.engineTemp_label = new System.Windows.Forms.Label();
            this.altitude_label = new System.Windows.Forms.Label();
            this.targetAlt_label = new System.Windows.Forms.Label();
            this.verticalSpeed_label = new System.Windows.Forms.Label();
            this.groundSpeed_label = new System.Windows.Forms.Label();
            this.environmentTemp_label = new System.Windows.Forms.Label();
            this.averageRpmICE_label = new System.Windows.Forms.Label();
            this.hudPanel = new System.Windows.Forms.Panel();
            this.HorizonHUD = new MissionPlanner.Controls.HorizonHUD();
            this.bindingSourceHud = new System.Windows.Forms.BindingSource(this.components);
            this.sensorsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.напряжениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.температураДвигателяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.топливоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.воздушнаяСкоростьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.путеваяСкоростьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.высотаСНСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.магнитныйКурсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.следующаяТочкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.силаТокаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensor_panel = new System.Windows.Forms.Panel();
            this.sensorsMenuStrip = new System.Windows.Forms.MenuStrip();
            this.addOrRemovePanel = new System.Windows.Forms.Panel();
            this.hideSensor_BUT = new System.Windows.Forms.Button();
            this.showSensor_BUT = new System.Windows.Forms.Button();
            this.fuel_PB = new System.Windows.Forms.PictureBox();
            this.enginePanel = new System.Windows.Forms.Panel();
            this.voltage_PB = new System.Windows.Forms.PictureBox();
            this.splittedBar_voltage = new MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar();
            this.bindingSourceCurrentState = new System.Windows.Forms.BindingSource(this.components);
            this.splittedBar_fuel = new MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar();
            this.speedPanel = new System.Windows.Forms.Panel();
            this.groundspeed_PB = new System.Windows.Forms.PictureBox();
            this.airspeed_PB = new System.Windows.Forms.PictureBox();
            this.airspeed_SVPB = new MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar();
            this.groundSpeed_SVPB = new MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar();
            this.temperaturePanel = new System.Windows.Forms.Panel();
            this.engineTemp_PB = new System.Windows.Forms.PictureBox();
            this.environmentTemp_PB = new System.Windows.Forms.PictureBox();
            this.environmentTemp_SVPB = new MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar();
            this.engineTemp_SVPB = new MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar();
            this.airspeedDirectionControl2 = new MissionPlanner.Controls.NewControls.AirspeedDirectionControl();
            this.hudPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.bindingSourceHud)).BeginInit();
            this.sensorsContextMenuStrip.SuspendLayout();
            this.sensor_panel.SuspendLayout();
            this.addOrRemovePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.fuel_PB)).BeginInit();
            this.enginePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.voltage_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.bindingSourceCurrentState)).BeginInit();
            this.speedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.groundspeed_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.airspeed_PB)).BeginInit();
            this.temperaturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.engineTemp_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.environmentTemp_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // rpmICE_label
            // 
            this.rpmICE_label.AutoSize = true;
            this.rpmICE_label.Location = new System.Drawing.Point(80, 0);
            this.rpmICE_label.Name = "rpmICE_label";
            this.rpmICE_label.Size = new System.Drawing.Size(41, 13);
            this.rpmICE_label.TabIndex = 3;
            this.rpmICE_label.Text = "rpmICE";
            // 
            // flightMode_label
            // 
            this.flightMode_label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flightMode_label.AutoSize = true;
            this.flightMode_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.flightMode_label.ForeColor = System.Drawing.Color.White;
            this.flightMode_label.Location = new System.Drawing.Point(23, 104);
            this.flightMode_label.MinimumSize = new System.Drawing.Size(150, 24);
            this.flightMode_label.Name = "flightMode_label";
            this.flightMode_label.Size = new System.Drawing.Size(150, 24);
            this.flightMode_label.TabIndex = 4;
            this.flightMode_label.Text = "flightMode";
            this.flightMode_label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fuel_label
            // 
            this.fuel_label.AutoSize = true;
            this.fuel_label.Location = new System.Drawing.Point(0, 0);
            this.fuel_label.Name = "fuel_label";
            this.fuel_label.Size = new System.Drawing.Size(24, 13);
            this.fuel_label.TabIndex = 5;
            this.fuel_label.Text = "fuel";
            // 
            // voltage_label
            // 
            this.voltage_label.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.voltage_label.AutoSize = true;
            this.voltage_label.Location = new System.Drawing.Point(157, 0);
            this.voltage_label.MaximumSize = new System.Drawing.Size(42, 13);
            this.voltage_label.MinimumSize = new System.Drawing.Size(42, 13);
            this.voltage_label.Name = "voltage_label";
            this.voltage_label.Size = new System.Drawing.Size(42, 13);
            this.voltage_label.TabIndex = 6;
            this.voltage_label.Text = "voltage";
            this.voltage_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // airspeed_label
            // 
            this.airspeed_label.AutoSize = true;
            this.airspeed_label.Location = new System.Drawing.Point(0, 0);
            this.airspeed_label.Name = "airspeed_label";
            this.airspeed_label.Size = new System.Drawing.Size(47, 13);
            this.airspeed_label.TabIndex = 7;
            this.airspeed_label.Text = "airspeed";
            // 
            // engineTemp_label
            // 
            this.engineTemp_label.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.engineTemp_label.AutoSize = true;
            this.engineTemp_label.Location = new System.Drawing.Point(133, 0);
            this.engineTemp_label.MaximumSize = new System.Drawing.Size(66, 13);
            this.engineTemp_label.MinimumSize = new System.Drawing.Size(66, 13);
            this.engineTemp_label.Name = "engineTemp_label";
            this.engineTemp_label.Size = new System.Drawing.Size(66, 13);
            this.engineTemp_label.TabIndex = 10;
            this.engineTemp_label.Text = "engineTemp";
            this.engineTemp_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // altitude_label
            // 
            this.altitude_label.AutoSize = true;
            this.altitude_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.altitude_label.ForeColor = System.Drawing.Color.White;
            this.altitude_label.Location = new System.Drawing.Point(32, 27);
            this.altitude_label.MinimumSize = new System.Drawing.Size(54, 37);
            this.altitude_label.Name = "altitude_label";
            this.altitude_label.Size = new System.Drawing.Size(54, 37);
            this.altitude_label.TabIndex = 11;
            this.altitude_label.Text = "alt";
            this.altitude_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // targetAlt_label
            // 
            this.targetAlt_label.AutoSize = true;
            this.targetAlt_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.targetAlt_label.ForeColor = System.Drawing.Color.White;
            this.targetAlt_label.Location = new System.Drawing.Point(98, 70);
            this.targetAlt_label.Name = "targetAlt_label";
            this.targetAlt_label.Size = new System.Drawing.Size(75, 25);
            this.targetAlt_label.TabIndex = 12;
            this.targetAlt_label.Text = "trgtAlt";
            // 
            // verticalSpeed_label
            // 
            this.verticalSpeed_label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.verticalSpeed_label.AutoSize = true;
            this.verticalSpeed_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.verticalSpeed_label.ForeColor = System.Drawing.Color.White;
            this.verticalSpeed_label.Location = new System.Drawing.Point(35, 104);
            this.verticalSpeed_label.MinimumSize = new System.Drawing.Size(124, 24);
            this.verticalSpeed_label.Name = "verticalSpeed_label";
            this.verticalSpeed_label.Size = new System.Drawing.Size(124, 24);
            this.verticalSpeed_label.TabIndex = 13;
            this.verticalSpeed_label.Text = "verticalSpeed";
            this.verticalSpeed_label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // groundSpeed_label
            // 
            this.groundSpeed_label.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groundSpeed_label.AutoSize = true;
            this.groundSpeed_label.Location = new System.Drawing.Point(128, 0);
            this.groundSpeed_label.MaximumSize = new System.Drawing.Size(71, 13);
            this.groundSpeed_label.MinimumSize = new System.Drawing.Size(71, 13);
            this.groundSpeed_label.Name = "groundSpeed_label";
            this.groundSpeed_label.Size = new System.Drawing.Size(71, 13);
            this.groundSpeed_label.TabIndex = 15;
            this.groundSpeed_label.Text = "groundSpeed";
            this.groundSpeed_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // environmentTemp_label
            // 
            this.environmentTemp_label.AutoSize = true;
            this.environmentTemp_label.Location = new System.Drawing.Point(0, 0);
            this.environmentTemp_label.Name = "environmentTemp_label";
            this.environmentTemp_label.Size = new System.Drawing.Size(92, 13);
            this.environmentTemp_label.TabIndex = 17;
            this.environmentTemp_label.Text = "environmentTemp";
            // 
            // averageRpmICE_label
            // 
            this.averageRpmICE_label.AutoSize = true;
            this.averageRpmICE_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.averageRpmICE_label.ForeColor = System.Drawing.Color.White;
            this.averageRpmICE_label.Location = new System.Drawing.Point(23, 48);
            this.averageRpmICE_label.MinimumSize = new System.Drawing.Size(152, 37);
            this.averageRpmICE_label.Name = "averageRpmICE_label";
            this.averageRpmICE_label.Size = new System.Drawing.Size(152, 37);
            this.averageRpmICE_label.TabIndex = 18;
            this.averageRpmICE_label.Text = "averRpm";
            this.averageRpmICE_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hudPanel
            // 
            this.hudPanel.Controls.Add(this.HorizonHUD);
            this.hudPanel.Location = new System.Drawing.Point(23, 16);
            this.hudPanel.Name = "hudPanel";
            this.hudPanel.Size = new System.Drawing.Size(150, 100);
            this.hudPanel.TabIndex = 19;
            // 
            // HorizonHUD
            // 
            this.HorizonHUD.airspeed = 0F;
            this.HorizonHUD.alt = 0F;
            this.HorizonHUD.altunit = null;
            this.HorizonHUD.AOA = 0F;
            this.HorizonHUD.BackColor = System.Drawing.Color.Black;
            this.HorizonHUD.batterylevel = 0F;
            this.HorizonHUD.batteryremaining = 0F;
            this.HorizonHUD.bgimage = null;
            this.HorizonHUD.connected = false;
            this.HorizonHUD.critAOA = 25F;
            this.HorizonHUD.critSSA = 30F;
            this.HorizonHUD.current = 0F;
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("airspeed", this.bindingSourceHud, "airspeed", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("alt", this.bindingSourceHud, "alt", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("batterylevel", this.bindingSourceHud, "battery_voltage", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("batteryremaining", this.bindingSourceHud, "battery_remaining", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("connected", this.bindingSourceHud, "connected", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("current", this.bindingSourceHud, "current", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("datetime", this.bindingSourceHud, "datetime", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("disttowp", this.bindingSourceHud, "wp_dist", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("ekfstatus", this.bindingSourceHud, "ekfstatus", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("failsafe", this.bindingSourceHud, "failsafe", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("gpsfix", this.bindingSourceHud, "gpsstatus", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("gpsfix2", this.bindingSourceHud, "gpsstatus2", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("gpshdop", this.bindingSourceHud, "gpshdop", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("gpshdop2", this.bindingSourceHud, "gpshdop2", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("groundalt", this.bindingSourceHud, "HomeAlt", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("groundcourse", this.bindingSourceHud, "groundcourse", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("groundspeed", this.bindingSourceHud, "groundspeed", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("heading", this.bindingSourceHud, "yaw", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("linkqualitygcs", this.bindingSourceHud, "linkqualitygcs", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("message", this.bindingSourceHud, "messageHigh", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("mode", this.bindingSourceHud, "mode", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("navpitch", this.bindingSourceHud, "nav_pitch", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("navroll", this.bindingSourceHud, "nav_roll", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("pitch", this.bindingSourceHud, "pitch", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("roll", this.bindingSourceHud, "roll", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("status", this.bindingSourceHud, "armed", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("targetalt", this.bindingSourceHud, "targetalt", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("targetheading", this.bindingSourceHud, "nav_bearing", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("targetspeed", this.bindingSourceHud, "targetairspeed", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("turnrate", this.bindingSourceHud, "turnrate", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("verticalspeed", this.bindingSourceHud, "verticalspeed", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("vibex", this.bindingSourceHud, "vibex", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("vibey", this.bindingSourceHud, "vibey", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("vibez", this.bindingSourceHud, "vibez", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("wpno", this.bindingSourceHud, "wpno", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("xtrack_error", this.bindingSourceHud, "xtrack_error", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("AOA", this.bindingSourceHud, "AOA", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("SSA", this.bindingSourceHud, "SSA", true));
            this.HorizonHUD.DataBindings.Add(new System.Windows.Forms.Binding("critAOA", this.bindingSourceHud, "crit_AOA", true));
            this.HorizonHUD.datetime = new System.DateTime(((long) (0)));
            this.HorizonHUD.displayAOASSA = false;
            this.HorizonHUD.disttowp = 0F;
            this.HorizonHUD.distunit = null;
            this.HorizonHUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HorizonHUD.ekfstatus = 0F;
            this.HorizonHUD.failsafe = false;
            this.HorizonHUD.gpsfix = 0F;
            this.HorizonHUD.gpsfix2 = 0F;
            this.HorizonHUD.gpshdop = 0F;
            this.HorizonHUD.gpshdop2 = 0F;
            this.HorizonHUD.groundalt = 0F;
            this.HorizonHUD.groundcourse = 0F;
            this.HorizonHUD.groundspeed = 0F;
            this.HorizonHUD.heading = 0F;
            this.HorizonHUD.hudcolor = System.Drawing.Color.LightGray;
            this.HorizonHUD.linkqualitygcs = 0F;
            this.HorizonHUD.Location = new System.Drawing.Point(0, 0);
            this.HorizonHUD.lowairspeed = false;
            this.HorizonHUD.lowgroundspeed = false;
            this.HorizonHUD.lowvoltagealert = false;
            this.HorizonHUD.message = "";
            this.HorizonHUD.mode = "Unknown";
            this.HorizonHUD.Name = "HorizonHUD";
            this.HorizonHUD.navpitch = 0F;
            this.HorizonHUD.navroll = 0F;
            this.HorizonHUD.pitch = 0F;
            this.HorizonHUD.roll = 0F;
            this.HorizonHUD.Russian = false;
            this.HorizonHUD.Size = new System.Drawing.Size(150, 100);
            this.HorizonHUD.skyColor1 = System.Drawing.Color.Blue;
            this.HorizonHUD.skyColor2 = System.Drawing.Color.LightBlue;
            this.HorizonHUD.speedunit = null;
            this.HorizonHUD.SSA = 0F;
            this.HorizonHUD.status = false;
            this.HorizonHUD.streamjpg = null;
            this.HorizonHUD.TabIndex = 2;
            this.HorizonHUD.targetalt = 0F;
            this.HorizonHUD.targetheading = 0F;
            this.HorizonHUD.targetspeed = 0F;
            this.HorizonHUD.turnrate = 0F;
            this.HorizonHUD.verticalspeed = 0F;
            this.HorizonHUD.vibex = 0F;
            this.HorizonHUD.vibey = 0F;
            this.HorizonHUD.vibez = 0F;
            this.HorizonHUD.VSync = false;
            this.HorizonHUD.wpno = 0;
            this.HorizonHUD.xtrack_error = 0F;
            // 
            // bindingSourceHud
            // 
            this.bindingSourceHud.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // sensorsContextMenuStrip
            // 
            this.sensorsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.напряжениеToolStripMenuItem, this.температураДвигателяToolStripMenuItem, this.топливоToolStripMenuItem, this.воздушнаяСкоростьToolStripMenuItem, this.путеваяСкоростьToolStripMenuItem, this.высотаСНСToolStripMenuItem, this.магнитныйКурсToolStripMenuItem, this.следующаяТочкаToolStripMenuItem, this.силаТокаToolStripMenuItem});
            this.sensorsContextMenuStrip.Name = "contextMenuStrip1";
            this.sensorsContextMenuStrip.Size = new System.Drawing.Size(203, 202);
            // 
            // напряжениеToolStripMenuItem
            // 
            this.напряжениеToolStripMenuItem.Name = "напряжениеToolStripMenuItem";
            this.напряжениеToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.напряжениеToolStripMenuItem.Text = "Напряжение";
            this.напряжениеToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // температураДвигателяToolStripMenuItem
            // 
            this.температураДвигателяToolStripMenuItem.Name = "температураДвигателяToolStripMenuItem";
            this.температураДвигателяToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.температураДвигателяToolStripMenuItem.Text = "Температура двигателя";
            this.температураДвигателяToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // топливоToolStripMenuItem
            // 
            this.топливоToolStripMenuItem.Name = "топливоToolStripMenuItem";
            this.топливоToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.топливоToolStripMenuItem.Text = "Топливо";
            this.топливоToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // воздушнаяСкоростьToolStripMenuItem
            // 
            this.воздушнаяСкоростьToolStripMenuItem.Name = "воздушнаяСкоростьToolStripMenuItem";
            this.воздушнаяСкоростьToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.воздушнаяСкоростьToolStripMenuItem.Text = "Воздушная скорость";
            this.воздушнаяСкоростьToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // путеваяСкоростьToolStripMenuItem
            // 
            this.путеваяСкоростьToolStripMenuItem.Name = "путеваяСкоростьToolStripMenuItem";
            this.путеваяСкоростьToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.путеваяСкоростьToolStripMenuItem.Text = "Путевая скорость";
            this.путеваяСкоростьToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // высотаСНСToolStripMenuItem
            // 
            this.высотаСНСToolStripMenuItem.Name = "высотаСНСToolStripMenuItem";
            this.высотаСНСToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.высотаСНСToolStripMenuItem.Text = "Высота (СНС)";
            this.высотаСНСToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // магнитныйКурсToolStripMenuItem
            // 
            this.магнитныйКурсToolStripMenuItem.Name = "магнитныйКурсToolStripMenuItem";
            this.магнитныйКурсToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.магнитныйКурсToolStripMenuItem.Text = "Магнитный курс";
            this.магнитныйКурсToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // следующаяТочкаToolStripMenuItem
            // 
            this.следующаяТочкаToolStripMenuItem.Name = "следующаяТочкаToolStripMenuItem";
            this.следующаяТочкаToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.следующаяТочкаToolStripMenuItem.Text = "Следующая точка";
            this.следующаяТочкаToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // силаТокаToolStripMenuItem
            // 
            this.силаТокаToolStripMenuItem.Name = "силаТокаToolStripMenuItem";
            this.силаТокаToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.силаТокаToolStripMenuItem.Text = "Сила тока";
            this.силаТокаToolStripMenuItem.Click += new System.EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // sensor_panel
            // 
            this.sensor_panel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.sensor_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sensor_panel.Controls.Add(this.sensorsMenuStrip);
            this.sensor_panel.Location = new System.Drawing.Point(760, 0);
            this.sensor_panel.MinimumSize = new System.Drawing.Size(130, 123);
            this.sensor_panel.Name = "sensor_panel";
            this.sensor_panel.Size = new System.Drawing.Size(161, 140);
            this.sensor_panel.TabIndex = 77;
            // 
            // sensorsMenuStrip
            // 
            this.sensorsMenuStrip.BackgroundImage = global::MissionPlanner.Properties.Resources.nonefon1;
            this.sensorsMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorsMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.sensorsMenuStrip.Name = "sensorsMenuStrip";
            this.sensorsMenuStrip.Size = new System.Drawing.Size(161, 140);
            this.sensorsMenuStrip.TabIndex = 0;
            this.sensorsMenuStrip.Text = "menuStrip1";
            // 
            // addOrRemovePanel
            // 
            this.addOrRemovePanel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.addOrRemovePanel.Controls.Add(this.hideSensor_BUT);
            this.addOrRemovePanel.Controls.Add(this.showSensor_BUT);
            this.addOrRemovePanel.Location = new System.Drawing.Point(927, 0);
            this.addOrRemovePanel.Name = "addOrRemovePanel";
            this.addOrRemovePanel.Size = new System.Drawing.Size(43, 140);
            this.addOrRemovePanel.TabIndex = 80;
            // 
            // hideSensor_BUT
            // 
            this.hideSensor_BUT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.hideSensor_BUT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.hideSensor_BUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideSensor_BUT.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.hideSensor_BUT.ForeColor = System.Drawing.Color.White;
            this.hideSensor_BUT.Location = new System.Drawing.Point(3, 70);
            this.hideSensor_BUT.Name = "hideSensor_BUT";
            this.hideSensor_BUT.Size = new System.Drawing.Size(37, 23);
            this.hideSensor_BUT.TabIndex = 1;
            this.hideSensor_BUT.Text = "<";
            this.hideSensor_BUT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.hideSensor_BUT.UseVisualStyleBackColor = true;
            this.hideSensor_BUT.Click += new System.EventHandler(this.hideSensor_BUT_Click);
            // 
            // showSensor_BUT
            // 
            this.showSensor_BUT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.showSensor_BUT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.showSensor_BUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showSensor_BUT.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.showSensor_BUT.ForeColor = System.Drawing.Color.White;
            this.showSensor_BUT.Location = new System.Drawing.Point(3, 27);
            this.showSensor_BUT.Name = "showSensor_BUT";
            this.showSensor_BUT.Size = new System.Drawing.Size(37, 23);
            this.showSensor_BUT.TabIndex = 0;
            this.showSensor_BUT.Text = " >";
            this.showSensor_BUT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.showSensor_BUT.UseVisualStyleBackColor = false;
            this.showSensor_BUT.Click += new System.EventHandler(this.showSensor_BUT_Click);
            // 
            // fuel_PB
            // 
            this.fuel_PB.BackColor = System.Drawing.Color.Transparent;
            this.fuel_PB.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_oil;
            this.fuel_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fuel_PB.Location = new System.Drawing.Point(0, 115);
            this.fuel_PB.Name = "fuel_PB";
            this.fuel_PB.Size = new System.Drawing.Size(25, 25);
            this.fuel_PB.TabIndex = 81;
            this.fuel_PB.TabStop = false;
            // 
            // enginePanel
            // 
            this.enginePanel.BackColor = System.Drawing.Color.Transparent;
            this.enginePanel.Controls.Add(this.voltage_PB);
            this.enginePanel.Controls.Add(this.splittedBar_voltage);
            this.enginePanel.Controls.Add(this.splittedBar_fuel);
            this.enginePanel.Controls.Add(this.fuel_PB);
            this.enginePanel.Controls.Add(this.rpmICE_label);
            this.enginePanel.Controls.Add(this.flightMode_label);
            this.enginePanel.Controls.Add(this.fuel_label);
            this.enginePanel.Controls.Add(this.voltage_label);
            this.enginePanel.Controls.Add(this.averageRpmICE_label);
            this.enginePanel.Location = new System.Drawing.Point(0, 0);
            this.enginePanel.Name = "enginePanel";
            this.enginePanel.Size = new System.Drawing.Size(199, 140);
            this.enginePanel.TabIndex = 82;
            this.enginePanel.Click += new System.EventHandler(this.enginePanel_Click);
            // 
            // voltage_PB
            // 
            this.voltage_PB.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_lightning;
            this.voltage_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.voltage_PB.Location = new System.Drawing.Point(174, 115);
            this.voltage_PB.Name = "voltage_PB";
            this.voltage_PB.Size = new System.Drawing.Size(25, 25);
            this.voltage_PB.TabIndex = 82;
            this.voltage_PB.TabStop = false;
            // 
            // splittedBar_voltage
            // 
            this.splittedBar_voltage.BorderStyle = MissionPlanner.Controls.NewControls.BorderStyles.Classic;
            this.splittedBar_voltage.Color = System.Drawing.Color.LimeGreen;
            this.splittedBar_voltage.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceCurrentState, "battery_voltage", true));
            this.splittedBar_voltage.Location = new System.Drawing.Point(174, 16);
            this.splittedBar_voltage.Maximum = 12.6D;
            this.splittedBar_voltage.Minimum = 9.9D;
            this.splittedBar_voltage.Name = "splittedBar_voltage";
            this.splittedBar_voltage.Size = new System.Drawing.Size(25, 99);
            this.splittedBar_voltage.Step = 0.27D;
            this.splittedBar_voltage.Style = MissionPlanner.Controls.NewControls.Styles.Classic;
            this.splittedBar_voltage.TabIndex = 2;
            this.splittedBar_voltage.Value = 12D;
            // 
            // bindingSourceCurrentState
            // 
            this.bindingSourceCurrentState.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // splittedBar_fuel
            // 
            this.splittedBar_fuel.BorderStyle = MissionPlanner.Controls.NewControls.BorderStyles.Classic;
            this.splittedBar_fuel.Color = System.Drawing.Color.LimeGreen;
            this.splittedBar_fuel.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceCurrentState, "battery_voltage2", true));
            this.splittedBar_fuel.Location = new System.Drawing.Point(0, 16);
            this.splittedBar_fuel.Maximum = 5D;
            this.splittedBar_fuel.Minimum = 0D;
            this.splittedBar_fuel.Name = "splittedBar_fuel";
            this.splittedBar_fuel.Size = new System.Drawing.Size(25, 99);
            this.splittedBar_fuel.Step = 0.5D;
            this.splittedBar_fuel.Style = MissionPlanner.Controls.NewControls.Styles.Classic;
            this.splittedBar_fuel.TabIndex = 1;
            this.splittedBar_fuel.Value = 0D;
            // 
            // speedPanel
            // 
            this.speedPanel.BackColor = System.Drawing.Color.Transparent;
            this.speedPanel.Controls.Add(this.groundspeed_PB);
            this.speedPanel.Controls.Add(this.airspeed_PB);
            this.speedPanel.Controls.Add(this.airspeed_SVPB);
            this.speedPanel.Controls.Add(this.airspeed_label);
            this.speedPanel.Controls.Add(this.altitude_label);
            this.speedPanel.Controls.Add(this.verticalSpeed_label);
            this.speedPanel.Controls.Add(this.groundSpeed_SVPB);
            this.speedPanel.Controls.Add(this.targetAlt_label);
            this.speedPanel.Controls.Add(this.groundSpeed_label);
            this.speedPanel.Location = new System.Drawing.Point(205, 0);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Size = new System.Drawing.Size(199, 140);
            this.speedPanel.TabIndex = 83;
            this.speedPanel.Click += new System.EventHandler(this.speedPanel_Click);
            // 
            // groundspeed_PB
            // 
            this.groundspeed_PB.BackColor = System.Drawing.Color.Transparent;
            this.groundspeed_PB.BackgroundImage = global::MissionPlanner.Properties.Resources.speedFly;
            this.groundspeed_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groundspeed_PB.Location = new System.Drawing.Point(174, 115);
            this.groundspeed_PB.Name = "groundspeed_PB";
            this.groundspeed_PB.Size = new System.Drawing.Size(25, 25);
            this.groundspeed_PB.TabIndex = 17;
            this.groundspeed_PB.TabStop = false;
            // 
            // airspeed_PB
            // 
            this.airspeed_PB.BackColor = System.Drawing.Color.Transparent;
            this.airspeed_PB.BackgroundImage = global::MissionPlanner.Properties.Resources.speedAir;
            this.airspeed_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.airspeed_PB.Location = new System.Drawing.Point(0, 115);
            this.airspeed_PB.Name = "airspeed_PB";
            this.airspeed_PB.Size = new System.Drawing.Size(25, 25);
            this.airspeed_PB.TabIndex = 16;
            this.airspeed_PB.TabStop = false;
            // 
            // airspeed_SVPB
            // 
            this.airspeed_SVPB.BorderStyle = MissionPlanner.Controls.NewControls.BorderStyles.Classic;
            this.airspeed_SVPB.Color = System.Drawing.Color.LimeGreen;
            this.airspeed_SVPB.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceCurrentState, "airspeed", true));
            this.airspeed_SVPB.Location = new System.Drawing.Point(0, 16);
            this.airspeed_SVPB.Maximum = 40D;
            this.airspeed_SVPB.Minimum = 0D;
            this.airspeed_SVPB.Name = "airspeed_SVPB";
            this.airspeed_SVPB.Size = new System.Drawing.Size(25, 99);
            this.airspeed_SVPB.Step = 4.61D;
            this.airspeed_SVPB.Style = MissionPlanner.Controls.NewControls.Styles.Classic;
            this.airspeed_SVPB.TabIndex = 8;
            this.airspeed_SVPB.Value = 12D;
            // 
            // groundSpeed_SVPB
            // 
            this.groundSpeed_SVPB.BorderStyle = MissionPlanner.Controls.NewControls.BorderStyles.Classic;
            this.groundSpeed_SVPB.Color = System.Drawing.Color.LimeGreen;
            this.groundSpeed_SVPB.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceCurrentState, "groundspeed", true));
            this.groundSpeed_SVPB.Location = new System.Drawing.Point(174, 16);
            this.groundSpeed_SVPB.Maximum = 40D;
            this.groundSpeed_SVPB.Minimum = 0D;
            this.groundSpeed_SVPB.Name = "groundSpeed_SVPB";
            this.groundSpeed_SVPB.Size = new System.Drawing.Size(25, 99);
            this.groundSpeed_SVPB.Step = 4.61D;
            this.groundSpeed_SVPB.Style = MissionPlanner.Controls.NewControls.Styles.Classic;
            this.groundSpeed_SVPB.TabIndex = 14;
            this.groundSpeed_SVPB.Value = 10D;
            // 
            // temperaturePanel
            // 
            this.temperaturePanel.BackColor = System.Drawing.Color.Transparent;
            this.temperaturePanel.Controls.Add(this.engineTemp_PB);
            this.temperaturePanel.Controls.Add(this.environmentTemp_PB);
            this.temperaturePanel.Controls.Add(this.environmentTemp_SVPB);
            this.temperaturePanel.Controls.Add(this.environmentTemp_label);
            this.temperaturePanel.Controls.Add(this.hudPanel);
            this.temperaturePanel.Controls.Add(this.engineTemp_SVPB);
            this.temperaturePanel.Controls.Add(this.engineTemp_label);
            this.temperaturePanel.Location = new System.Drawing.Point(410, 0);
            this.temperaturePanel.Name = "temperaturePanel";
            this.temperaturePanel.Size = new System.Drawing.Size(199, 140);
            this.temperaturePanel.TabIndex = 84;
            // 
            // engineTemp_PB
            // 
            this.engineTemp_PB.BackColor = System.Drawing.Color.Transparent;
            this.engineTemp_PB.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_engine;
            this.engineTemp_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.engineTemp_PB.Location = new System.Drawing.Point(174, 115);
            this.engineTemp_PB.Name = "engineTemp_PB";
            this.engineTemp_PB.Size = new System.Drawing.Size(25, 25);
            this.engineTemp_PB.TabIndex = 20;
            this.engineTemp_PB.TabStop = false;
            // 
            // environmentTemp_PB
            // 
            this.environmentTemp_PB.BackColor = System.Drawing.Color.Transparent;
            this.environmentTemp_PB.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_cloud;
            this.environmentTemp_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.environmentTemp_PB.Location = new System.Drawing.Point(0, 115);
            this.environmentTemp_PB.Name = "environmentTemp_PB";
            this.environmentTemp_PB.Size = new System.Drawing.Size(25, 25);
            this.environmentTemp_PB.TabIndex = 18;
            this.environmentTemp_PB.TabStop = false;
            // 
            // environmentTemp_SVPB
            // 
            this.environmentTemp_SVPB.BorderStyle = MissionPlanner.Controls.NewControls.BorderStyles.Classic;
            this.environmentTemp_SVPB.Color = System.Drawing.Color.LimeGreen;
            this.environmentTemp_SVPB.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceCurrentState, "press_temp2", true));
            this.environmentTemp_SVPB.Location = new System.Drawing.Point(0, 16);
            this.environmentTemp_SVPB.Maximum = 50D;
            this.environmentTemp_SVPB.Minimum = -50D;
            this.environmentTemp_SVPB.Name = "environmentTemp_SVPB";
            this.environmentTemp_SVPB.Size = new System.Drawing.Size(25, 99);
            this.environmentTemp_SVPB.Step = 11D;
            this.environmentTemp_SVPB.Style = MissionPlanner.Controls.NewControls.Styles.Classic;
            this.environmentTemp_SVPB.TabIndex = 5;
            this.environmentTemp_SVPB.Value = 0D;
            // 
            // engineTemp_SVPB
            // 
            this.engineTemp_SVPB.BorderStyle = MissionPlanner.Controls.NewControls.BorderStyles.Classic;
            this.engineTemp_SVPB.Color = System.Drawing.Color.LimeGreen;
            this.engineTemp_SVPB.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceCurrentState, "rpm2", true));
            this.engineTemp_SVPB.Location = new System.Drawing.Point(174, 16);
            this.engineTemp_SVPB.Maximum = 140D;
            this.engineTemp_SVPB.Minimum = -50D;
            this.engineTemp_SVPB.Name = "engineTemp_SVPB";
            this.engineTemp_SVPB.Size = new System.Drawing.Size(25, 99);
            this.engineTemp_SVPB.Step = 16D;
            this.engineTemp_SVPB.Style = MissionPlanner.Controls.NewControls.Styles.Classic;
            this.engineTemp_SVPB.TabIndex = 9;
            this.engineTemp_SVPB.Value = 10D;
            // 
            // airspeedDirectionControl2
            // 
            this.airspeedDirectionControl2.AutoScroll = true;
            this.airspeedDirectionControl2.BackColor = System.Drawing.Color.Transparent;
            this.airspeedDirectionControl2.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("airspeedDirectionControl2.BackgroundImage")));
            this.airspeedDirectionControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.airspeedDirectionControl2.Location = new System.Drawing.Point(615, 3);
            this.airspeedDirectionControl2.Name = "airspeedDirectionControl2";
            this.airspeedDirectionControl2.Size = new System.Drawing.Size(134, 134);
            this.airspeedDirectionControl2.TabIndex = 85;
            // 
            // StatusControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.airspeedDirectionControl2);
            this.Controls.Add(this.temperaturePanel);
            this.Controls.Add(this.speedPanel);
            this.Controls.Add(this.enginePanel);
            this.Controls.Add(this.addOrRemovePanel);
            this.Controls.Add(this.sensor_panel);
            this.Name = "StatusControlPanel";
            this.Size = new System.Drawing.Size(967, 140);
            this.hudPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.bindingSourceHud)).EndInit();
            this.sensorsContextMenuStrip.ResumeLayout(false);
            this.sensor_panel.ResumeLayout(false);
            this.sensor_panel.PerformLayout();
            this.addOrRemovePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.fuel_PB)).EndInit();
            this.enginePanel.ResumeLayout(false);
            this.enginePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.voltage_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.bindingSourceCurrentState)).EndInit();
            this.speedPanel.ResumeLayout(false);
            this.speedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.groundspeed_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.airspeed_PB)).EndInit();
            this.temperaturePanel.ResumeLayout(false);
            this.temperaturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.engineTemp_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.environmentTemp_PB)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel addOrRemovePanel;
        private System.Windows.Forms.Label airspeed_label;
        private System.Windows.Forms.PictureBox airspeed_PB;
        private MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar airspeed_SVPB;
        private System.Windows.Forms.Label altitude_label;
        private System.Windows.Forms.Label averageRpmICE_label;
        private System.Windows.Forms.BindingSource bindingSourceCurrentState;
        private System.Windows.Forms.BindingSource bindingSourceHud;
        private System.Windows.Forms.Panel enginePanel;
        private System.Windows.Forms.Label engineTemp_label;
        private System.Windows.Forms.PictureBox engineTemp_PB;
        private MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar engineTemp_SVPB;
        private System.Windows.Forms.Label environmentTemp_label;
        private System.Windows.Forms.PictureBox environmentTemp_PB;
        private MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar environmentTemp_SVPB;
        private System.Windows.Forms.Label flightMode_label;
        private System.Windows.Forms.Label fuel_label;
        private System.Windows.Forms.PictureBox fuel_PB;
        private System.Windows.Forms.Label groundSpeed_label;
        private System.Windows.Forms.PictureBox groundspeed_PB;
        private MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar groundSpeed_SVPB;
        private System.Windows.Forms.Button hideSensor_BUT;
        private MissionPlanner.Controls.HorizonHUD HorizonHUD;
        private System.Windows.Forms.Panel hudPanel;
        private System.Windows.Forms.Label rpmICE_label;
        private System.Windows.Forms.Panel sensor_panel;
        private System.Windows.Forms.ContextMenuStrip sensorsContextMenuStrip;
        private System.Windows.Forms.MenuStrip sensorsMenuStrip;
        private System.Windows.Forms.Button showSensor_BUT;
        private System.Windows.Forms.Panel speedPanel;
        private MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar splittedBar_fuel;
        private MissionPlanner.Controls.NewControls.VerticalSplittedProgressBar splittedBar_voltage;
        private System.Windows.Forms.Label targetAlt_label;
        private System.Windows.Forms.Panel temperaturePanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label verticalSpeed_label;
        private System.Windows.Forms.Label voltage_label;
        private System.Windows.Forms.PictureBox voltage_PB;
        private System.Windows.Forms.ToolStripMenuItem воздушнаяСкоростьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem высотаСНСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem магнитныйКурсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem напряжениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem путеваяСкоростьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem силаТокаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem следующаяТочкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem температураДвигателяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem топливоToolStripMenuItem;

        #endregion

        public AirspeedDirectionControl airspeedDirectionControl1;
        public AirspeedDirectionControl airspeedDirectionControl2;
    }
}