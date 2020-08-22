using System;
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
        private IContainer components = null;

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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainV2));
            this.MainMenu = new MenuStrip();
            this.CTX_mainmenu = new ContextMenuStrip(this.components);
            this.autoHideToolStripMenuItem = new ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new ToolStripMenuItem();
            this.readonlyToolStripMenuItem = new ToolStripMenuItem();
            this.connectionOptionsToolStripMenuItem = new ToolStripMenuItem();
            this.connectionListToolStripMenuItem = new ToolStripMenuItem();
            this.MenuFlightData = new ToolStripButton();
            this.MenuFlightPlanner = new ToolStripButton();
            this.MenuInitConfig = new ToolStripButton();
            this.MenuConfigTune = new ToolStripButton();
            this.MenuSimulation = new ToolStripButton();
            this.MenuHelp = new ToolStripButton();
            this.MenuConnect = new ToolStripButton();
            this.toolStripConnectionControl = new ToolStripConnectionControl();
            this.MenuArduPilot = new ToolStripButton();
            this.panel1 = new Panel();
            this.myButton3 = new MyButton();
            this.myButton2 = new MyButton();
            this.myButton1 = new MyButton();
            this.label12 = new Label();
            this.label11 = new Label();
            this.label10 = new Label();
            this.label9 = new Label();
            this.label8 = new Label();
            this.verticalProgressBar6 = new VerticalProgressBar();
            this.verticalProgressBar5 = new VerticalProgressBar();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label4 = new Label();
            this.verticalProgressBar4 = new VerticalProgressBar();
            this.verticalProgressBar3 = new VerticalProgressBar();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.verticalProgressBar2 = new VerticalProgressBar();
            this.verticalProgressBar1 = new VerticalProgressBar();
            this.status1 = new Status();
            this.menuStrip1 = new MenuStrip();
            this.label14 = new Label();
            this.toolStripButton1 = new ToolStripButton();
            this.toolStripButton3 = new ToolStripButton();
            this.toolStripButton2 = new ToolStripButton();
            this.toolStripButton4 = new ToolStripButton();
            this.toolStripButton5 = new ToolStripButton();
            this.toolStripButton6 = new ToolStripButton();
            this.toolStripButton7 = new ToolStripButton();
            this.toolStripButton8 = new ToolStripButton();
            this.menu = new MyButton();
            this.label13 = new Label();
            this.toolStripConnectionControl1 = new ToolStripConnectionControl();
            this.MainMenu.SuspendLayout();
            this.CTX_mainmenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.ContextMenuStrip = this.CTX_mainmenu;
            this.MainMenu.GripMargin = new Padding(0);
            this.MainMenu.ImageScalingSize = new Size(45, 39);
            this.MainMenu.Items.AddRange(new ToolStripItem[] {
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
            this.MainMenu.ItemClicked += new ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            this.MainMenu.MouseLeave += new EventHandler(this.MainMenu_MouseLeave);
            // 
            // CTX_mainmenu
            // 
            this.CTX_mainmenu.Items.AddRange(new ToolStripItem[] {
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
            this.autoHideToolStripMenuItem.Click += new EventHandler(this.autoHideToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.CheckOnClick = true;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
            this.fullScreenToolStripMenuItem.Click += new EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // readonlyToolStripMenuItem
            // 
            this.readonlyToolStripMenuItem.CheckOnClick = true;
            this.readonlyToolStripMenuItem.Name = "readonlyToolStripMenuItem";
            resources.ApplyResources(this.readonlyToolStripMenuItem, "readonlyToolStripMenuItem");
            this.readonlyToolStripMenuItem.Click += new EventHandler(this.readonlyToolStripMenuItem_Click);
            // 
            // connectionOptionsToolStripMenuItem
            // 
            this.connectionOptionsToolStripMenuItem.Name = "connectionOptionsToolStripMenuItem";
            resources.ApplyResources(this.connectionOptionsToolStripMenuItem, "connectionOptionsToolStripMenuItem");
            this.connectionOptionsToolStripMenuItem.Click += new EventHandler(this.connectionOptionsToolStripMenuItem_Click);
            // 
            // connectionListToolStripMenuItem
            // 
            this.connectionListToolStripMenuItem.Name = "connectionListToolStripMenuItem";
            resources.ApplyResources(this.connectionListToolStripMenuItem, "connectionListToolStripMenuItem");
            this.connectionListToolStripMenuItem.Click += new EventHandler(this.connectionListToolStripMenuItem_Click);
            // 
            // MenuFlightData
            // 
            this.MenuFlightData.ForeColor = SystemColors.ControlLight;
            resources.ApplyResources(this.MenuFlightData, "MenuFlightData");
            this.MenuFlightData.Margin = new Padding(0);
            this.MenuFlightData.Name = "MenuFlightData";
            this.MenuFlightData.Click += new EventHandler(this.MenuFlightData_Click);
            // 
            // MenuFlightPlanner
            // 
            this.MenuFlightPlanner.ForeColor = SystemColors.ControlLight;
            resources.ApplyResources(this.MenuFlightPlanner, "MenuFlightPlanner");
            this.MenuFlightPlanner.Margin = new Padding(0);
            this.MenuFlightPlanner.Name = "MenuFlightPlanner";
            this.MenuFlightPlanner.Click += new EventHandler(this.MenuFlightPlanner_Click);
            // 
            // MenuInitConfig
            // 
            this.MenuInitConfig.ForeColor = SystemColors.ControlLight;
            resources.ApplyResources(this.MenuInitConfig, "MenuInitConfig");
            this.MenuInitConfig.Margin = new Padding(0);
            this.MenuInitConfig.Name = "MenuInitConfig";
            this.MenuInitConfig.Click += new EventHandler(this.MenuSetup_Click);
            // 
            // MenuConfigTune
            // 
            this.MenuConfigTune.ForeColor = SystemColors.ControlLight;
            resources.ApplyResources(this.MenuConfigTune, "MenuConfigTune");
            this.MenuConfigTune.Margin = new Padding(0);
            this.MenuConfigTune.Name = "MenuConfigTune";
            this.MenuConfigTune.Click += new EventHandler(this.MenuTuning_Click);
            // 
            // MenuSimulation
            // 
            this.MenuSimulation.ForeColor = SystemColors.ControlLight;
            resources.ApplyResources(this.MenuSimulation, "MenuSimulation");
            this.MenuSimulation.Margin = new Padding(0);
            this.MenuSimulation.Name = "MenuSimulation";
            this.MenuSimulation.Click += new EventHandler(this.MenuSimulation_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.ForeColor = SystemColors.ControlLight;
            resources.ApplyResources(this.MenuHelp, "MenuHelp");
            this.MenuHelp.Margin = new Padding(0);
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Click += new EventHandler(this.MenuHelp_Click);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = ToolStripItemAlignment.Right;
            this.MenuConnect.ForeColor = SystemColors.ControlLight;
            resources.ApplyResources(this.MenuConnect, "MenuConnect");
            this.MenuConnect.Margin = new Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Click += new EventHandler(this.MenuConnect_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.ForeColor = Color.Black;
            this.toolStripConnectionControl.Margin = new Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.MouseLeave += new EventHandler(this.MainMenu_MouseLeave);
            // 
            // MenuArduPilot
            // 
            this.MenuArduPilot.Alignment = ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuArduPilot, "MenuArduPilot");
            this.MenuArduPilot.BackColor = Color.Transparent;
            this.MenuArduPilot.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.MenuArduPilot.ForeColor = Color.White;
            this.MenuArduPilot.Margin = new Padding(0);
            this.MenuArduPilot.Name = "MenuArduPilot";
            this.MenuArduPilot.Click += new EventHandler(this.MenuArduPilot_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myButton3);
            this.panel1.Controls.Add(this.myButton2);
            this.panel1.Controls.Add(this.myButton1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.verticalProgressBar6);
            this.panel1.Controls.Add(this.verticalProgressBar5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.verticalProgressBar4);
            this.panel1.Controls.Add(this.verticalProgressBar3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.verticalProgressBar2);
            this.panel1.Controls.Add(this.verticalProgressBar1);
            this.panel1.Controls.Add(this.status1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.MainMenu);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.MouseLeave += new EventHandler(this.MainMenu_MouseLeave);
            // 
            // myButton3
            // 
            resources.ApplyResources(this.myButton3, "myButton3");
            this.myButton3.Name = "myButton3";
            this.myButton3.UseVisualStyleBackColor = true;
            this.myButton3.Click += new EventHandler(this.myButton3_Click);
            // 
            // myButton2
            // 
            resources.ApplyResources(this.myButton2, "myButton2");
            this.myButton2.Name = "myButton2";
            this.myButton2.UseVisualStyleBackColor = true;
            // 
            // myButton1
            // 
            resources.ApplyResources(this.myButton1, "myButton1");
            this.myButton1.Name = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // verticalProgressBar6
            // 
            this.verticalProgressBar6.DrawLabel = true;
            resources.ApplyResources(this.verticalProgressBar6, "verticalProgressBar6");
            this.verticalProgressBar6.Label = null;
            this.verticalProgressBar6.maxline = 0;
            this.verticalProgressBar6.minline = 0;
            this.verticalProgressBar6.Name = "verticalProgressBar6";
            this.verticalProgressBar6.Value = 20;
            // 
            // verticalProgressBar5
            // 
            this.verticalProgressBar5.DrawLabel = true;
            resources.ApplyResources(this.verticalProgressBar5, "verticalProgressBar5");
            this.verticalProgressBar5.Label = null;
            this.verticalProgressBar5.maxline = 0;
            this.verticalProgressBar5.minline = 0;
            this.verticalProgressBar5.Name = "verticalProgressBar5";
            this.verticalProgressBar5.Value = 20;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // verticalProgressBar4
            // 
            this.verticalProgressBar4.DrawLabel = true;
            resources.ApplyResources(this.verticalProgressBar4, "verticalProgressBar4");
            this.verticalProgressBar4.Label = null;
            this.verticalProgressBar4.maxline = 0;
            this.verticalProgressBar4.minline = 0;
            this.verticalProgressBar4.Name = "verticalProgressBar4";
            this.verticalProgressBar4.Value = 20;
            // 
            // verticalProgressBar3
            // 
            this.verticalProgressBar3.DrawLabel = true;
            resources.ApplyResources(this.verticalProgressBar3, "verticalProgressBar3");
            this.verticalProgressBar3.Label = null;
            this.verticalProgressBar3.maxline = 0;
            this.verticalProgressBar3.minline = 0;
            this.verticalProgressBar3.Name = "verticalProgressBar3";
            this.verticalProgressBar3.Value = 20;
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // verticalProgressBar2
            // 
            this.verticalProgressBar2.DrawLabel = true;
            resources.ApplyResources(this.verticalProgressBar2, "verticalProgressBar2");
            this.verticalProgressBar2.Label = null;
            this.verticalProgressBar2.maxline = 0;
            this.verticalProgressBar2.minline = 0;
            this.verticalProgressBar2.Name = "verticalProgressBar2";
            this.verticalProgressBar2.Value = 20;
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.DrawLabel = true;
            resources.ApplyResources(this.verticalProgressBar1, "verticalProgressBar1");
            this.verticalProgressBar1.Label = null;
            this.verticalProgressBar1.maxline = 0;
            this.verticalProgressBar1.minline = 0;
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Value = 20;
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
            this.menuStrip1.GripMargin = new Padding(0);
            this.menuStrip1.ImageScalingSize = new Size(45, 39);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
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
            // menu
            // 
            resources.ApplyResources(this.menu, "menu");
            this.menu.Name = "menu";
            this.menu.UseVisualStyleBackColor = true;
            this.menu.MouseEnter += new EventHandler(this.menu_MouseEnter);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // toolStripConnectionControl1
            // 
            resources.ApplyResources(this.toolStripConnectionControl1, "toolStripConnectionControl1");
            this.toolStripConnectionControl1.Name = "toolStripConnectionControl1";
            // 
            // MainV2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainV2";
            this.Load += new EventHandler(this.MainV2_Load);
            this.KeyDown += new KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new EventHandler(this.MainV2_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.CTX_mainmenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ToolStripMenuItem autoHideToolStripMenuItem;
        private ToolStripMenuItem connectionListToolStripMenuItem;
        private ToolStripMenuItem connectionOptionsToolStripMenuItem;
        private ContextMenuStrip CTX_mainmenu;
        private ToolStripMenuItem fullScreenToolStripMenuItem;
        public MenuStrip MainMenu;
        private MyButton menu;
        public ToolStripButton MenuArduPilot;
        public ToolStripButton MenuConfigTune;
        public ToolStripButton MenuConnect;
        public ToolStripButton MenuFlightData;
        public ToolStripButton MenuFlightPlanner;
        public ToolStripButton MenuHelp;
        public ToolStripButton MenuInitConfig;
        public ToolStripButton MenuSimulation;
        public MenuStrip menuStrip1;
        public Panel panel1;
        private ToolStripMenuItem readonlyToolStripMenuItem;
        public Status status1;
        public ToolStripButton toolStripButton1;
        public ToolStripButton toolStripButton2;
        public ToolStripButton toolStripButton3;
        public ToolStripButton toolStripButton4;
        public ToolStripButton toolStripButton5;
        public ToolStripButton toolStripButton6;
        public ToolStripButton toolStripButton7;
        public ToolStripButton toolStripButton8;
        private ToolStripConnectionControl toolStripConnectionControl;
        private ToolStripConnectionControl toolStripConnectionControl1;

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private VerticalProgressBar verticalProgressBar2;
        private VerticalProgressBar verticalProgressBar1;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private VerticalProgressBar verticalProgressBar6;
        private VerticalProgressBar verticalProgressBar5;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private VerticalProgressBar verticalProgressBar4;
        private VerticalProgressBar verticalProgressBar3;
        private MyButton myButton2;
        private MyButton myButton1;
        private Label label13;
        private Label label14;
        private MyButton myButton3;
    }
}