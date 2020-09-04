﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MissionPlanner.Controls;

namespace MissionPlanner
{
    partial class MainV2
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
            Console.WriteLine("mainv2_Dispose");
            if (PluginThreadrunner != null)
                PluginThreadrunner.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.CTX_mainmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readonlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFlightData = new System.Windows.Forms.ToolStripButton();
            this.MenuFlightPlanner = new System.Windows.Forms.ToolStripButton();
            this.MenuInitConfig = new System.Windows.Forms.ToolStripButton();
            this.MenuConfigTune = new System.Windows.Forms.ToolStripButton();
            this.MenuSimulation = new System.Windows.Forms.ToolStripButton();
            this.MenuHelp = new System.Windows.Forms.ToolStripButton();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectionControl = new MissionPlanner.Controls.ToolStripConnectionControl();
            this.MenuArduPilot = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.status1 = new MissionPlanner.Controls.Status();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.coordinatsControl1 = new MissionPlanner.Controls.NewControls.CoordinatsControl();
            this.servoGimbal1 = new MissionPlanner.Controls.NewControls.servoGimbal();
            this.snsControl1 = new MissionPlanner.Controls.NewControls.SNSControl();
            this.myButton3 = new MissionPlanner.Controls.MyButton();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.myButton4 = new MissionPlanner.Controls.MyButton();
            this.menu = new MissionPlanner.Controls.MyButton();
            this.toolStripConnectionControl1 = new MissionPlanner.Controls.ToolStripConnectionControl();
            this.timeControl2 = new MissionPlanner.Controls.NewControls.TimeControl();
            this.MainMenu.SuspendLayout();
            this.CTX_mainmenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.ContextMenuStrip = this.CTX_mainmenu;
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(45, 39);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFlightData,
            this.MenuFlightPlanner,
            this.MenuInitConfig,
            this.MenuConfigTune,
            this.MenuSimulation,
            this.MenuHelp,
            this.MenuConnect,
            this.toolStripConnectionControl,
            this.MenuArduPilot});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.ShowItemToolTips = true;
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            this.MainMenu.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // CTX_mainmenu
            // 
            this.CTX_mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoHideToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.readonlyToolStripMenuItem,
            this.connectionOptionsToolStripMenuItem,
            this.connectionListToolStripMenuItem});
            this.CTX_mainmenu.Name = "CTX_mainmenu";
            resources.ApplyResources(this.CTX_mainmenu, "CTX_mainmenu");
            // 
            // autoHideToolStripMenuItem
            // 
            this.autoHideToolStripMenuItem.CheckOnClick = true;
            this.autoHideToolStripMenuItem.Name = "autoHideToolStripMenuItem";
            resources.ApplyResources(this.autoHideToolStripMenuItem, "autoHideToolStripMenuItem");
            this.autoHideToolStripMenuItem.Click += new System.EventHandler(this.autoHideToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.CheckOnClick = true;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // readonlyToolStripMenuItem
            // 
            this.readonlyToolStripMenuItem.CheckOnClick = true;
            this.readonlyToolStripMenuItem.Name = "readonlyToolStripMenuItem";
            resources.ApplyResources(this.readonlyToolStripMenuItem, "readonlyToolStripMenuItem");
            this.readonlyToolStripMenuItem.Click += new System.EventHandler(this.readonlyToolStripMenuItem_Click);
            // 
            // connectionOptionsToolStripMenuItem
            // 
            this.connectionOptionsToolStripMenuItem.Name = "connectionOptionsToolStripMenuItem";
            resources.ApplyResources(this.connectionOptionsToolStripMenuItem, "connectionOptionsToolStripMenuItem");
            this.connectionOptionsToolStripMenuItem.Click += new System.EventHandler(this.connectionOptionsToolStripMenuItem_Click);
            // 
            // connectionListToolStripMenuItem
            // 
            this.connectionListToolStripMenuItem.Name = "connectionListToolStripMenuItem";
            resources.ApplyResources(this.connectionListToolStripMenuItem, "connectionListToolStripMenuItem");
            this.connectionListToolStripMenuItem.Click += new System.EventHandler(this.connectionListToolStripMenuItem_Click);
            // 
            // MenuFlightData
            // 
            this.MenuFlightData.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuFlightData, "MenuFlightData");
            this.MenuFlightData.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightData.Name = "MenuFlightData";
            this.MenuFlightData.Click += new System.EventHandler(this.MenuFlightData_Click);
            // 
            // MenuFlightPlanner
            // 
            this.MenuFlightPlanner.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuFlightPlanner, "MenuFlightPlanner");
            this.MenuFlightPlanner.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlanner.Name = "MenuFlightPlanner";
            this.MenuFlightPlanner.Click += new System.EventHandler(this.MenuFlightPlanner_Click);
            // 
            // MenuInitConfig
            // 
            this.MenuInitConfig.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuInitConfig, "MenuInitConfig");
            this.MenuInitConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuInitConfig.Name = "MenuInitConfig";
            this.MenuInitConfig.Click += new System.EventHandler(this.MenuSetup_Click);
            // 
            // MenuConfigTune
            // 
            this.MenuConfigTune.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuConfigTune, "MenuConfigTune");
            this.MenuConfigTune.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConfigTune.Name = "MenuConfigTune";
            this.MenuConfigTune.Click += new System.EventHandler(this.MenuTuning_Click);
            // 
            // MenuSimulation
            // 
            this.MenuSimulation.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuSimulation, "MenuSimulation");
            this.MenuSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSimulation.Name = "MenuSimulation";
            this.MenuSimulation.Click += new System.EventHandler(this.MenuSimulation_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuHelp, "MenuHelp");
            this.MenuHelp.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuConnect.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuConnect, "MenuConnect");
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.ForeColor = System.Drawing.Color.Black;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // MenuArduPilot
            // 
            this.MenuArduPilot.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuArduPilot, "MenuArduPilot");
            this.MenuArduPilot.BackColor = System.Drawing.Color.Transparent;
            this.MenuArduPilot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuArduPilot.ForeColor = System.Drawing.Color.White;
            this.MenuArduPilot.Margin = new System.Windows.Forms.Padding(0);
            this.MenuArduPilot.Name = "MenuArduPilot";
            this.MenuArduPilot.Click += new System.EventHandler(this.MenuArduPilot_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.status1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.MainMenu);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // status1
            // 
            resources.ApplyResources(this.status1, "status1");
            this.status1.Name = "status1";
            this.status1.Percent = 0D;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ContextMenuStrip = this.CTX_mainmenu;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(45, 39);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Name = "toolStripButton3";
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Name = "toolStripButton5";
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Name = "toolStripButton6";
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Name = "toolStripButton7";
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Name = "toolStripButton8";
            resources.ApplyResources(this.toolStripButton8, "toolStripButton8");
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackgroundImage = global::MissionPlanner.Properties.Resources.bgdark;
            this.panel2.Controls.Add(this.timeControl2);
            this.panel2.Controls.Add(this.coordinatsControl1);
            this.panel2.Controls.Add(this.servoGimbal1);
            this.panel2.Controls.Add(this.snsControl1);
            this.panel2.Name = "panel2";
            // 
            // coordinatsControl1
            // 
            resources.ApplyResources(this.coordinatsControl1, "coordinatsControl1");
            this.coordinatsControl1.Name = "coordinatsControl1";
            // 
            // servoGimbal1
            // 
            resources.ApplyResources(this.servoGimbal1, "servoGimbal1");
            this.servoGimbal1.Name = "servoGimbal1";
            // 
            // snsControl1
            // 
            resources.ApplyResources(this.snsControl1, "snsControl1");
            this.snsControl1.Name = "snsControl1";
            // 
            // myButton3
            // 
            resources.ApplyResources(this.myButton3, "myButton3");
            this.myButton3.Name = "myButton3";
            this.myButton3.UseVisualStyleBackColor = true;
            this.myButton3.Click += new System.EventHandler(this.myButton3_Click);
            // 
            // myButton2
            // 
            resources.ApplyResources(this.myButton2, "myButton2");
            this.myButton2.Name = "myButton2";
            this.myButton2.UseVisualStyleBackColor = true;
            this.myButton2.Click += new System.EventHandler(this.myButton2_Click);
            // 
            // myButton1
            // 
            resources.ApplyResources(this.myButton1, "myButton1");
            this.myButton1.Name = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // myButton4
            // 
            resources.ApplyResources(this.myButton4, "myButton4");
            this.myButton4.Name = "myButton4";
            this.myButton4.UseVisualStyleBackColor = true;
            this.myButton4.Click += new System.EventHandler(this.myButton4_Click);
            // 
            // menu
            // 
            resources.ApplyResources(this.menu, "menu");
            this.menu.Name = "menu";
            this.menu.UseVisualStyleBackColor = true;
            this.menu.MouseEnter += new System.EventHandler(this.menu_MouseEnter);
            // 
            // toolStripConnectionControl1
            // 
            resources.ApplyResources(this.toolStripConnectionControl1, "toolStripConnectionControl1");
            this.toolStripConnectionControl1.Name = "toolStripConnectionControl1";
            // 
            // timeControl2
            // 
            resources.ApplyResources(this.timeControl2, "timeControl2");
            this.timeControl2.Name = "timeControl2";
            // 
            // MainV2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.myButton3);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.myButton4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainV2";
            this.Load += new System.EventHandler(this.MainV2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.CTX_mainmenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem autoHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionOptionsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CTX_mainmenu;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        public System.Windows.Forms.MenuStrip MainMenu;
        private MissionPlanner.Controls.MyButton menu;
        public System.Windows.Forms.ToolStripButton MenuArduPilot;
        public System.Windows.Forms.ToolStripButton MenuConfigTune;
        public System.Windows.Forms.ToolStripButton MenuConnect;
        public System.Windows.Forms.ToolStripButton MenuFlightData;
        public System.Windows.Forms.ToolStripButton MenuFlightPlanner;
        public System.Windows.Forms.ToolStripButton MenuHelp;
        public System.Windows.Forms.ToolStripButton MenuInitConfig;
        public System.Windows.Forms.ToolStripButton MenuSimulation;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem readonlyToolStripMenuItem;
        public MissionPlanner.Controls.Status status1;
        public System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.ToolStripButton toolStripButton3;
        public System.Windows.Forms.ToolStripButton toolStripButton4;
        public System.Windows.Forms.ToolStripButton toolStripButton5;
        public System.Windows.Forms.ToolStripButton toolStripButton6;
        public System.Windows.Forms.ToolStripButton toolStripButton7;
        public System.Windows.Forms.ToolStripButton toolStripButton8;
        private MissionPlanner.Controls.ToolStripConnectionControl toolStripConnectionControl;
        private MissionPlanner.Controls.ToolStripConnectionControl toolStripConnectionControl1;

        #endregion
        private MyButton myButton2;
        private MyButton myButton1;
        private Label label13;
        private MyButton myButton3;
        private MyButton myButton4;
        private Timer timer1;
        private Panel panel2;
        private Controls.NewControls.SNSControl snsControl1;
        private Controls.NewControls.servoGimbal servoGimbal1;
        private Controls.NewControls.CoordinatsControl coordinatsControl1;
        private Controls.NewControls.TimeControl timeControl1;
        private Controls.NewControls.TimeControl timeControl2;
    }
}