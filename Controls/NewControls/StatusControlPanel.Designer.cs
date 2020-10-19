﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MissionPlanner.Controls.NewControls;
using MissionPlanner.NewForms;
using MissionPlanner.Properties;

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
            this.components = new Container();
            this.rpmICE_label = new Label();
            this.flightMode_label = new Label();
            this.timer1 = new Timer(this.components);
            this.fuel_label = new Label();
            this.voltage_label = new Label();
            this.airspeed_label = new Label();
            this.engineTemp_label = new Label();
            this.altitude_label = new Label();
            this.targetAlt_label = new Label();
            this.verticalSpeed_label = new Label();
            this.groundSpeed_label = new Label();
            this.environmentTemp_label = new Label();
            this.averageRpmICE_label = new Label();
            this.hudPanel = new Panel();
            this.HorizonHUD = new HorizonHUD();
            this.bindingSourceHud = new BindingSource(this.components);
            this.bindingSourceCurrentState = new BindingSource(this.components);
            this.sensorsContextMenuStrip = new ContextMenuStrip(this.components);
            this.напряжениеToolStripMenuItem = new ToolStripMenuItem();
            this.температураДвигателяToolStripMenuItem = new ToolStripMenuItem();
            this.топливоToolStripMenuItem = new ToolStripMenuItem();
            this.воздушнаяСкоростьToolStripMenuItem = new ToolStripMenuItem();
            this.путеваяСкоростьToolStripMenuItem = new ToolStripMenuItem();
            this.высотаСНСToolStripMenuItem = new ToolStripMenuItem();
            this.магнитныйКурсToolStripMenuItem = new ToolStripMenuItem();
            this.следующаяТочкаToolStripMenuItem = new ToolStripMenuItem();
            this.силаТокаToolStripMenuItem = new ToolStripMenuItem();
            this.sensor_panel = new Panel();
            this.sensorsMenuStrip = new MenuStrip();
            this.windDirection = new WindDir();
            this.addOrRemovePanel = new Panel();
            this.hideSensor_BUT = new Button();
            this.showSensor_BUT = new Button();
            this.fuel_PB = new PictureBox();
            this.enginePanel = new Panel();
            this.voltage_PB = new PictureBox();
            this.splittedBar_voltage = new VerticalSplittedProgressBar();
            this.splittedBar_fuel = new VerticalSplittedProgressBar();
            this.speedPanel = new Panel();
            this.groundspeed_PB = new PictureBox();
            this.airspeed_PB = new PictureBox();
            this.airspeed_SVPB = new VerticalSplittedProgressBar();
            this.groundSpeed_SVPB = new VerticalSplittedProgressBar();
            this.temperaturePanel = new Panel();
            this.engineTemp_PB = new PictureBox();
            this.environmentTemp_PB = new PictureBox();
            this.environmentTemp_SVPB = new VerticalSplittedProgressBar();
            this.engineTemp_SVPB = new VerticalSplittedProgressBar();
            this.hudPanel.SuspendLayout();
            ((ISupportInitialize)(this.bindingSourceHud)).BeginInit();
            ((ISupportInitialize)(this.bindingSourceCurrentState)).BeginInit();
            this.sensorsContextMenuStrip.SuspendLayout();
            this.sensor_panel.SuspendLayout();
            this.addOrRemovePanel.SuspendLayout();
            ((ISupportInitialize)(this.fuel_PB)).BeginInit();
            this.enginePanel.SuspendLayout();
            ((ISupportInitialize)(this.voltage_PB)).BeginInit();
            this.speedPanel.SuspendLayout();
            ((ISupportInitialize)(this.groundspeed_PB)).BeginInit();
            ((ISupportInitialize)(this.airspeed_PB)).BeginInit();
            this.temperaturePanel.SuspendLayout();
            ((ISupportInitialize)(this.engineTemp_PB)).BeginInit();
            ((ISupportInitialize)(this.environmentTemp_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // rpmICE_label
            // 
            this.rpmICE_label.AutoSize = true;
            this.rpmICE_label.Location = new Point(80, 0);
            this.rpmICE_label.Name = "rpmICE_label";
            this.rpmICE_label.Size = new Size(41, 13);
            this.rpmICE_label.TabIndex = 3;
            this.rpmICE_label.Text = "rpmICE";
            // 
            // flightMode_label
            // 
            this.flightMode_label.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
                                                             | AnchorStyles.Left) 
                                                            | AnchorStyles.Right)));
            this.flightMode_label.AutoSize = true;
            this.flightMode_label.Font = new Font("Microsoft Sans Serif", 14.25F);
            this.flightMode_label.ForeColor = Color.White;
            this.flightMode_label.Location = new Point(23, 104);
            this.flightMode_label.MinimumSize = new Size(150, 24);
            this.flightMode_label.Name = "flightMode_label";
            this.flightMode_label.Size = new Size(150, 24);
            this.flightMode_label.TabIndex = 4;
            this.flightMode_label.Text = "flightMode";
            this.flightMode_label.TextAlign = ContentAlignment.BottomCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            // 
            // fuel_label
            // 
            this.fuel_label.AutoSize = true;
            this.fuel_label.Location = new Point(0, 0);
            this.fuel_label.Name = "fuel_label";
            this.fuel_label.Size = new Size(24, 13);
            this.fuel_label.TabIndex = 5;
            this.fuel_label.Text = "fuel";
            // 
            // voltage_label
            // 
            this.voltage_label.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.voltage_label.AutoSize = true;
            this.voltage_label.Location = new Point(157, 0);
            this.voltage_label.MaximumSize = new Size(42, 13);
            this.voltage_label.MinimumSize = new Size(42, 13);
            this.voltage_label.Name = "voltage_label";
            this.voltage_label.Size = new Size(42, 13);
            this.voltage_label.TabIndex = 6;
            this.voltage_label.Text = "voltage";
            this.voltage_label.TextAlign = ContentAlignment.TopRight;
            // 
            // airspeed_label
            // 
            this.airspeed_label.AutoSize = true;
            this.airspeed_label.Location = new Point(0, 0);
            this.airspeed_label.Name = "airspeed_label";
            this.airspeed_label.Size = new Size(47, 13);
            this.airspeed_label.TabIndex = 7;
            this.airspeed_label.Text = "airspeed";
            // 
            // engineTemp_label
            // 
            this.engineTemp_label.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.engineTemp_label.AutoSize = true;
            this.engineTemp_label.Location = new Point(133, 0);
            this.engineTemp_label.MaximumSize = new Size(66, 13);
            this.engineTemp_label.MinimumSize = new Size(66, 13);
            this.engineTemp_label.Name = "engineTemp_label";
            this.engineTemp_label.Size = new Size(66, 13);
            this.engineTemp_label.TabIndex = 10;
            this.engineTemp_label.Text = "engineTemp";
            this.engineTemp_label.TextAlign = ContentAlignment.TopRight;
            // 
            // altitude_label
            // 
            this.altitude_label.AutoSize = true;
            this.altitude_label.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            this.altitude_label.ForeColor = Color.White;
            this.altitude_label.Location = new Point(32, 27);
            this.altitude_label.MinimumSize = new Size(54, 37);
            this.altitude_label.Name = "altitude_label";
            this.altitude_label.Size = new Size(54, 37);
            this.altitude_label.TabIndex = 11;
            this.altitude_label.Text = "alt";
            this.altitude_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // targetAlt_label
            // 
            this.targetAlt_label.AutoSize = true;
            this.targetAlt_label.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.targetAlt_label.ForeColor = Color.White;
            this.targetAlt_label.Location = new Point(98, 70);
            this.targetAlt_label.Name = "targetAlt_label";
            this.targetAlt_label.Size = new Size(75, 25);
            this.targetAlt_label.TabIndex = 12;
            this.targetAlt_label.Text = "trgtAlt";
            // 
            // verticalSpeed_label
            // 
            this.verticalSpeed_label.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
                                                                | AnchorStyles.Left) 
                                                               | AnchorStyles.Right)));
            this.verticalSpeed_label.AutoSize = true;
            this.verticalSpeed_label.Font = new Font("Microsoft Sans Serif", 14.25F);
            this.verticalSpeed_label.ForeColor = Color.White;
            this.verticalSpeed_label.Location = new Point(35, 104);
            this.verticalSpeed_label.MinimumSize = new Size(124, 24);
            this.verticalSpeed_label.Name = "verticalSpeed_label";
            this.verticalSpeed_label.Size = new Size(124, 24);
            this.verticalSpeed_label.TabIndex = 13;
            this.verticalSpeed_label.Text = "verticalSpeed";
            this.verticalSpeed_label.TextAlign = ContentAlignment.BottomCenter;
            // 
            // groundSpeed_label
            // 
            this.groundSpeed_label.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.groundSpeed_label.AutoSize = true;
            this.groundSpeed_label.Location = new Point(128, 0);
            this.groundSpeed_label.MaximumSize = new Size(71, 13);
            this.groundSpeed_label.MinimumSize = new Size(71, 13);
            this.groundSpeed_label.Name = "groundSpeed_label";
            this.groundSpeed_label.Size = new Size(71, 13);
            this.groundSpeed_label.TabIndex = 15;
            this.groundSpeed_label.Text = "groundSpeed";
            this.groundSpeed_label.TextAlign = ContentAlignment.TopRight;
            // 
            // environmentTemp_label
            // 
            this.environmentTemp_label.AutoSize = true;
            this.environmentTemp_label.Location = new Point(0, 0);
            this.environmentTemp_label.Name = "environmentTemp_label";
            this.environmentTemp_label.Size = new Size(92, 13);
            this.environmentTemp_label.TabIndex = 17;
            this.environmentTemp_label.Text = "environmentTemp";
            // 
            // averageRpmICE_label
            // 
            this.averageRpmICE_label.AutoSize = true;
            this.averageRpmICE_label.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            this.averageRpmICE_label.ForeColor = Color.White;
            this.averageRpmICE_label.Location = new Point(23, 48);
            this.averageRpmICE_label.MinimumSize = new Size(152, 37);
            this.averageRpmICE_label.Name = "averageRpmICE_label";
            this.averageRpmICE_label.Size = new Size(152, 37);
            this.averageRpmICE_label.TabIndex = 18;
            this.averageRpmICE_label.Text = "averRpm";
            this.averageRpmICE_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hudPanel
            // 
            this.hudPanel.Controls.Add(this.HorizonHUD);
            this.hudPanel.Location = new Point(23, 16);
            this.hudPanel.Name = "hudPanel";
            this.hudPanel.Size = new Size(150, 100);
            this.hudPanel.TabIndex = 19;
            // 
            // HorizonHUD
            // 
            this.HorizonHUD.airspeed = 0F;
            this.HorizonHUD.alt = 0F;
            this.HorizonHUD.altunit = null;
            this.HorizonHUD.AOA = 0F;
            this.HorizonHUD.BackColor = Color.Black;
            this.HorizonHUD.batterylevel = 0F;
            this.HorizonHUD.batteryremaining = 0F;
            this.HorizonHUD.bgimage = null;
            this.HorizonHUD.connected = false;
            this.HorizonHUD.critAOA = 25F;
            this.HorizonHUD.critSSA = 30F;
            this.HorizonHUD.current = 0F;
            this.HorizonHUD.DataBindings.Add(new Binding("airspeed", this.bindingSourceHud, "airspeed", true));
            this.HorizonHUD.DataBindings.Add(new Binding("alt", this.bindingSourceHud, "alt", true));
            this.HorizonHUD.DataBindings.Add(new Binding("batterylevel", this.bindingSourceHud, "battery_voltage", true));
            this.HorizonHUD.DataBindings.Add(new Binding("batteryremaining", this.bindingSourceHud, "battery_remaining", true));
            this.HorizonHUD.DataBindings.Add(new Binding("connected", this.bindingSourceHud, "connected", true));
            this.HorizonHUD.DataBindings.Add(new Binding("current", this.bindingSourceHud, "current", true));
            this.HorizonHUD.DataBindings.Add(new Binding("datetime", this.bindingSourceHud, "datetime", true));
            this.HorizonHUD.DataBindings.Add(new Binding("disttowp", this.bindingSourceHud, "wp_dist", true));
            this.HorizonHUD.DataBindings.Add(new Binding("ekfstatus", this.bindingSourceHud, "ekfstatus", true));
            this.HorizonHUD.DataBindings.Add(new Binding("failsafe", this.bindingSourceHud, "failsafe", true));
            this.HorizonHUD.DataBindings.Add(new Binding("gpsfix", this.bindingSourceHud, "gpsstatus", true));
            this.HorizonHUD.DataBindings.Add(new Binding("gpsfix2", this.bindingSourceHud, "gpsstatus2", true));
            this.HorizonHUD.DataBindings.Add(new Binding("gpshdop", this.bindingSourceHud, "gpshdop", true));
            this.HorizonHUD.DataBindings.Add(new Binding("gpshdop2", this.bindingSourceHud, "gpshdop2", true));
            this.HorizonHUD.DataBindings.Add(new Binding("groundalt", this.bindingSourceHud, "HomeAlt", true));
            this.HorizonHUD.DataBindings.Add(new Binding("groundcourse", this.bindingSourceHud, "groundcourse", true));
            this.HorizonHUD.DataBindings.Add(new Binding("groundspeed", this.bindingSourceHud, "groundspeed", true));
            this.HorizonHUD.DataBindings.Add(new Binding("heading", this.bindingSourceHud, "yaw", true));
            this.HorizonHUD.DataBindings.Add(new Binding("linkqualitygcs", this.bindingSourceHud, "linkqualitygcs", true));
            this.HorizonHUD.DataBindings.Add(new Binding("message", this.bindingSourceHud, "messageHigh", true));
            this.HorizonHUD.DataBindings.Add(new Binding("mode", this.bindingSourceHud, "mode", true));
            this.HorizonHUD.DataBindings.Add(new Binding("navpitch", this.bindingSourceHud, "nav_pitch", true));
            this.HorizonHUD.DataBindings.Add(new Binding("navroll", this.bindingSourceHud, "nav_roll", true));
            this.HorizonHUD.DataBindings.Add(new Binding("pitch", this.bindingSourceHud, "pitch", true));
            this.HorizonHUD.DataBindings.Add(new Binding("roll", this.bindingSourceHud, "roll", true));
            this.HorizonHUD.DataBindings.Add(new Binding("status", this.bindingSourceHud, "armed", true));
            this.HorizonHUD.DataBindings.Add(new Binding("targetalt", this.bindingSourceHud, "targetalt", true));
            this.HorizonHUD.DataBindings.Add(new Binding("targetheading", this.bindingSourceHud, "nav_bearing", true));
            this.HorizonHUD.DataBindings.Add(new Binding("targetspeed", this.bindingSourceHud, "targetairspeed", true));
            this.HorizonHUD.DataBindings.Add(new Binding("turnrate", this.bindingSourceHud, "turnrate", true));
            this.HorizonHUD.DataBindings.Add(new Binding("verticalspeed", this.bindingSourceHud, "verticalspeed", true));
            this.HorizonHUD.DataBindings.Add(new Binding("vibex", this.bindingSourceHud, "vibex", true));
            this.HorizonHUD.DataBindings.Add(new Binding("vibey", this.bindingSourceHud, "vibey", true));
            this.HorizonHUD.DataBindings.Add(new Binding("vibez", this.bindingSourceHud, "vibez", true));
            this.HorizonHUD.DataBindings.Add(new Binding("wpno", this.bindingSourceHud, "wpno", true));
            this.HorizonHUD.DataBindings.Add(new Binding("xtrack_error", this.bindingSourceHud, "xtrack_error", true));
            this.HorizonHUD.DataBindings.Add(new Binding("AOA", this.bindingSourceHud, "AOA", true));
            this.HorizonHUD.DataBindings.Add(new Binding("SSA", this.bindingSourceHud, "SSA", true));
            this.HorizonHUD.DataBindings.Add(new Binding("critAOA", this.bindingSourceHud, "crit_AOA", true));
            this.HorizonHUD.datetime = new DateTime(((long)(0)));
            this.HorizonHUD.displayAOASSA = false;
            this.HorizonHUD.disttowp = 0F;
            this.HorizonHUD.distunit = null;
            this.HorizonHUD.Dock = DockStyle.Fill;
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
            this.HorizonHUD.hudcolor = Color.LightGray;
            this.HorizonHUD.linkqualitygcs = 0F;
            this.HorizonHUD.Location = new Point(0, 0);
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
            this.HorizonHUD.Size = new Size(150, 100);
            this.HorizonHUD.skyColor1 = Color.Blue;
            this.HorizonHUD.skyColor2 = Color.LightBlue;
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
            this.bindingSourceHud.DataSource = typeof(CurrentState);
            // 
            // bindingSourceCurrentState
            // 
            this.bindingSourceCurrentState.DataSource = typeof(CurrentState);
            // 
            // sensorsContextMenuStrip
            // 
            this.sensorsContextMenuStrip.Items.AddRange(new ToolStripItem[] {
            this.напряжениеToolStripMenuItem,
            this.температураДвигателяToolStripMenuItem,
            this.топливоToolStripMenuItem,
            this.воздушнаяСкоростьToolStripMenuItem,
            this.путеваяСкоростьToolStripMenuItem,
            this.высотаСНСToolStripMenuItem,
            this.магнитныйКурсToolStripMenuItem,
            this.следующаяТочкаToolStripMenuItem,
            this.силаТокаToolStripMenuItem});
            this.sensorsContextMenuStrip.Name = "contextMenuStrip1";
            this.sensorsContextMenuStrip.Size = new Size(203, 202);
            // 
            // напряжениеToolStripMenuItem
            // 
            this.напряжениеToolStripMenuItem.Name = "напряжениеToolStripMenuItem";
            this.напряжениеToolStripMenuItem.Size = new Size(202, 22);
            this.напряжениеToolStripMenuItem.Text = "Напряжение";
            this.напряжениеToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // температураДвигателяToolStripMenuItem
            // 
            this.температураДвигателяToolStripMenuItem.Name = "температураДвигателяToolStripMenuItem";
            this.температураДвигателяToolStripMenuItem.Size = new Size(202, 22);
            this.температураДвигателяToolStripMenuItem.Text = "Температура двигателя";
            this.температураДвигателяToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // топливоToolStripMenuItem
            // 
            this.топливоToolStripMenuItem.Name = "топливоToolStripMenuItem";
            this.топливоToolStripMenuItem.Size = new Size(202, 22);
            this.топливоToolStripMenuItem.Text = "Топливо";
            this.топливоToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // воздушнаяСкоростьToolStripMenuItem
            // 
            this.воздушнаяСкоростьToolStripMenuItem.Name = "воздушнаяСкоростьToolStripMenuItem";
            this.воздушнаяСкоростьToolStripMenuItem.Size = new Size(202, 22);
            this.воздушнаяСкоростьToolStripMenuItem.Text = "Воздушная скорость";
            this.воздушнаяСкоростьToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // путеваяСкоростьToolStripMenuItem
            // 
            this.путеваяСкоростьToolStripMenuItem.Name = "путеваяСкоростьToolStripMenuItem";
            this.путеваяСкоростьToolStripMenuItem.Size = new Size(202, 22);
            this.путеваяСкоростьToolStripMenuItem.Text = "Путевая скорость";
            this.путеваяСкоростьToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // высотаСНСToolStripMenuItem
            // 
            this.высотаСНСToolStripMenuItem.Name = "высотаСНСToolStripMenuItem";
            this.высотаСНСToolStripMenuItem.Size = new Size(202, 22);
            this.высотаСНСToolStripMenuItem.Text = "Высота (СНС)";
            this.высотаСНСToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // магнитныйКурсToolStripMenuItem
            // 
            this.магнитныйКурсToolStripMenuItem.Name = "магнитныйКурсToolStripMenuItem";
            this.магнитныйКурсToolStripMenuItem.Size = new Size(202, 22);
            this.магнитныйКурсToolStripMenuItem.Text = "Магнитный курс";
            this.магнитныйКурсToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // следующаяТочкаToolStripMenuItem
            // 
            this.следующаяТочкаToolStripMenuItem.Name = "следующаяТочкаToolStripMenuItem";
            this.следующаяТочкаToolStripMenuItem.Size = new Size(202, 22);
            this.следующаяТочкаToolStripMenuItem.Text = "Следующая точка";
            this.следующаяТочкаToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // силаТокаToolStripMenuItem
            // 
            this.силаТокаToolStripMenuItem.Name = "силаТокаToolStripMenuItem";
            this.силаТокаToolStripMenuItem.Size = new Size(202, 22);
            this.силаТокаToolStripMenuItem.Text = "Сила тока";
            this.силаТокаToolStripMenuItem.Click += new EventHandler(this.AdditionalSensorToolStripMenuItemClick);
            // 
            // sensor_panel
            // 
            this.sensor_panel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
                                                         | AnchorStyles.Left) 
                                                        | AnchorStyles.Right)));
            this.sensor_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.sensor_panel.Controls.Add(this.sensorsMenuStrip);
            this.sensor_panel.Location = new Point(760, 0);
            this.sensor_panel.MinimumSize = new Size(130, 123);
            this.sensor_panel.Name = "sensor_panel";
            this.sensor_panel.Size = new Size(161, 140);
            this.sensor_panel.TabIndex = 77;
            // 
            // sensorsMenuStrip
            // 
            this.sensorsMenuStrip.BackgroundImage = Resources.nonefon1;
            this.sensorsMenuStrip.Dock = DockStyle.Fill;
            this.sensorsMenuStrip.Location = new Point(0, 0);
            this.sensorsMenuStrip.Name = "sensorsMenuStrip";
            this.sensorsMenuStrip.Size = new Size(161, 140);
            this.sensorsMenuStrip.TabIndex = 0;
            this.sensorsMenuStrip.Text = "menuStrip1";
            // 
            // windDirection
            // 
            this.windDirection.BackColor = Color.Transparent;
            this.windDirection.DataBindings.Add(new Binding("Direction", this.bindingSourceCurrentState, "wind_dir", true));
            this.windDirection.DataBindings.Add(new Binding("Speed", this.bindingSourceCurrentState, "wind_vel", true));
            this.windDirection.Direction = 360D;
            this.windDirection.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.windDirection.Location = new Point(615, 0);
            this.windDirection.Name = "windDirection";
            this.windDirection.Size = new Size(140, 140);
            this.windDirection.Speed = 0D;
            this.windDirection.TabIndex = 76;
            // 
            // addOrRemovePanel
            // 
            this.addOrRemovePanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
                                                            | AnchorStyles.Right)));
            this.addOrRemovePanel.Controls.Add(this.hideSensor_BUT);
            this.addOrRemovePanel.Controls.Add(this.showSensor_BUT);
            this.addOrRemovePanel.Location = new Point(927, 0);
            this.addOrRemovePanel.Name = "addOrRemovePanel";
            this.addOrRemovePanel.Size = new Size(43, 140);
            this.addOrRemovePanel.TabIndex = 80;
            // 
            // hideSensor_BUT
            // 
            this.hideSensor_BUT.FlatStyle = FlatStyle.Flat;
            this.hideSensor_BUT.Font = new Font("MS UI Gothic", 9F, FontStyle.Bold);
            this.hideSensor_BUT.ForeColor = Color.White;
            this.hideSensor_BUT.Location = new Point(3, 70);
            this.hideSensor_BUT.Name = "hideSensor_BUT";
            this.hideSensor_BUT.Size = new Size(37, 23);
            this.hideSensor_BUT.TabIndex = 1;
            this.hideSensor_BUT.Text = "<";
            this.hideSensor_BUT.TextAlign = ContentAlignment.BottomCenter;
            this.hideSensor_BUT.UseVisualStyleBackColor = true;
            this.hideSensor_BUT.Click += new EventHandler(this.hideSensor_BUT_Click);
            // 
            // showSensor_BUT
            // 
            this.showSensor_BUT.FlatStyle = FlatStyle.Flat;
            this.showSensor_BUT.Font = new Font("MS UI Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.showSensor_BUT.ForeColor = Color.White;
            this.showSensor_BUT.Location = new Point(3, 27);
            this.showSensor_BUT.Name = "showSensor_BUT";
            this.showSensor_BUT.Size = new Size(37, 23);
            this.showSensor_BUT.TabIndex = 0;
            this.showSensor_BUT.Text = " >";
            this.showSensor_BUT.TextAlign = ContentAlignment.BottomCenter;
            this.showSensor_BUT.UseVisualStyleBackColor = false;
            this.showSensor_BUT.Click += new EventHandler(this.showSensor_BUT_Click);
            // 
            // fuel_PB
            // 
            this.fuel_PB.BackColor = Color.Transparent;
            this.fuel_PB.BackgroundImage = Resources.icons8_oil;
            this.fuel_PB.BackgroundImageLayout = ImageLayout.Zoom;
            this.fuel_PB.Location = new Point(0, 120);
            this.fuel_PB.Name = "fuel_PB";
            this.fuel_PB.Size = new Size(17, 17);
            this.fuel_PB.TabIndex = 81;
            this.fuel_PB.TabStop = false;
            // 
            // enginePanel
            // 
            this.enginePanel.BackColor = Color.Transparent;
            this.enginePanel.Controls.Add(this.voltage_PB);
            this.enginePanel.Controls.Add(this.splittedBar_voltage);
            this.enginePanel.Controls.Add(this.splittedBar_fuel);
            this.enginePanel.Controls.Add(this.fuel_PB);
            this.enginePanel.Controls.Add(this.rpmICE_label);
            this.enginePanel.Controls.Add(this.flightMode_label);
            this.enginePanel.Controls.Add(this.fuel_label);
            this.enginePanel.Controls.Add(this.voltage_label);
            this.enginePanel.Controls.Add(this.averageRpmICE_label);
            this.enginePanel.Location = new Point(0, 0);
            this.enginePanel.Name = "enginePanel";
            this.enginePanel.Size = new Size(199, 140);
            this.enginePanel.TabIndex = 82;
            this.enginePanel.Click += new EventHandler(this.enginePanel_Click);
            // 
            // voltage_PB
            // 
            this.voltage_PB.BackgroundImage = Resources.icons8_lightning;
            this.voltage_PB.BackgroundImageLayout = ImageLayout.Zoom;
            this.voltage_PB.Location = new Point(179, 120);
            this.voltage_PB.Name = "voltage_PB";
            this.voltage_PB.Size = new Size(17, 17);
            this.voltage_PB.TabIndex = 82;
            this.voltage_PB.TabStop = false;
            // 
            // splittedBar_voltage
            // 
            this.splittedBar_voltage.BorderStyle = BorderStyles.Classic;
            this.splittedBar_voltage.Color = Color.LimeGreen;
            this.splittedBar_voltage.DataBindings.Add(new Binding("Value", this.bindingSourceCurrentState, "battery_voltage", true));
            this.splittedBar_voltage.Location = new Point(179, 16);
            this.splittedBar_voltage.Maximum = 12.6D;
            this.splittedBar_voltage.Minimum = 9.9D;
            this.splittedBar_voltage.Name = "splittedBar_voltage";
            this.splittedBar_voltage.Size = new Size(17, 100);
            this.splittedBar_voltage.Step = 1.4D;
            this.splittedBar_voltage.Style = Styles.Classic;
            this.splittedBar_voltage.TabIndex = 2;
            this.splittedBar_voltage.Value = 12D;
            // 
            // splittedBar_fuel
            // 
            this.splittedBar_fuel.BorderStyle = BorderStyles.Classic;
            this.splittedBar_fuel.Color = Color.LimeGreen;
            this.splittedBar_fuel.DataBindings.Add(new Binding("Value", this.bindingSourceCurrentState, "battery_voltage2", true));
            this.splittedBar_fuel.Location = new Point(0, 16);
            this.splittedBar_fuel.Maximum = 100D;
            this.splittedBar_fuel.Minimum = 0D;
            this.splittedBar_fuel.Name = "splittedBar_fuel";
            this.splittedBar_fuel.Size = new Size(17, 100);
            this.splittedBar_fuel.Step = 10D;
            this.splittedBar_fuel.Style = Styles.Classic;
            this.splittedBar_fuel.TabIndex = 1;
            this.splittedBar_fuel.Value = 100D;
            // 
            // speedPanel
            // 
            this.speedPanel.BackColor = Color.Transparent;
            this.speedPanel.Controls.Add(this.groundspeed_PB);
            this.speedPanel.Controls.Add(this.airspeed_PB);
            this.speedPanel.Controls.Add(this.airspeed_SVPB);
            this.speedPanel.Controls.Add(this.airspeed_label);
            this.speedPanel.Controls.Add(this.altitude_label);
            this.speedPanel.Controls.Add(this.verticalSpeed_label);
            this.speedPanel.Controls.Add(this.groundSpeed_SVPB);
            this.speedPanel.Controls.Add(this.targetAlt_label);
            this.speedPanel.Controls.Add(this.groundSpeed_label);
            this.speedPanel.Location = new Point(205, 0);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Size = new Size(199, 140);
            this.speedPanel.TabIndex = 83;
            this.speedPanel.Click += new EventHandler(this.speedPanel_Click);
            // 
            // groundspeed_PB
            // 
            this.groundspeed_PB.BackColor = Color.Transparent;
            this.groundspeed_PB.BackgroundImage = Resources.icons8_speed_p;
            this.groundspeed_PB.BackgroundImageLayout = ImageLayout.Zoom;
            this.groundspeed_PB.Location = new Point(179, 120);
            this.groundspeed_PB.Name = "groundspeed_PB";
            this.groundspeed_PB.Size = new Size(17, 17);
            this.groundspeed_PB.TabIndex = 17;
            this.groundspeed_PB.TabStop = false;
            // 
            // airspeed_PB
            // 
            this.airspeed_PB.BackColor = Color.Transparent;
            this.airspeed_PB.BackgroundImage = Resources.icons8_speedometer;
            this.airspeed_PB.BackgroundImageLayout = ImageLayout.Zoom;
            this.airspeed_PB.Location = new Point(0, 120);
            this.airspeed_PB.Name = "airspeed_PB";
            this.airspeed_PB.Size = new Size(17, 17);
            this.airspeed_PB.TabIndex = 16;
            this.airspeed_PB.TabStop = false;
            // 
            // airspeed_SVPB
            // 
            this.airspeed_SVPB.BorderStyle = BorderStyles.Classic;
            this.airspeed_SVPB.Color = Color.LimeGreen;
            this.airspeed_SVPB.DataBindings.Add(new Binding("Value", this.bindingSourceCurrentState, "airspeed", true));
            this.airspeed_SVPB.Location = new Point(0, 16);
            this.airspeed_SVPB.Maximum = 40D;
            this.airspeed_SVPB.Minimum = 0D;
            this.airspeed_SVPB.Name = "airspeed_SVPB";
            this.airspeed_SVPB.Size = new Size(17, 100);
            this.airspeed_SVPB.Step = 2D;
            this.airspeed_SVPB.Style = Styles.Classic;
            this.airspeed_SVPB.TabIndex = 8;
            this.airspeed_SVPB.Value = 12D;
            // 
            // groundSpeed_SVPB
            // 
            this.groundSpeed_SVPB.BorderStyle = BorderStyles.Classic;
            this.groundSpeed_SVPB.Color = Color.LimeGreen;
            this.groundSpeed_SVPB.DataBindings.Add(new Binding("Value", this.bindingSourceCurrentState, "groundspeed", true));
            this.groundSpeed_SVPB.Location = new Point(179, 16);
            this.groundSpeed_SVPB.Maximum = 40D;
            this.groundSpeed_SVPB.Minimum = 0D;
            this.groundSpeed_SVPB.Name = "groundSpeed_SVPB";
            this.groundSpeed_SVPB.Size = new Size(17, 100);
            this.groundSpeed_SVPB.Step = 2D;
            this.groundSpeed_SVPB.Style = Styles.Classic;
            this.groundSpeed_SVPB.TabIndex = 14;
            this.groundSpeed_SVPB.Value = 10D;
            // 
            // temperaturePanel
            // 
            this.temperaturePanel.BackColor = Color.Transparent;
            this.temperaturePanel.Controls.Add(this.engineTemp_PB);
            this.temperaturePanel.Controls.Add(this.environmentTemp_PB);
            this.temperaturePanel.Controls.Add(this.environmentTemp_SVPB);
            this.temperaturePanel.Controls.Add(this.environmentTemp_label);
            this.temperaturePanel.Controls.Add(this.hudPanel);
            this.temperaturePanel.Controls.Add(this.engineTemp_SVPB);
            this.temperaturePanel.Controls.Add(this.engineTemp_label);
            this.temperaturePanel.Location = new Point(410, 0);
            this.temperaturePanel.Name = "temperaturePanel";
            this.temperaturePanel.Size = new Size(199, 140);
            this.temperaturePanel.TabIndex = 84;
            // 
            // engineTemp_PB
            // 
            this.engineTemp_PB.BackColor = Color.Transparent;
            this.engineTemp_PB.BackgroundImage = Resources.icons8_engine;
            this.engineTemp_PB.BackgroundImageLayout = ImageLayout.Zoom;
            this.engineTemp_PB.Location = new Point(179, 120);
            this.engineTemp_PB.Name = "engineTemp_PB";
            this.engineTemp_PB.Size = new Size(17, 17);
            this.engineTemp_PB.TabIndex = 20;
            this.engineTemp_PB.TabStop = false;
            // 
            // environmentTemp_PB
            // 
            this.environmentTemp_PB.BackColor = Color.Transparent;
            this.environmentTemp_PB.BackgroundImage = Resources.icons8_cloud;
            this.environmentTemp_PB.BackgroundImageLayout = ImageLayout.Zoom;
            this.environmentTemp_PB.Location = new Point(0, 120);
            this.environmentTemp_PB.Name = "environmentTemp_PB";
            this.environmentTemp_PB.Size = new Size(17, 17);
            this.environmentTemp_PB.TabIndex = 18;
            this.environmentTemp_PB.TabStop = false;
            // 
            // environmentTemp_SVPB
            // 
            this.environmentTemp_SVPB.BorderStyle = BorderStyles.Classic;
            this.environmentTemp_SVPB.Color = Color.LimeGreen;
            this.environmentTemp_SVPB.DataBindings.Add(new Binding("Value", this.bindingSourceCurrentState, "press_temp2", true));
            this.environmentTemp_SVPB.Location = new Point(0, 16);
            this.environmentTemp_SVPB.Maximum = 50D;
            this.environmentTemp_SVPB.Minimum = -50D;
            this.environmentTemp_SVPB.Name = "environmentTemp_SVPB";
            this.environmentTemp_SVPB.Size = new Size(17, 100);
            this.environmentTemp_SVPB.Step = 5D;
            this.environmentTemp_SVPB.Style = Styles.Classic;
            this.environmentTemp_SVPB.TabIndex = 5;
            this.environmentTemp_SVPB.Value = 10D;
            // 
            // engineTemp_SVPB
            // 
            this.engineTemp_SVPB.BorderStyle = BorderStyles.Classic;
            this.engineTemp_SVPB.Color = Color.LimeGreen;
            this.engineTemp_SVPB.DataBindings.Add(new Binding("Value", this.bindingSourceCurrentState, "rpm2", true));
            this.engineTemp_SVPB.Location = new Point(179, 16);
            this.engineTemp_SVPB.Maximum = 130D;
            this.engineTemp_SVPB.Minimum = -50D;
            this.engineTemp_SVPB.Name = "engineTemp_SVPB";
            this.engineTemp_SVPB.Size = new Size(17, 100);
            this.engineTemp_SVPB.Step = 10D;
            this.engineTemp_SVPB.Style = Styles.Classic;
            this.engineTemp_SVPB.TabIndex = 9;
            this.engineTemp_SVPB.Value = 10D;
            // 
            // StatusControlPanel
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.temperaturePanel);
            this.Controls.Add(this.speedPanel);
            this.Controls.Add(this.enginePanel);
            this.Controls.Add(this.addOrRemovePanel);
            this.Controls.Add(this.sensor_panel);
            this.Controls.Add(this.windDirection);
            this.Name = "StatusControlPanel";
            this.Size = new Size(967, 140);
            this.hudPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.bindingSourceHud)).EndInit();
            ((ISupportInitialize)(this.bindingSourceCurrentState)).EndInit();
            this.sensorsContextMenuStrip.ResumeLayout(false);
            this.sensor_panel.ResumeLayout(false);
            this.sensor_panel.PerformLayout();
            this.addOrRemovePanel.ResumeLayout(false);
            ((ISupportInitialize)(this.fuel_PB)).EndInit();
            this.enginePanel.ResumeLayout(false);
            this.enginePanel.PerformLayout();
            ((ISupportInitialize)(this.voltage_PB)).EndInit();
            this.speedPanel.ResumeLayout(false);
            this.speedPanel.PerformLayout();
            ((ISupportInitialize)(this.groundspeed_PB)).EndInit();
            ((ISupportInitialize)(this.airspeed_PB)).EndInit();
            this.temperaturePanel.ResumeLayout(false);
            this.temperaturePanel.PerformLayout();
            ((ISupportInitialize)(this.engineTemp_PB)).EndInit();
            ((ISupportInitialize)(this.environmentTemp_PB)).EndInit();
            this.ResumeLayout(false);

        }

        private Label averageRpmICE_label;
        private Panel hudPanel;

        #endregion
        private VerticalSplittedProgressBar splittedBar_fuel;
        private VerticalSplittedProgressBar splittedBar_voltage;
        private Label rpmICE_label;
        private Label flightMode_label;
        private BindingSource bindingSourceCurrentState;
        private Timer timer1;
        private Label fuel_label;
        private Label voltage_label;
        private Label airspeed_label;
        private VerticalSplittedProgressBar airspeed_SVPB;
        private VerticalSplittedProgressBar engineTemp_SVPB;
        private Label engineTemp_label;
        private Label altitude_label;
        private Label targetAlt_label;
        private Label verticalSpeed_label;
        private VerticalSplittedProgressBar groundSpeed_SVPB;
        private Label groundSpeed_label;
        private VerticalSplittedProgressBar environmentTemp_SVPB;
        private Label environmentTemp_label;
        private BindingSource bindingSourceHud;
        public WindDir windDirection;
        private ContextMenuStrip sensorsContextMenuStrip;
        private ToolStripMenuItem напряжениеToolStripMenuItem;
        private ToolStripMenuItem температураДвигателяToolStripMenuItem;
        private ToolStripMenuItem топливоToolStripMenuItem;
        private ToolStripMenuItem воздушнаяСкоростьToolStripMenuItem;
        private ToolStripMenuItem путеваяСкоростьToolStripMenuItem;
        private ToolStripMenuItem высотаСНСToolStripMenuItem;
        private ToolStripMenuItem магнитныйКурсToolStripMenuItem;
        private ToolStripMenuItem следующаяТочкаToolStripMenuItem;
        private ToolStripMenuItem силаТокаToolStripMenuItem;
        private Panel sensor_panel;
        private MenuStrip sensorsMenuStrip;
        private Panel addOrRemovePanel;
        private Button hideSensor_BUT;
        private Button showSensor_BUT;
        private PictureBox fuel_PB;
        private Panel enginePanel;
        private PictureBox voltage_PB;
        private Panel speedPanel;
        private PictureBox airspeed_PB;
        private PictureBox groundspeed_PB;
        private HorizonHUD HorizonHUD;
        private Panel temperaturePanel;
        private PictureBox environmentTemp_PB;
        private PictureBox engineTemp_PB;
    }
}