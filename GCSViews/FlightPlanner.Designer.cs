﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using MissionPlanner.Controls;
using MissionPlanner.Controls.NewControls;

namespace MissionPlanner.GCSViews
{
    partial class FlightPlanner
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

            if (currentMarker != null) currentMarker.Dispose();
            if (DrawingPolygon != null) DrawingPolygon.Dispose();
            if (kmlpolygonsoverlay != null) kmlpolygonsoverlay.Dispose();
            if (wppolygon != null) wppolygon.Dispose();
            if (top != null) top.Dispose();
            if (geofencepolygon != null) geofencepolygon.Dispose();
            if (geofenceoverlay != null) geofenceoverlay.Dispose();
            if (DrawnPolygonsOverlay != null) DrawnPolygonsOverlay.Dispose();
            if (center != null) center.Dispose(); 

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightPlanner));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CHK_verifyheight = new System.Windows.Forms.CheckBox();
            this.TXT_WPRad = new System.Windows.Forms.TextBox();
            this.TXT_DefaultAlt = new System.Windows.Forms.TextBox();
            this.LBL_WPRad = new System.Windows.Forms.Label();
            this.LBL_defalutalt = new System.Windows.Forms.Label();
            this.TXT_loiterrad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.but_writewpfast = new MissionPlanner.Controls.MyButton();
            this.BUT_write = new MissionPlanner.Controls.MyButton();
            this.BUT_read = new MissionPlanner.Controls.MyButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TXT_homealt = new System.Windows.Forms.TextBox();
            this.TXT_homelng = new System.Windows.Forms.TextBox();
            this.TXT_homelat = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.coords1 = new MissionPlanner.Controls.Coords();
            this.lbl_status = new System.Windows.Forms.Label();
            this.panelWaypoints = new System.Windows.Forms.Panel();
            this.but_mincommands = new MissionPlanner.Controls.MyButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chk_grid = new System.Windows.Forms.CheckBox();
            this.comboBoxMapType = new System.Windows.Forms.ComboBox();
            this.lnk_kml = new System.Windows.Forms.LinkLabel();
            this.CMB_altmode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar1 = new MissionPlanner.Controls.MyTrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_wpfile = new System.Windows.Forms.Label();
            this.BUT_loadwpfile = new MissionPlanner.Controls.MyButton();
            this.BUT_saveWPFile = new MissionPlanner.Controls.MyButton();
            this.CHK_splinedefault = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TXT_altwarn = new System.Windows.Forms.TextBox();
            this.BUT_Add = new MissionPlanner.Controls.MyButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelMap = new System.Windows.Forms.Panel();
            this.lbl_homedist = new System.Windows.Forms.Label();
            this.lbl_prevdist = new System.Windows.Forms.Label();
            this.lbl_distance = new System.Windows.Forms.Label();
            this.cmb_missiontype = new System.Windows.Forms.ComboBox();
            this.MainMap = new MissionPlanner.Controls.myGMAP();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertWpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertSplineWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loiterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loiterForeverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loitertimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loitercirclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpstartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpwPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.landToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPolygonPointToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPolygonToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.savePolygonToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPolygonToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSHPToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.areaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.geoFenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeoFenceuploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeoFencedownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setReturnLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rallyPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRallyPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getRallyPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRallyPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRallyPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createWpCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSplineCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCircleSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveyGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMeasure = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefetchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefetchWPPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kMLOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseWPsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoadSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAndAppendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadKMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSHPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poiaddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poideleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poieditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackerHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyAltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterUTMCoordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchDockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setHomeHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPolygonPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fenceInclusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fenceExclusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBASE = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripPoly = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.drawAPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripZoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToMissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GoToThisWPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зажатьЭтуТочкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationListControl1 = new MissionPlanner.Controls.NewControls.NotificationListControl();
            this.notificationControl1 = new MissionPlanner.Controls.NewControls.NotificationControl();
            this.rulerControl1 = new MissionPlanner.Controls.NewControls.RulerControl();
            this.wpMenu1 = new MissionPlanner.Controls.NewControls.WPMenu();
            this.mainMenuWidget1 = new MissionPlanner.Controls.MainMenuWidget();
            this.Commands = new MissionPlanner.Controls.MyDataGridView();
            this.Command = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Param1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frame = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.coordZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordEasting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordNorthing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MGRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Up = new System.Windows.Forms.DataGridViewImageColumn();
            this.Down = new System.Windows.Forms.DataGridViewImageColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelWaypoints.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelMap.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelBASE.SuspendLayout();
            this.contextMenuStripPoly.SuspendLayout();
            this.contextMenuStripZoom.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).BeginInit();
            this.SuspendLayout();
            // 
            // CHK_verifyheight
            // 
            resources.ApplyResources(this.CHK_verifyheight, "CHK_verifyheight");
            this.CHK_verifyheight.Name = "CHK_verifyheight";
            this.CHK_verifyheight.UseVisualStyleBackColor = true;
            // 
            // TXT_WPRad
            // 
            resources.ApplyResources(this.TXT_WPRad, "TXT_WPRad");
            this.TXT_WPRad.Name = "TXT_WPRad";
            this.TXT_WPRad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_WPRad_KeyPress);
            this.TXT_WPRad.Leave += new System.EventHandler(this.TXT_WPRad_Leave);
            // 
            // TXT_DefaultAlt
            // 
            resources.ApplyResources(this.TXT_DefaultAlt, "TXT_DefaultAlt");
            this.TXT_DefaultAlt.Name = "TXT_DefaultAlt";
            this.TXT_DefaultAlt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_DefaultAlt_KeyPress);
            this.TXT_DefaultAlt.Leave += new System.EventHandler(this.TXT_DefaultAlt_Leave);
            // 
            // LBL_WPRad
            // 
            resources.ApplyResources(this.LBL_WPRad, "LBL_WPRad");
            this.LBL_WPRad.Name = "LBL_WPRad";
            // 
            // LBL_defalutalt
            // 
            resources.ApplyResources(this.LBL_defalutalt, "LBL_defalutalt");
            this.LBL_defalutalt.Name = "LBL_defalutalt";
            // 
            // TXT_loiterrad
            // 
            resources.ApplyResources(this.TXT_loiterrad, "TXT_loiterrad");
            this.TXT_loiterrad.Name = "TXT_loiterrad";
            this.TXT_loiterrad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_loiterrad_KeyPress);
            this.TXT_loiterrad.Leave += new System.EventHandler(this.TXT_loiterrad_Leave);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.but_writewpfast);
            this.panel5.Controls.Add(this.BUT_write);
            this.panel5.Controls.Add(this.BUT_read);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // but_writewpfast
            // 
            this.but_writewpfast.BGGradBot = System.Drawing.Color.Empty;
            this.but_writewpfast.BGGradTop = System.Drawing.Color.Empty;
            resources.ApplyResources(this.but_writewpfast, "but_writewpfast");
            this.but_writewpfast.Name = "but_writewpfast";
            this.but_writewpfast.Outline = System.Drawing.Color.Empty;
            this.but_writewpfast.TextColor = System.Drawing.Color.Empty;
            this.but_writewpfast.UseVisualStyleBackColor = true;
            this.but_writewpfast.Click += new System.EventHandler(this.but_writewpfast_Click);
            // 
            // BUT_write
            // 
            this.BUT_write.BGGradBot = System.Drawing.Color.Empty;
            this.BUT_write.BGGradTop = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_write, "BUT_write");
            this.BUT_write.Name = "BUT_write";
            this.BUT_write.Outline = System.Drawing.Color.Empty;
            this.BUT_write.TextColor = System.Drawing.Color.Empty;
            this.BUT_write.UseVisualStyleBackColor = true;
            this.BUT_write.Click += new System.EventHandler(this.BUT_write_Click);
            // 
            // BUT_read
            // 
            this.BUT_read.BGGradBot = System.Drawing.Color.Empty;
            this.BUT_read.BGGradTop = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_read, "BUT_read");
            this.BUT_read.Name = "BUT_read";
            this.BUT_read.Outline = System.Drawing.Color.Empty;
            this.BUT_read.TextColor = System.Drawing.Color.Empty;
            this.BUT_read.UseVisualStyleBackColor = true;
            this.BUT_read.Click += new System.EventHandler(this.BUT_read_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.TXT_homealt);
            this.panel1.Controls.Add(this.TXT_homelng);
            this.panel1.Controls.Add(this.TXT_homelat);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.TabStop = true;
            this.label4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.label4_LinkClicked);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // TXT_homealt
            // 
            resources.ApplyResources(this.TXT_homealt, "TXT_homealt");
            this.TXT_homealt.Name = "TXT_homealt";
            this.TXT_homealt.TextChanged += new System.EventHandler(this.TXT_homealt_TextChanged);
            // 
            // TXT_homelng
            // 
            resources.ApplyResources(this.TXT_homelng, "TXT_homelng");
            this.TXT_homelng.Name = "TXT_homelng";
            this.TXT_homelng.TextChanged += new System.EventHandler(this.TXT_homelng_TextChanged);
            // 
            // TXT_homelat
            // 
            resources.ApplyResources(this.TXT_homelat, "TXT_homelat");
            this.TXT_homelat.Name = "TXT_homelat";
            this.TXT_homelat.TextChanged += new System.EventHandler(this.TXT_homelat_TextChanged);
            this.TXT_homelat.Enter += new System.EventHandler(this.TXT_homelat_Enter);
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dataGridViewImageColumn2, "dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // coords1
            // 
            this.coords1.Alt = 0D;
            this.coords1.AltSource = "";
            this.coords1.AltUnit = "m";
            this.coords1.Lat = 0D;
            this.coords1.Lng = 0D;
            resources.ApplyResources(this.coords1, "coords1");
            this.coords1.Name = "coords1";
            this.coords1.Vertical = true;
            this.coords1.SystemChanged += new System.EventHandler(this.coords1_SystemChanged);
            // 
            // lbl_status
            // 
            resources.ApplyResources(this.lbl_status, "lbl_status");
            this.lbl_status.Name = "lbl_status";
            // 
            // panelWaypoints
            // 
            this.panelWaypoints.Controls.Add(this.coords1);
            this.panelWaypoints.Controls.Add(this.but_mincommands);
            this.panelWaypoints.Controls.Add(this.panel3);
            this.panelWaypoints.Controls.Add(this.CMB_altmode);
            this.panelWaypoints.Controls.Add(this.label11);
            this.panelWaypoints.Controls.Add(this.trackBar1);
            this.panelWaypoints.Controls.Add(this.panel2);
            this.panelWaypoints.Controls.Add(this.CHK_splinedefault);
            this.panelWaypoints.Controls.Add(this.panel5);
            this.panelWaypoints.Controls.Add(this.label17);
            this.panelWaypoints.Controls.Add(this.panel1);
            this.panelWaypoints.Controls.Add(this.TXT_altwarn);
            this.panelWaypoints.Controls.Add(this.LBL_WPRad);
            this.panelWaypoints.Controls.Add(this.label5);
            this.panelWaypoints.Controls.Add(this.TXT_loiterrad);
            this.panelWaypoints.Controls.Add(this.LBL_defalutalt);
            this.panelWaypoints.Controls.Add(this.Commands);
            this.panelWaypoints.Controls.Add(this.TXT_DefaultAlt);
            this.panelWaypoints.Controls.Add(this.CHK_verifyheight);
            this.panelWaypoints.Controls.Add(this.TXT_WPRad);
            this.panelWaypoints.Controls.Add(this.BUT_Add);
            resources.ApplyResources(this.panelWaypoints, "panelWaypoints");
            this.panelWaypoints.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelWaypoints.Name = "panelWaypoints";
            // 
            // but_mincommands
            // 
            resources.ApplyResources(this.but_mincommands, "but_mincommands");
            this.but_mincommands.BGGradBot = System.Drawing.Color.Empty;
            this.but_mincommands.BGGradTop = System.Drawing.Color.Empty;
            this.but_mincommands.Name = "but_mincommands";
            this.but_mincommands.Outline = System.Drawing.Color.Empty;
            this.but_mincommands.TextColor = System.Drawing.Color.Empty;
            this.but_mincommands.UseVisualStyleBackColor = true;
            this.but_mincommands.Click += new System.EventHandler(this.but_mincommands_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chk_grid);
            this.panel3.Controls.Add(this.lbl_status);
            this.panel3.Controls.Add(this.comboBoxMapType);
            this.panel3.Controls.Add(this.lnk_kml);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // chk_grid
            // 
            resources.ApplyResources(this.chk_grid, "chk_grid");
            this.chk_grid.Name = "chk_grid";
            this.chk_grid.UseVisualStyleBackColor = true;
            this.chk_grid.CheckedChanged += new System.EventHandler(this.chk_grid_CheckedChanged);
            // 
            // comboBoxMapType
            // 
            this.comboBoxMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMapType.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxMapType, "comboBoxMapType");
            this.comboBoxMapType.Name = "comboBoxMapType";
            this.toolTip1.SetToolTip(this.comboBoxMapType, resources.GetString("comboBoxMapType.ToolTip"));
            // 
            // lnk_kml
            // 
            resources.ApplyResources(this.lnk_kml, "lnk_kml");
            this.lnk_kml.Name = "lnk_kml";
            this.lnk_kml.TabStop = true;
            this.lnk_kml.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_kml_LinkClicked);
            // 
            // CMB_altmode
            // 
            this.CMB_altmode.FormattingEnabled = true;
            resources.ApplyResources(this.CMB_altmode, "CMB_altmode");
            this.CMB_altmode.Name = "CMB_altmode";
            this.CMB_altmode.SelectedIndexChanged += new System.EventHandler(this.CMB_altmode_SelectedIndexChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.LargeChange = 0.005F;
            this.trackBar1.Maximum = 24F;
            this.trackBar1.Minimum = 1F;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.SmallChange = 0.001F;
            this.trackBar1.TickFrequency = 1F;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 2F;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_wpfile);
            this.panel2.Controls.Add(this.BUT_loadwpfile);
            this.panel2.Controls.Add(this.BUT_saveWPFile);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lbl_wpfile
            // 
            resources.ApplyResources(this.lbl_wpfile, "lbl_wpfile");
            this.lbl_wpfile.Name = "lbl_wpfile";
            // 
            // BUT_loadwpfile
            // 
            this.BUT_loadwpfile.BGGradBot = System.Drawing.Color.Empty;
            this.BUT_loadwpfile.BGGradTop = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_loadwpfile, "BUT_loadwpfile");
            this.BUT_loadwpfile.Name = "BUT_loadwpfile";
            this.BUT_loadwpfile.Outline = System.Drawing.Color.Empty;
            this.BUT_loadwpfile.TextColor = System.Drawing.Color.Empty;
            this.BUT_loadwpfile.UseVisualStyleBackColor = true;
            this.BUT_loadwpfile.Click += new System.EventHandler(this.BUT_loadwpfile_Click);
            // 
            // BUT_saveWPFile
            // 
            this.BUT_saveWPFile.BGGradBot = System.Drawing.Color.Empty;
            this.BUT_saveWPFile.BGGradTop = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_saveWPFile, "BUT_saveWPFile");
            this.BUT_saveWPFile.Name = "BUT_saveWPFile";
            this.BUT_saveWPFile.Outline = System.Drawing.Color.Empty;
            this.BUT_saveWPFile.TextColor = System.Drawing.Color.Empty;
            this.BUT_saveWPFile.UseVisualStyleBackColor = true;
            this.BUT_saveWPFile.Click += new System.EventHandler(this.BUT_saveWPFile_Click);
            // 
            // CHK_splinedefault
            // 
            resources.ApplyResources(this.CHK_splinedefault, "CHK_splinedefault");
            this.CHK_splinedefault.Name = "CHK_splinedefault";
            this.CHK_splinedefault.UseVisualStyleBackColor = true;
            this.CHK_splinedefault.CheckedChanged += new System.EventHandler(this.CHK_splinedefault_CheckedChanged);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // TXT_altwarn
            // 
            resources.ApplyResources(this.TXT_altwarn, "TXT_altwarn");
            this.TXT_altwarn.Name = "TXT_altwarn";
            // 
            // BUT_Add
            // 
            this.BUT_Add.BGGradBot = System.Drawing.Color.Empty;
            this.BUT_Add.BGGradTop = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_Add, "BUT_Add");
            this.BUT_Add.Name = "BUT_Add";
            this.BUT_Add.Outline = System.Drawing.Color.Empty;
            this.BUT_Add.TextColor = System.Drawing.Color.Empty;
            this.toolTip1.SetToolTip(this.BUT_Add, resources.GetString("BUT_Add.ToolTip"));
            this.BUT_Add.UseVisualStyleBackColor = true;
            this.BUT_Add.Click += new System.EventHandler(this.BUT_Add_Click);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // panelMap
            // 
            this.panelMap.Controls.Add(this.notificationListControl1);
            this.panelMap.Controls.Add(this.notificationControl1);
            this.panelMap.Controls.Add(this.rulerControl1);
            this.panelMap.Controls.Add(this.wpMenu1);
            this.panelMap.Controls.Add(this.mainMenuWidget1);
            this.panelMap.Controls.Add(this.lbl_homedist);
            this.panelMap.Controls.Add(this.lbl_prevdist);
            this.panelMap.Controls.Add(this.lbl_distance);
            this.panelMap.Controls.Add(this.cmb_missiontype);
            this.panelMap.Controls.Add(this.MainMap);
            resources.ApplyResources(this.panelMap, "panelMap");
            this.panelMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMap.Name = "panelMap";
            this.panelMap.Resize += new System.EventHandler(this.panelMap_Resize);
            // 
            // lbl_homedist
            // 
            resources.ApplyResources(this.lbl_homedist, "lbl_homedist");
            this.lbl_homedist.Name = "lbl_homedist";
            // 
            // lbl_prevdist
            // 
            resources.ApplyResources(this.lbl_prevdist, "lbl_prevdist");
            this.lbl_prevdist.Name = "lbl_prevdist";
            // 
            // lbl_distance
            // 
            resources.ApplyResources(this.lbl_distance, "lbl_distance");
            this.lbl_distance.Name = "lbl_distance";
            // 
            // cmb_missiontype
            // 
            resources.ApplyResources(this.cmb_missiontype, "cmb_missiontype");
            this.cmb_missiontype.FormattingEnabled = true;
            this.cmb_missiontype.Items.AddRange(new object[] {
            resources.GetString("cmb_missiontype.Items"),
            resources.GetString("cmb_missiontype.Items1"),
            resources.GetString("cmb_missiontype.Items2")});
            this.cmb_missiontype.Name = "cmb_missiontype";
            this.cmb_missiontype.SelectedIndexChanged += new System.EventHandler(this.Cmb_missiontype_SelectedIndexChanged);
            // 
            // MainMap
            // 
            resources.ApplyResources(this.MainMap, "MainMap");
            this.MainMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.ContextMenuStrip = this.contextMenuStrip1;
            this.MainMap.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Gray;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.HoldInvalidation = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 19;
            this.MainMap.MinZoom = 0;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = false;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Zoom = 0D;
            this.MainMap.SizeChanged += new System.EventHandler(this.MainMap_SizeChanged);
            this.MainMap.Paint += new System.Windows.Forms.PaintEventHandler(this.MainMap_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteWPToolStripMenuItem,
            this.insertWpToolStripMenuItem,
            this.insertSplineWPToolStripMenuItem,
            this.loiterToolStripMenuItem,
            this.jumpToolStripMenuItem,
            this.rTLToolStripMenuItem,
            this.landToolStripMenuItem,
            this.takeoffToolStripMenuItem,
            this.setROIToolStripMenuItem,
            this.clearMissionToolStripMenuItem,
            this.toolStripSeparator1,
            this.polygonToolStripMenuItem,
            this.geoFenceToolStripMenuItem,
            this.rallyPointsToolStripMenuItem,
            this.autoWPToolStripMenuItem,
            this.mapToolToolStripMenuItem,
            this.fileLoadSaveToolStripMenuItem,
            this.pOIToolStripMenuItem,
            this.trackerHomeToolStripMenuItem,
            this.modifyAltToolStripMenuItem,
            this.enterUTMCoordToolStripMenuItem,
            this.switchDockingToolStripMenuItem,
            this.setHomeHereToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // deleteWPToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteWPToolStripMenuItem, "deleteWPToolStripMenuItem");
            this.deleteWPToolStripMenuItem.Name = "deleteWPToolStripMenuItem";
            this.deleteWPToolStripMenuItem.Click += new System.EventHandler(this.deleteWPToolStripMenuItem_Click);
            // 
            // insertWpToolStripMenuItem
            // 
            this.insertWpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentPositionToolStripMenuItem});
            resources.ApplyResources(this.insertWpToolStripMenuItem, "insertWpToolStripMenuItem");
            this.insertWpToolStripMenuItem.Name = "insertWpToolStripMenuItem";
            this.insertWpToolStripMenuItem.Click += new System.EventHandler(this.insertWpToolStripMenuItem_Click);
            // 
            // currentPositionToolStripMenuItem
            // 
            this.currentPositionToolStripMenuItem.Name = "currentPositionToolStripMenuItem";
            resources.ApplyResources(this.currentPositionToolStripMenuItem, "currentPositionToolStripMenuItem");
            this.currentPositionToolStripMenuItem.Click += new System.EventHandler(this.currentPositionToolStripMenuItem_Click);
            // 
            // insertSplineWPToolStripMenuItem
            // 
            resources.ApplyResources(this.insertSplineWPToolStripMenuItem, "insertSplineWPToolStripMenuItem");
            this.insertSplineWPToolStripMenuItem.Name = "insertSplineWPToolStripMenuItem";
            this.insertSplineWPToolStripMenuItem.Click += new System.EventHandler(this.insertSplineWPToolStripMenuItem_Click);
            // 
            // loiterToolStripMenuItem
            // 
            this.loiterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loiterForeverToolStripMenuItem,
            this.loitertimeToolStripMenuItem,
            this.loitercirclesToolStripMenuItem});
            resources.ApplyResources(this.loiterToolStripMenuItem, "loiterToolStripMenuItem");
            this.loiterToolStripMenuItem.Name = "loiterToolStripMenuItem";
            // 
            // loiterForeverToolStripMenuItem
            // 
            this.loiterForeverToolStripMenuItem.Name = "loiterForeverToolStripMenuItem";
            resources.ApplyResources(this.loiterForeverToolStripMenuItem, "loiterForeverToolStripMenuItem");
            this.loiterForeverToolStripMenuItem.Click += new System.EventHandler(this.loiterForeverToolStripMenuItem_Click);
            // 
            // loitertimeToolStripMenuItem
            // 
            this.loitertimeToolStripMenuItem.Name = "loitertimeToolStripMenuItem";
            resources.ApplyResources(this.loitertimeToolStripMenuItem, "loitertimeToolStripMenuItem");
            this.loitertimeToolStripMenuItem.Click += new System.EventHandler(this.loitertimeToolStripMenuItem_Click);
            // 
            // loitercirclesToolStripMenuItem
            // 
            this.loitercirclesToolStripMenuItem.Name = "loitercirclesToolStripMenuItem";
            resources.ApplyResources(this.loitercirclesToolStripMenuItem, "loitercirclesToolStripMenuItem");
            this.loitercirclesToolStripMenuItem.Click += new System.EventHandler(this.loitercirclesToolStripMenuItem_Click);
            // 
            // jumpToolStripMenuItem
            // 
            this.jumpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jumpstartToolStripMenuItem,
            this.jumpwPToolStripMenuItem});
            resources.ApplyResources(this.jumpToolStripMenuItem, "jumpToolStripMenuItem");
            this.jumpToolStripMenuItem.Name = "jumpToolStripMenuItem";
            // 
            // jumpstartToolStripMenuItem
            // 
            this.jumpstartToolStripMenuItem.Name = "jumpstartToolStripMenuItem";
            resources.ApplyResources(this.jumpstartToolStripMenuItem, "jumpstartToolStripMenuItem");
            this.jumpstartToolStripMenuItem.Click += new System.EventHandler(this.jumpstartToolStripMenuItem_Click);
            // 
            // jumpwPToolStripMenuItem
            // 
            this.jumpwPToolStripMenuItem.Name = "jumpwPToolStripMenuItem";
            resources.ApplyResources(this.jumpwPToolStripMenuItem, "jumpwPToolStripMenuItem");
            this.jumpwPToolStripMenuItem.Click += new System.EventHandler(this.jumpwPToolStripMenuItem_Click);
            // 
            // rTLToolStripMenuItem
            // 
            resources.ApplyResources(this.rTLToolStripMenuItem, "rTLToolStripMenuItem");
            this.rTLToolStripMenuItem.Name = "rTLToolStripMenuItem";
            this.rTLToolStripMenuItem.Click += new System.EventHandler(this.rTLToolStripMenuItem_Click);
            // 
            // landToolStripMenuItem
            // 
            resources.ApplyResources(this.landToolStripMenuItem, "landToolStripMenuItem");
            this.landToolStripMenuItem.Name = "landToolStripMenuItem";
            this.landToolStripMenuItem.Click += new System.EventHandler(this.landToolStripMenuItem_Click);
            // 
            // takeoffToolStripMenuItem
            // 
            resources.ApplyResources(this.takeoffToolStripMenuItem, "takeoffToolStripMenuItem");
            this.takeoffToolStripMenuItem.Name = "takeoffToolStripMenuItem";
            this.takeoffToolStripMenuItem.Click += new System.EventHandler(this.takeoffToolStripMenuItem_Click);
            // 
            // setROIToolStripMenuItem
            // 
            resources.ApplyResources(this.setROIToolStripMenuItem, "setROIToolStripMenuItem");
            this.setROIToolStripMenuItem.Name = "setROIToolStripMenuItem";
            this.setROIToolStripMenuItem.Click += new System.EventHandler(this.setROIToolStripMenuItem_Click);
            // 
            // clearMissionToolStripMenuItem
            // 
            resources.ApplyResources(this.clearMissionToolStripMenuItem, "clearMissionToolStripMenuItem");
            this.clearMissionToolStripMenuItem.Name = "clearMissionToolStripMenuItem";
            this.clearMissionToolStripMenuItem.Click += new System.EventHandler(this.clearMissionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPolygonPointToolStripMenuItem2,
            this.clearPolygonToolStripMenuItem2,
            this.savePolygonToolStripMenuItem2,
            this.loadPolygonToolStripMenuItem2,
            this.fromSHPToolStripMenuItem2,
            this.areaToolStripMenuItem2});
            resources.ApplyResources(this.polygonToolStripMenuItem, "polygonToolStripMenuItem");
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            // 
            // addPolygonPointToolStripMenuItem2
            // 
            this.addPolygonPointToolStripMenuItem2.Name = "addPolygonPointToolStripMenuItem2";
            resources.ApplyResources(this.addPolygonPointToolStripMenuItem2, "addPolygonPointToolStripMenuItem2");
            this.addPolygonPointToolStripMenuItem2.Click += new System.EventHandler(this.addPolygonPointToolStripMenuItem_Click);
            // 
            // clearPolygonToolStripMenuItem2
            // 
            this.clearPolygonToolStripMenuItem2.Name = "clearPolygonToolStripMenuItem2";
            resources.ApplyResources(this.clearPolygonToolStripMenuItem2, "clearPolygonToolStripMenuItem2");
            this.clearPolygonToolStripMenuItem2.Click += new System.EventHandler(this.clearPolygonToolStripMenuItem_Click);
            // 
            // savePolygonToolStripMenuItem2
            // 
            this.savePolygonToolStripMenuItem2.Name = "savePolygonToolStripMenuItem2";
            resources.ApplyResources(this.savePolygonToolStripMenuItem2, "savePolygonToolStripMenuItem2");
            this.savePolygonToolStripMenuItem2.Click += new System.EventHandler(this.savePolygonToolStripMenuItem_Click);
            // 
            // loadPolygonToolStripMenuItem2
            // 
            this.loadPolygonToolStripMenuItem2.Name = "loadPolygonToolStripMenuItem2";
            resources.ApplyResources(this.loadPolygonToolStripMenuItem2, "loadPolygonToolStripMenuItem2");
            this.loadPolygonToolStripMenuItem2.Click += new System.EventHandler(this.loadPolygonToolStripMenuItem_Click);
            // 
            // fromSHPToolStripMenuItem2
            // 
            this.fromSHPToolStripMenuItem2.Name = "fromSHPToolStripMenuItem2";
            resources.ApplyResources(this.fromSHPToolStripMenuItem2, "fromSHPToolStripMenuItem2");
            this.fromSHPToolStripMenuItem2.Click += new System.EventHandler(this.fromSHPToolStripMenuItem_Click);
            // 
            // areaToolStripMenuItem2
            // 
            this.areaToolStripMenuItem2.Name = "areaToolStripMenuItem2";
            resources.ApplyResources(this.areaToolStripMenuItem2, "areaToolStripMenuItem2");
            this.areaToolStripMenuItem2.Click += new System.EventHandler(this.areaToolStripMenuItem_Click);
            // 
            // geoFenceToolStripMenuItem
            // 
            this.geoFenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GeoFenceuploadToolStripMenuItem,
            this.GeoFencedownloadToolStripMenuItem,
            this.setReturnLocationToolStripMenuItem,
            this.loadFromFileToolStripMenuItem,
            this.saveToFileToolStripMenuItem,
            this.clearToolStripMenuItem});
            resources.ApplyResources(this.geoFenceToolStripMenuItem, "geoFenceToolStripMenuItem");
            this.geoFenceToolStripMenuItem.Name = "geoFenceToolStripMenuItem";
            // 
            // GeoFenceuploadToolStripMenuItem
            // 
            this.GeoFenceuploadToolStripMenuItem.Name = "GeoFenceuploadToolStripMenuItem";
            resources.ApplyResources(this.GeoFenceuploadToolStripMenuItem, "GeoFenceuploadToolStripMenuItem");
            this.GeoFenceuploadToolStripMenuItem.Click += new System.EventHandler(this.GeoFenceuploadToolStripMenuItem_Click);
            // 
            // GeoFencedownloadToolStripMenuItem
            // 
            this.GeoFencedownloadToolStripMenuItem.Name = "GeoFencedownloadToolStripMenuItem";
            resources.ApplyResources(this.GeoFencedownloadToolStripMenuItem, "GeoFencedownloadToolStripMenuItem");
            this.GeoFencedownloadToolStripMenuItem.Click += new System.EventHandler(this.GeoFencedownloadToolStripMenuItem_Click);
            // 
            // setReturnLocationToolStripMenuItem
            // 
            this.setReturnLocationToolStripMenuItem.Name = "setReturnLocationToolStripMenuItem";
            resources.ApplyResources(this.setReturnLocationToolStripMenuItem, "setReturnLocationToolStripMenuItem");
            this.setReturnLocationToolStripMenuItem.Click += new System.EventHandler(this.setReturnLocationToolStripMenuItem_Click);
            // 
            // loadFromFileToolStripMenuItem
            // 
            this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            resources.ApplyResources(this.loadFromFileToolStripMenuItem, "loadFromFileToolStripMenuItem");
            this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromFileToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            resources.ApplyResources(this.saveToFileToolStripMenuItem, "saveToFileToolStripMenuItem");
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // rallyPointsToolStripMenuItem
            // 
            this.rallyPointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setRallyPointToolStripMenuItem,
            this.getRallyPointsToolStripMenuItem,
            this.saveRallyPointsToolStripMenuItem,
            this.clearRallyPointsToolStripMenuItem,
            this.saveToFileToolStripMenuItem1,
            this.loadFromFileToolStripMenuItem1});
            this.rallyPointsToolStripMenuItem.Name = "rallyPointsToolStripMenuItem";
            resources.ApplyResources(this.rallyPointsToolStripMenuItem, "rallyPointsToolStripMenuItem");
            // 
            // setRallyPointToolStripMenuItem
            // 
            this.setRallyPointToolStripMenuItem.Name = "setRallyPointToolStripMenuItem";
            resources.ApplyResources(this.setRallyPointToolStripMenuItem, "setRallyPointToolStripMenuItem");
            this.setRallyPointToolStripMenuItem.Click += new System.EventHandler(this.setRallyPointToolStripMenuItem_Click);
            // 
            // getRallyPointsToolStripMenuItem
            // 
            this.getRallyPointsToolStripMenuItem.Name = "getRallyPointsToolStripMenuItem";
            resources.ApplyResources(this.getRallyPointsToolStripMenuItem, "getRallyPointsToolStripMenuItem");
            this.getRallyPointsToolStripMenuItem.Click += new System.EventHandler(this.getRallyPointsToolStripMenuItem_Click);
            // 
            // saveRallyPointsToolStripMenuItem
            // 
            this.saveRallyPointsToolStripMenuItem.Name = "saveRallyPointsToolStripMenuItem";
            resources.ApplyResources(this.saveRallyPointsToolStripMenuItem, "saveRallyPointsToolStripMenuItem");
            this.saveRallyPointsToolStripMenuItem.Click += new System.EventHandler(this.saveRallyPointsToolStripMenuItem_Click);
            // 
            // clearRallyPointsToolStripMenuItem
            // 
            this.clearRallyPointsToolStripMenuItem.Name = "clearRallyPointsToolStripMenuItem";
            resources.ApplyResources(this.clearRallyPointsToolStripMenuItem, "clearRallyPointsToolStripMenuItem");
            this.clearRallyPointsToolStripMenuItem.Click += new System.EventHandler(this.clearRallyPointsToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem1
            // 
            this.saveToFileToolStripMenuItem1.Name = "saveToFileToolStripMenuItem1";
            resources.ApplyResources(this.saveToFileToolStripMenuItem1, "saveToFileToolStripMenuItem1");
            this.saveToFileToolStripMenuItem1.Click += new System.EventHandler(this.saveToFileToolStripMenuItem1_Click);
            // 
            // loadFromFileToolStripMenuItem1
            // 
            this.loadFromFileToolStripMenuItem1.Name = "loadFromFileToolStripMenuItem1";
            resources.ApplyResources(this.loadFromFileToolStripMenuItem1, "loadFromFileToolStripMenuItem1");
            this.loadFromFileToolStripMenuItem1.Click += new System.EventHandler(this.loadFromFileToolStripMenuItem1_Click);
            // 
            // autoWPToolStripMenuItem
            // 
            this.autoWPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createWpCircleToolStripMenuItem,
            this.createSplineCircleToolStripMenuItem,
            this.areaToolStripMenuItem1,
            this.textToolStripMenuItem,
            this.createCircleSurveyToolStripMenuItem,
            this.surveyGridToolStripMenuItem});
            resources.ApplyResources(this.autoWPToolStripMenuItem, "autoWPToolStripMenuItem");
            this.autoWPToolStripMenuItem.Name = "autoWPToolStripMenuItem";
            // 
            // createWpCircleToolStripMenuItem
            // 
            this.createWpCircleToolStripMenuItem.Name = "createWpCircleToolStripMenuItem";
            resources.ApplyResources(this.createWpCircleToolStripMenuItem, "createWpCircleToolStripMenuItem");
            this.createWpCircleToolStripMenuItem.Click += new System.EventHandler(this.createWpCircleToolStripMenuItem_Click);
            // 
            // createSplineCircleToolStripMenuItem
            // 
            this.createSplineCircleToolStripMenuItem.Name = "createSplineCircleToolStripMenuItem";
            resources.ApplyResources(this.createSplineCircleToolStripMenuItem, "createSplineCircleToolStripMenuItem");
            this.createSplineCircleToolStripMenuItem.Click += new System.EventHandler(this.createSplineCircleToolStripMenuItem_Click);
            // 
            // areaToolStripMenuItem1
            // 
            this.areaToolStripMenuItem1.Name = "areaToolStripMenuItem1";
            resources.ApplyResources(this.areaToolStripMenuItem1, "areaToolStripMenuItem1");
            this.areaToolStripMenuItem1.Click += new System.EventHandler(this.areaToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            resources.ApplyResources(this.textToolStripMenuItem, "textToolStripMenuItem");
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // createCircleSurveyToolStripMenuItem
            // 
            this.createCircleSurveyToolStripMenuItem.Name = "createCircleSurveyToolStripMenuItem";
            resources.ApplyResources(this.createCircleSurveyToolStripMenuItem, "createCircleSurveyToolStripMenuItem");
            this.createCircleSurveyToolStripMenuItem.Click += new System.EventHandler(this.createCircleSurveyToolStripMenuItem_Click);
            // 
            // surveyGridToolStripMenuItem
            // 
            this.surveyGridToolStripMenuItem.Name = "surveyGridToolStripMenuItem";
            resources.ApplyResources(this.surveyGridToolStripMenuItem, "surveyGridToolStripMenuItem");
            this.surveyGridToolStripMenuItem.Click += new System.EventHandler(this.surveyGridToolStripMenuItem_Click);
            // 
            // mapToolToolStripMenuItem
            // 
            this.mapToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMeasure,
            this.rotateMapToolStripMenuItem,
            this.zoomToToolStripMenuItem,
            this.prefetchToolStripMenuItem,
            this.prefetchWPPathToolStripMenuItem,
            this.kMLOverlayToolStripMenuItem,
            this.elevationGraphToolStripMenuItem,
            this.reverseWPsToolStripMenuItem});
            resources.ApplyResources(this.mapToolToolStripMenuItem, "mapToolToolStripMenuItem");
            this.mapToolToolStripMenuItem.Name = "mapToolToolStripMenuItem";
            // 
            // ContextMeasure
            // 
            this.ContextMeasure.Name = "ContextMeasure";
            resources.ApplyResources(this.ContextMeasure, "ContextMeasure");
            this.ContextMeasure.Click += new System.EventHandler(this.ContextMeasure_Click);
            // 
            // rotateMapToolStripMenuItem
            // 
            this.rotateMapToolStripMenuItem.Name = "rotateMapToolStripMenuItem";
            resources.ApplyResources(this.rotateMapToolStripMenuItem, "rotateMapToolStripMenuItem");
            this.rotateMapToolStripMenuItem.Click += new System.EventHandler(this.rotateMapToolStripMenuItem_Click);
            // 
            // zoomToToolStripMenuItem
            // 
            this.zoomToToolStripMenuItem.Name = "zoomToToolStripMenuItem";
            resources.ApplyResources(this.zoomToToolStripMenuItem, "zoomToToolStripMenuItem");
            this.zoomToToolStripMenuItem.Click += new System.EventHandler(this.zoomToToolStripMenuItem_Click);
            // 
            // prefetchToolStripMenuItem
            // 
            this.prefetchToolStripMenuItem.Name = "prefetchToolStripMenuItem";
            resources.ApplyResources(this.prefetchToolStripMenuItem, "prefetchToolStripMenuItem");
            this.prefetchToolStripMenuItem.Click += new System.EventHandler(this.prefetchToolStripMenuItem_Click);
            // 
            // prefetchWPPathToolStripMenuItem
            // 
            this.prefetchWPPathToolStripMenuItem.Name = "prefetchWPPathToolStripMenuItem";
            resources.ApplyResources(this.prefetchWPPathToolStripMenuItem, "prefetchWPPathToolStripMenuItem");
            this.prefetchWPPathToolStripMenuItem.Click += new System.EventHandler(this.prefetchWPPathToolStripMenuItem_Click);
            // 
            // kMLOverlayToolStripMenuItem
            // 
            this.kMLOverlayToolStripMenuItem.Name = "kMLOverlayToolStripMenuItem";
            resources.ApplyResources(this.kMLOverlayToolStripMenuItem, "kMLOverlayToolStripMenuItem");
            this.kMLOverlayToolStripMenuItem.Click += new System.EventHandler(this.kMLOverlayToolStripMenuItem_Click);
            // 
            // elevationGraphToolStripMenuItem
            // 
            this.elevationGraphToolStripMenuItem.Name = "elevationGraphToolStripMenuItem";
            resources.ApplyResources(this.elevationGraphToolStripMenuItem, "elevationGraphToolStripMenuItem");
            this.elevationGraphToolStripMenuItem.Click += new System.EventHandler(this.elevationGraphToolStripMenuItem_Click);
            // 
            // reverseWPsToolStripMenuItem
            // 
            this.reverseWPsToolStripMenuItem.Name = "reverseWPsToolStripMenuItem";
            resources.ApplyResources(this.reverseWPsToolStripMenuItem, "reverseWPsToolStripMenuItem");
            this.reverseWPsToolStripMenuItem.Click += new System.EventHandler(this.reverseWPsToolStripMenuItem_Click);
            // 
            // fileLoadSaveToolStripMenuItem
            // 
            this.fileLoadSaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadWPFileToolStripMenuItem,
            this.loadAndAppendToolStripMenuItem,
            this.saveWPFileToolStripMenuItem,
            this.loadKMLFileToolStripMenuItem,
            this.loadSHPFileToolStripMenuItem});
            resources.ApplyResources(this.fileLoadSaveToolStripMenuItem, "fileLoadSaveToolStripMenuItem");
            this.fileLoadSaveToolStripMenuItem.Name = "fileLoadSaveToolStripMenuItem";
            // 
            // loadWPFileToolStripMenuItem
            // 
            this.loadWPFileToolStripMenuItem.Name = "loadWPFileToolStripMenuItem";
            resources.ApplyResources(this.loadWPFileToolStripMenuItem, "loadWPFileToolStripMenuItem");
            this.loadWPFileToolStripMenuItem.Click += new System.EventHandler(this.loadWPFileToolStripMenuItem_Click);
            // 
            // loadAndAppendToolStripMenuItem
            // 
            this.loadAndAppendToolStripMenuItem.Name = "loadAndAppendToolStripMenuItem";
            resources.ApplyResources(this.loadAndAppendToolStripMenuItem, "loadAndAppendToolStripMenuItem");
            this.loadAndAppendToolStripMenuItem.Click += new System.EventHandler(this.loadAndAppendToolStripMenuItem_Click);
            // 
            // saveWPFileToolStripMenuItem
            // 
            this.saveWPFileToolStripMenuItem.Name = "saveWPFileToolStripMenuItem";
            resources.ApplyResources(this.saveWPFileToolStripMenuItem, "saveWPFileToolStripMenuItem");
            this.saveWPFileToolStripMenuItem.Click += new System.EventHandler(this.saveWPFileToolStripMenuItem_Click);
            // 
            // loadKMLFileToolStripMenuItem
            // 
            this.loadKMLFileToolStripMenuItem.Name = "loadKMLFileToolStripMenuItem";
            resources.ApplyResources(this.loadKMLFileToolStripMenuItem, "loadKMLFileToolStripMenuItem");
            this.loadKMLFileToolStripMenuItem.Click += new System.EventHandler(this.loadKMLFileToolStripMenuItem_Click);
            // 
            // loadSHPFileToolStripMenuItem
            // 
            this.loadSHPFileToolStripMenuItem.Name = "loadSHPFileToolStripMenuItem";
            resources.ApplyResources(this.loadSHPFileToolStripMenuItem, "loadSHPFileToolStripMenuItem");
            this.loadSHPFileToolStripMenuItem.Click += new System.EventHandler(this.loadSHPFileToolStripMenuItem_Click);
            // 
            // pOIToolStripMenuItem
            // 
            this.pOIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.poiaddToolStripMenuItem,
            this.poideleteToolStripMenuItem,
            this.poieditToolStripMenuItem});
            resources.ApplyResources(this.pOIToolStripMenuItem, "pOIToolStripMenuItem");
            this.pOIToolStripMenuItem.Name = "pOIToolStripMenuItem";
            // 
            // poiaddToolStripMenuItem
            // 
            this.poiaddToolStripMenuItem.Name = "poiaddToolStripMenuItem";
            resources.ApplyResources(this.poiaddToolStripMenuItem, "poiaddToolStripMenuItem");
            this.poiaddToolStripMenuItem.Click += new System.EventHandler(this.poiaddToolStripMenuItem_Click);
            // 
            // poideleteToolStripMenuItem
            // 
            this.poideleteToolStripMenuItem.Name = "poideleteToolStripMenuItem";
            resources.ApplyResources(this.poideleteToolStripMenuItem, "poideleteToolStripMenuItem");
            this.poideleteToolStripMenuItem.Click += new System.EventHandler(this.poideleteToolStripMenuItem_Click);
            // 
            // poieditToolStripMenuItem
            // 
            this.poieditToolStripMenuItem.Name = "poieditToolStripMenuItem";
            resources.ApplyResources(this.poieditToolStripMenuItem, "poieditToolStripMenuItem");
            this.poieditToolStripMenuItem.Click += new System.EventHandler(this.poieditToolStripMenuItem_Click);
            // 
            // trackerHomeToolStripMenuItem
            // 
            resources.ApplyResources(this.trackerHomeToolStripMenuItem, "trackerHomeToolStripMenuItem");
            this.trackerHomeToolStripMenuItem.Name = "trackerHomeToolStripMenuItem";
            this.trackerHomeToolStripMenuItem.Click += new System.EventHandler(this.trackerHomeToolStripMenuItem_Click);
            // 
            // modifyAltToolStripMenuItem
            // 
            resources.ApplyResources(this.modifyAltToolStripMenuItem, "modifyAltToolStripMenuItem");
            this.modifyAltToolStripMenuItem.Name = "modifyAltToolStripMenuItem";
            this.modifyAltToolStripMenuItem.Click += new System.EventHandler(this.modifyAltToolStripMenuItem_Click);
            // 
            // enterUTMCoordToolStripMenuItem
            // 
            resources.ApplyResources(this.enterUTMCoordToolStripMenuItem, "enterUTMCoordToolStripMenuItem");
            this.enterUTMCoordToolStripMenuItem.Name = "enterUTMCoordToolStripMenuItem";
            this.enterUTMCoordToolStripMenuItem.Click += new System.EventHandler(this.enterUTMCoordToolStripMenuItem_Click);
            // 
            // switchDockingToolStripMenuItem
            // 
            resources.ApplyResources(this.switchDockingToolStripMenuItem, "switchDockingToolStripMenuItem");
            this.switchDockingToolStripMenuItem.Name = "switchDockingToolStripMenuItem";
            this.switchDockingToolStripMenuItem.Click += new System.EventHandler(this.switchDockingToolStripMenuItem_Click);
            // 
            // setHomeHereToolStripMenuItem
            // 
            resources.ApplyResources(this.setHomeHereToolStripMenuItem, "setHomeHereToolStripMenuItem");
            this.setHomeHereToolStripMenuItem.Name = "setHomeHereToolStripMenuItem";
            this.setHomeHereToolStripMenuItem.Click += new System.EventHandler(this.setHomeHereToolStripMenuItem_Click);
            // 
            // addPolygonPointToolStripMenuItem
            // 
            this.addPolygonPointToolStripMenuItem.Name = "addPolygonPointToolStripMenuItem";
            resources.ApplyResources(this.addPolygonPointToolStripMenuItem, "addPolygonPointToolStripMenuItem");
            this.addPolygonPointToolStripMenuItem.Click += new System.EventHandler(this.addPolygonPointToolStripMenuItem_Click);
            // 
            // clearPolygonToolStripMenuItem
            // 
            this.clearPolygonToolStripMenuItem.Name = "clearPolygonToolStripMenuItem";
            resources.ApplyResources(this.clearPolygonToolStripMenuItem, "clearPolygonToolStripMenuItem");
            this.clearPolygonToolStripMenuItem.Click += new System.EventHandler(this.clearPolygonToolStripMenuItem_Click);
            // 
            // savePolygonToolStripMenuItem
            // 
            this.savePolygonToolStripMenuItem.Name = "savePolygonToolStripMenuItem";
            resources.ApplyResources(this.savePolygonToolStripMenuItem, "savePolygonToolStripMenuItem");
            this.savePolygonToolStripMenuItem.Click += new System.EventHandler(this.savePolygonToolStripMenuItem_Click);
            // 
            // loadPolygonToolStripMenuItem
            // 
            this.loadPolygonToolStripMenuItem.Name = "loadPolygonToolStripMenuItem";
            resources.ApplyResources(this.loadPolygonToolStripMenuItem, "loadPolygonToolStripMenuItem");
            this.loadPolygonToolStripMenuItem.Click += new System.EventHandler(this.loadPolygonToolStripMenuItem_Click);
            // 
            // fromSHPToolStripMenuItem
            // 
            this.fromSHPToolStripMenuItem.Name = "fromSHPToolStripMenuItem";
            resources.ApplyResources(this.fromSHPToolStripMenuItem, "fromSHPToolStripMenuItem");
            this.fromSHPToolStripMenuItem.Click += new System.EventHandler(this.fromSHPToolStripMenuItem_Click);
            // 
            // areaToolStripMenuItem
            // 
            this.areaToolStripMenuItem.Name = "areaToolStripMenuItem";
            resources.ApplyResources(this.areaToolStripMenuItem, "areaToolStripMenuItem");
            this.areaToolStripMenuItem.Click += new System.EventHandler(this.areaToolStripMenuItem_Click);
            // 
            // fenceInclusionToolStripMenuItem
            // 
            this.fenceInclusionToolStripMenuItem.Name = "fenceInclusionToolStripMenuItem";
            resources.ApplyResources(this.fenceInclusionToolStripMenuItem, "fenceInclusionToolStripMenuItem");
            this.fenceInclusionToolStripMenuItem.Click += new System.EventHandler(this.FenceInclusionToolStripMenuItem_Click);
            // 
            // fenceExclusionToolStripMenuItem
            // 
            this.fenceExclusionToolStripMenuItem.Name = "fenceExclusionToolStripMenuItem";
            resources.ApplyResources(this.fenceExclusionToolStripMenuItem, "fenceExclusionToolStripMenuItem");
            this.fenceExclusionToolStripMenuItem.Click += new System.EventHandler(this.FenceExclusionToolStripMenuItem_Click);
            // 
            // panelBASE
            // 
            this.panelBASE.Controls.Add(this.splitter1);
            this.panelBASE.Controls.Add(this.panelMap);
            this.panelBASE.Controls.Add(this.panelWaypoints);
            this.panelBASE.Controls.Add(this.label6);
            resources.ApplyResources(this.panelBASE, "panelBASE");
            this.panelBASE.Name = "panelBASE";
            // 
            // timer1
            // 
            this.timer1.Interval = 1200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStripPoly
            // 
            this.contextMenuStripPoly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPolygonPointToolStripMenuItem,
            this.clearPolygonToolStripMenuItem,
            this.savePolygonToolStripMenuItem,
            this.loadPolygonToolStripMenuItem,
            this.fromSHPToolStripMenuItem,
            this.areaToolStripMenuItem,
            this.fenceInclusionToolStripMenuItem,
            this.fenceExclusionToolStripMenuItem});
            this.contextMenuStripPoly.Name = "contextMenuStripPoly";
            this.contextMenuStripPoly.ShowImageMargin = false;
            resources.ApplyResources(this.contextMenuStripPoly, "contextMenuStripPoly");
            this.contextMenuStripPoly.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripPoly_Opening);
            // 
            // drawAPolygonToolStripMenuItem
            // 
            this.drawAPolygonToolStripMenuItem.Name = "drawAPolygonToolStripMenuItem";
            resources.ApplyResources(this.drawAPolygonToolStripMenuItem, "drawAPolygonToolStripMenuItem");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            resources.ApplyResources(this.testToolStripMenuItem, "testToolStripMenuItem");
            // 
            // contextMenuStripZoom
            // 
            this.contextMenuStripZoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToVehicleToolStripMenuItem,
            this.zoomToMissionToolStripMenuItem,
            this.zoomToHomeToolStripMenuItem});
            this.contextMenuStripZoom.Name = "contextMenuStripZoom";
            resources.ApplyResources(this.contextMenuStripZoom, "contextMenuStripZoom");
            // 
            // zoomToVehicleToolStripMenuItem
            // 
            this.zoomToVehicleToolStripMenuItem.Name = "zoomToVehicleToolStripMenuItem";
            resources.ApplyResources(this.zoomToVehicleToolStripMenuItem, "zoomToVehicleToolStripMenuItem");
            this.zoomToVehicleToolStripMenuItem.Click += new System.EventHandler(this.zoomToVehicleToolStripMenuItem_Click);
            // 
            // zoomToMissionToolStripMenuItem
            // 
            this.zoomToMissionToolStripMenuItem.Name = "zoomToMissionToolStripMenuItem";
            resources.ApplyResources(this.zoomToMissionToolStripMenuItem, "zoomToMissionToolStripMenuItem");
            this.zoomToMissionToolStripMenuItem.Click += new System.EventHandler(this.zoomToMissionToolStripMenuItem_Click);
            // 
            // zoomToHomeToolStripMenuItem
            // 
            this.zoomToHomeToolStripMenuItem.Name = "zoomToHomeToolStripMenuItem";
            resources.ApplyResources(this.zoomToHomeToolStripMenuItem, "zoomToHomeToolStripMenuItem");
            this.zoomToHomeToolStripMenuItem.Click += new System.EventHandler(this.zoomToHomeToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoToThisWPToolStripMenuItem,
            this.зажатьЭтуТочкуToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            this.contextMenuStrip2.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip2_Closed);
            // 
            // GoToThisWPToolStripMenuItem
            // 
            this.GoToThisWPToolStripMenuItem.Name = "GoToThisWPToolStripMenuItem";
            resources.ApplyResources(this.GoToThisWPToolStripMenuItem, "GoToThisWPToolStripMenuItem");
            this.GoToThisWPToolStripMenuItem.Click += new System.EventHandler(this.GoToThisWPToolStripMenuItem_Click);
            // 
            // зажатьЭтуТочкуToolStripMenuItem
            // 
            this.зажатьЭтуТочкуToolStripMenuItem.Name = "зажатьЭтуТочкуToolStripMenuItem";
            resources.ApplyResources(this.зажатьЭтуТочкуToolStripMenuItem, "зажатьЭтуТочкуToolStripMenuItem");
            this.зажатьЭтуТочкуToolStripMenuItem.Click += new System.EventHandler(this.GoToWPAndLoiterToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            resources.ApplyResources(this.удалитьToolStripMenuItem, "удалитьToolStripMenuItem");
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.deleteWPToolStripMenuItem2_Click);
            // 
            // notificationListControl1
            // 
            this.notificationListControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            resources.ApplyResources(this.notificationListControl1, "notificationListControl1");
            this.notificationListControl1.Name = "notificationListControl1";
            // 
            // notificationControl1
            // 
            this.notificationControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            resources.ApplyResources(this.notificationControl1, "notificationControl1");
            this.notificationControl1.Name = "notificationControl1";
            // 
            // rulerControl1
            // 
            this.rulerControl1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.rulerControl1, "rulerControl1");
            this.rulerControl1.Name = "rulerControl1";
            // 
            // wpMenu1
            // 
            this.wpMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            resources.ApplyResources(this.wpMenu1, "wpMenu1");
            this.wpMenu1.Name = "wpMenu1";
            this.wpMenu1.SizeChanged += new System.EventHandler(this.wpMenu1_SizeChanged);
            // 
            // mainMenuWidget1
            // 
            this.mainMenuWidget1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            resources.ApplyResources(this.mainMenuWidget1, "mainMenuWidget1");
            this.mainMenuWidget1.Name = "mainMenuWidget1";
            // 
            // Commands
            // 
            this.Commands.AllowUserToAddRows = false;
            resources.ApplyResources(this.Commands, "Commands");
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Commands.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Commands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.Param1,
            this.Param2,
            this.Param3,
            this.Param4,
            this.Lat,
            this.Lon,
            this.Alt,
            this.Frame,
            this.coordZone,
            this.coordEasting,
            this.coordNorthing,
            this.MGRS,
            this.Delete,
            this.Up,
            this.Down,
            this.Grad,
            this.Angle,
            this.Dist,
            this.AZ,
            this.TagData});
            this.Commands.Name = "Commands";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Commands.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.Commands.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.Commands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_CellContentClick);
            this.Commands.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_CellEndEdit);
            this.Commands.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Commands_DataError);
            this.Commands.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.Commands_DefaultValuesNeeded);
            this.Commands.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Commands_EditingControlShowing);
            this.Commands.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Commands_RowEnter);
            this.Commands.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Commands_RowsAdded);
            this.Commands.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Commands_RowsRemoved);
            this.Commands.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Commands_RowValidating);
            // 
            // Command
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.Command.DefaultCellStyle = dataGridViewCellStyle4;
            this.Command.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            resources.ApplyResources(this.Command, "Command");
            this.Command.Name = "Command";
            // 
            // Param1
            // 
            resources.ApplyResources(this.Param1, "Param1");
            this.Param1.Name = "Param1";
            this.Param1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Param2
            // 
            resources.ApplyResources(this.Param2, "Param2");
            this.Param2.Name = "Param2";
            this.Param2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Param3
            // 
            resources.ApplyResources(this.Param3, "Param3");
            this.Param3.Name = "Param3";
            this.Param3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Param4
            // 
            resources.ApplyResources(this.Param4, "Param4");
            this.Param4.Name = "Param4";
            this.Param4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lat
            // 
            resources.ApplyResources(this.Lat, "Lat");
            this.Lat.Name = "Lat";
            this.Lat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lon
            // 
            resources.ApplyResources(this.Lon, "Lon");
            this.Lon.Name = "Lon";
            this.Lon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Alt
            // 
            resources.ApplyResources(this.Alt, "Alt");
            this.Alt.Name = "Alt";
            this.Alt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frame
            // 
            resources.ApplyResources(this.Frame, "Frame");
            this.Frame.Name = "Frame";
            // 
            // coordZone
            // 
            resources.ApplyResources(this.coordZone, "coordZone");
            this.coordZone.Name = "coordZone";
            // 
            // coordEasting
            // 
            resources.ApplyResources(this.coordEasting, "coordEasting");
            this.coordEasting.Name = "coordEasting";
            // 
            // coordNorthing
            // 
            resources.ApplyResources(this.coordNorthing, "coordNorthing");
            this.coordNorthing.Name = "coordNorthing";
            // 
            // MGRS
            // 
            resources.ApplyResources(this.MGRS, "MGRS");
            this.MGRS.Name = "MGRS";
            // 
            // Delete
            // 
            resources.ApplyResources(this.Delete, "Delete");
            this.Delete.Name = "Delete";
            this.Delete.Text = "X";
            // 
            // Up
            // 
            this.Up.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.Up, "Up");
            this.Up.Image = ((System.Drawing.Image)(resources.GetObject("Up.Image")));
            this.Up.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Up.Name = "Up";
            // 
            // Down
            // 
            this.Down.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.Down, "Down");
            this.Down.Image = ((System.Drawing.Image)(resources.GetObject("Down.Image")));
            this.Down.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Down.Name = "Down";
            // 
            // Grad
            // 
            resources.ApplyResources(this.Grad, "Grad");
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            this.Grad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Angle
            // 
            resources.ApplyResources(this.Angle, "Angle");
            this.Angle.Name = "Angle";
            this.Angle.ReadOnly = true;
            this.Angle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Dist
            // 
            resources.ApplyResources(this.Dist, "Dist");
            this.Dist.Name = "Dist";
            this.Dist.ReadOnly = true;
            this.Dist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AZ
            // 
            resources.ApplyResources(this.AZ, "AZ");
            this.AZ.Name = "AZ";
            this.AZ.ReadOnly = true;
            this.AZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TagData
            // 
            resources.ApplyResources(this.TagData, "TagData");
            this.TagData.Name = "TagData";
            this.TagData.ReadOnly = true;
            // 
            // FlightPlanner
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelBASE);
            resources.ApplyResources(this, "$this");
            this.Name = "FlightPlanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlightPlanner_FormClosing);
            this.Load += new System.EventHandler(this.FlightPlanner_Load);
            this.Resize += new System.EventHandler(this.Planner_Resize);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelWaypoints.ResumeLayout(false);
            this.panelWaypoints.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMap.ResumeLayout(false);
            this.panelMap.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelBASE.ResumeLayout(false);
            this.contextMenuStripPoly.ResumeLayout(false);
            this.contextMenuStripZoom.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).EndInit();
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.ToolStripMenuItem addPolygonPointToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem addPolygonPointToolStripMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Angle;
        public System.Windows.Forms.ToolStripMenuItem areaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem areaToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem areaToolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem autoWPToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn AZ;
        public MissionPlanner.Controls.MyButton BUT_Add;
        public MissionPlanner.Controls.MyButton BUT_loadwpfile;
        public MissionPlanner.Controls.MyButton but_mincommands;
        public MissionPlanner.Controls.MyButton BUT_read;
        public MissionPlanner.Controls.MyButton BUT_saveWPFile;
        public MissionPlanner.Controls.MyButton BUT_write;
        public MissionPlanner.Controls.MyButton but_writewpfast;
        public System.Windows.Forms.CheckBox chk_grid;
        public System.Windows.Forms.CheckBox CHK_splinedefault;
        public System.Windows.Forms.CheckBox CHK_verifyheight;
        public System.Windows.Forms.ToolStripMenuItem clearMissionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearPolygonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearPolygonToolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem clearRallyPointsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        public System.Windows.Forms.ComboBox CMB_altmode;
        public System.Windows.Forms.ComboBox cmb_missiontype;
        public System.Windows.Forms.ComboBox comboBoxMapType;
        public System.Windows.Forms.DataGridViewComboBoxColumn Command;
        public MissionPlanner.Controls.MyDataGridView Commands;
        public System.Windows.Forms.ToolStripMenuItem ContextMeasure;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripPoly;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripZoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordEasting;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordNorthing;
        public MissionPlanner.Controls.Coords coords1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordZone;
        public System.Windows.Forms.ToolStripMenuItem createCircleSurveyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem createSplineCircleToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem createWpCircleToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem currentPositionToolStripMenuItem;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        public System.Windows.Forms.ToolStripMenuItem deleteWPToolStripMenuItem;
        public System.Windows.Forms.DataGridViewTextBoxColumn Dist;
        private System.Windows.Forms.DataGridViewImageColumn Down;
        public System.Windows.Forms.ToolStripMenuItem drawAPolygonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem elevationGraphToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem enterUTMCoordToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem fenceExclusionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem fenceInclusionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem fileLoadSaveToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn Frame;
        public System.Windows.Forms.ToolStripMenuItem fromSHPToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem fromSHPToolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem GeoFencedownloadToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem geoFenceToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem GeoFenceuploadToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem getRallyPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoToThisWPToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        public System.Windows.Forms.ToolStripMenuItem insertSplineWPToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem insertWpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem jumpstartToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem jumpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem jumpwPToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem kMLOverlayToolStripMenuItem;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.LinkLabel label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ToolStripMenuItem landToolStripMenuItem;
        public System.Windows.Forms.DataGridViewTextBoxColumn Lat;
        public System.Windows.Forms.Label LBL_defalutalt;
        public System.Windows.Forms.Label lbl_distance;
        public System.Windows.Forms.Label lbl_homedist;
        public System.Windows.Forms.Label lbl_prevdist;
        public System.Windows.Forms.Label lbl_status;
        public System.Windows.Forms.Label lbl_wpfile;
        public System.Windows.Forms.Label LBL_WPRad;
        public System.Windows.Forms.LinkLabel lnk_kml;
        public System.Windows.Forms.ToolStripMenuItem loadAndAppendToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem loadKMLFileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadPolygonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadPolygonToolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem loadSHPFileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadWPFileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loitercirclesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loiterForeverToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loitertimeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loiterToolStripMenuItem;
        public System.Windows.Forms.DataGridViewTextBoxColumn Lon;
        public MissionPlanner.Controls.myGMAP MainMap;
        public MissionPlanner.Controls.MainMenuWidget mainMenuWidget1;
        public System.Windows.Forms.ToolStripMenuItem mapToolToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MGRS;
        public System.Windows.Forms.ToolStripMenuItem modifyAltToolStripMenuItem;
        public MissionPlanner.Controls.NewControls.NotificationControl notificationControl1;
        public MissionPlanner.Controls.NewControls.NotificationListControl notificationListControl1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel panelBASE;
        public System.Windows.Forms.Panel panelMap;
        public System.Windows.Forms.Panel panelWaypoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param4;
        public System.Windows.Forms.ToolStripMenuItem poiaddToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem poideleteToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem poieditToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pOIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem prefetchToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem prefetchWPPathToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem rallyPointsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem reverseWPsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem rotateMapToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem rTLToolStripMenuItem;
        public MissionPlanner.Controls.NewControls.RulerControl rulerControl1;
        public System.Windows.Forms.ToolStripMenuItem savePolygonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem savePolygonToolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem saveRallyPointsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem saveWPFileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem setHomeHereToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem setRallyPointToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem setReturnLocationToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem setROIToolStripMenuItem;
        public System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.ToolStripMenuItem surveyGridToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem switchDockingToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagData;
        public System.Windows.Forms.ToolStripMenuItem takeoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolTip toolTip1;
        public MissionPlanner.Controls.MyTrackBar trackBar1;
        public System.Windows.Forms.ToolStripMenuItem trackerHomeToolStripMenuItem;
        public System.Windows.Forms.TextBox TXT_altwarn;
        public System.Windows.Forms.TextBox TXT_DefaultAlt;
        public System.Windows.Forms.TextBox TXT_homealt;
        public System.Windows.Forms.TextBox TXT_homelat;
        public System.Windows.Forms.TextBox TXT_homelng;
        public System.Windows.Forms.TextBox TXT_loiterrad;
        public System.Windows.Forms.TextBox TXT_WPRad;
        private System.Windows.Forms.DataGridViewImageColumn Up;
        public MissionPlanner.Controls.NewControls.WPMenu wpMenu1;
        private System.Windows.Forms.ToolStripMenuItem zoomToHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToMissionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem zoomToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зажатьЭтуТочкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;

        #endregion
    }
}