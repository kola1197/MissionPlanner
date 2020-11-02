namespace MissionPlanner.NewForms
{
    partial class WPConfig
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPConfig));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lonNotification = new System.Windows.Forms.Label();
            this.latNotification = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lonTB1 = new System.Windows.Forms.TextBox();
            this.latTB1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.myButton14 = new MissionPlanner.Controls.MyButton();
            this.myButton15 = new MissionPlanner.Controls.MyButton();
            this.myButton16 = new MissionPlanner.Controls.MyButton();
            this.myButton11 = new MissionPlanner.Controls.MyButton();
            this.myButton12 = new MissionPlanner.Controls.MyButton();
            this.myButton13 = new MissionPlanner.Controls.MyButton();
            this.myButton10 = new MissionPlanner.Controls.MyButton();
            this.myButton9 = new MissionPlanner.Controls.MyButton();
            this.myButton8 = new MissionPlanner.Controls.MyButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.myButton7 = new MissionPlanner.Controls.MyButton();
            this.myButton6 = new MissionPlanner.Controls.MyButton();
            this.myButton5 = new MissionPlanner.Controls.MyButton();
            this.myButton4 = new MissionPlanner.Controls.MyButton();
            this.myButton3 = new MissionPlanner.Controls.MyButton();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.wpAltSlidingScale1 = new MissionPlanner.Controls.NewControls.WpAltSlidingScale();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 260);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tabPage1.Controls.Add(this.lonNotification);
            this.tabPage1.Controls.Add(this.latNotification);
            this.tabPage1.Controls.Add(this.wpAltSlidingScale1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lonTB1);
            this.tabPage1.Controls.Add(this.latTB1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основные:";
            // 
            // lonNotification
            // 
            this.lonNotification.AutoSize = true;
            this.lonNotification.ForeColor = System.Drawing.Color.Red;
            this.lonNotification.Location = new System.Drawing.Point(190, 48);
            this.lonNotification.Name = "lonNotification";
            this.lonNotification.Size = new System.Drawing.Size(121, 13);
            this.lonNotification.TabIndex = 16;
            this.lonNotification.Text = "Данные не корректны";
            this.lonNotification.Visible = false;
            // 
            // latNotification
            // 
            this.latNotification.AutoSize = true;
            this.latNotification.ForeColor = System.Drawing.Color.Red;
            this.latNotification.Location = new System.Drawing.Point(189, 22);
            this.latNotification.Name = "latNotification";
            this.latNotification.Size = new System.Drawing.Size(121, 13);
            this.latNotification.TabIndex = 15;
            this.latNotification.Text = "Данные не корректны";
            this.latNotification.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(192, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Км/ч";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(25, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Скорость:";
            this.label10.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(84, 112);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Точка дом",
            "Точка взлета",
            "Маршрутная точка",
            "Изменение скорости",
            "Точка посадки",
            "Точка Rally"});
            this.comboBox1.Location = new System.Drawing.Point(84, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тип:";
            // 
            // lonTB1
            // 
            this.lonTB1.Location = new System.Drawing.Point(84, 45);
            this.lonTB1.Name = "lonTB1";
            this.lonTB1.Size = new System.Drawing.Size(100, 20);
            this.lonTB1.TabIndex = 3;
            this.lonTB1.TextChanged += new System.EventHandler(this.lonTB1_TextChanged);
            // 
            // latTB1
            // 
            this.latTB1.Location = new System.Drawing.Point(84, 19);
            this.latTB1.Name = "latTB1";
            this.latTB1.Size = new System.Drawing.Size(100, 20);
            this.latTB1.TabIndex = 2;
            this.latTB1.TextChanged += new System.EventHandler(this.latTB1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Долгота:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Широта:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.myButton14);
            this.tabPage2.Controls.Add(this.myButton15);
            this.tabPage2.Controls.Add(this.myButton16);
            this.tabPage2.Controls.Add(this.myButton11);
            this.tabPage2.Controls.Add(this.myButton12);
            this.tabPage2.Controls.Add(this.myButton13);
            this.tabPage2.Controls.Add(this.myButton10);
            this.tabPage2.Controls.Add(this.myButton9);
            this.tabPage2.Controls.Add(this.myButton8);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.myButton7);
            this.tabPage2.Controls.Add(this.myButton6);
            this.tabPage2.Controls.Add(this.myButton5);
            this.tabPage2.Controls.Add(this.myButton4);
            this.tabPage2.Controls.Add(this.myButton3);
            this.tabPage2.Controls.Add(this.myButton2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 234);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Дополнительно";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(226, 206);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(184, 20);
            this.textBox4.TabIndex = 29;
            this.textBox4.Text = "500";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(18, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Включать при расстоянии до точки, м:";
            // 
            // myButton14
            // 
            this.myButton14.BGGradBot = System.Drawing.Color.Empty;
            this.myButton14.BGGradTop = System.Drawing.Color.Empty;
            this.myButton14.DefaultTheme = false;
            this.myButton14.Location = new System.Drawing.Point(286, 169);
            this.myButton14.Name = "myButton14";
            this.myButton14.Outline = System.Drawing.Color.Black;
            this.myButton14.Size = new System.Drawing.Size(126, 25);
            this.myButton14.TabIndex = 27;
            this.myButton14.Text = "9";
            this.myButton14.TextColor = System.Drawing.Color.White;
            this.myButton14.UseVisualStyleBackColor = true;
            this.myButton14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton14_MouseUp);
            // 
            // myButton15
            // 
            this.myButton15.BGGradBot = System.Drawing.Color.Empty;
            this.myButton15.BGGradTop = System.Drawing.Color.Empty;
            this.myButton15.DefaultTheme = false;
            this.myButton15.Location = new System.Drawing.Point(154, 169);
            this.myButton15.Name = "myButton15";
            this.myButton15.Outline = System.Drawing.Color.Black;
            this.myButton15.Size = new System.Drawing.Size(126, 25);
            this.myButton15.TabIndex = 26;
            this.myButton15.Text = "8";
            this.myButton15.TextColor = System.Drawing.Color.White;
            this.myButton15.UseVisualStyleBackColor = true;
            this.myButton15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton15_MouseUp);
            // 
            // myButton16
            // 
            this.myButton16.BGGradBot = System.Drawing.Color.Empty;
            this.myButton16.BGGradTop = System.Drawing.Color.Empty;
            this.myButton16.DefaultTheme = false;
            this.myButton16.Location = new System.Drawing.Point(21, 169);
            this.myButton16.Name = "myButton16";
            this.myButton16.Outline = System.Drawing.Color.Black;
            this.myButton16.Size = new System.Drawing.Size(127, 25);
            this.myButton16.TabIndex = 25;
            this.myButton16.Text = "7";
            this.myButton16.TextColor = System.Drawing.Color.White;
            this.myButton16.UseVisualStyleBackColor = true;
            this.myButton16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton16_MouseUp);
            // 
            // myButton11
            // 
            this.myButton11.BGGradBot = System.Drawing.Color.Empty;
            this.myButton11.BGGradTop = System.Drawing.Color.Empty;
            this.myButton11.DefaultTheme = false;
            this.myButton11.Location = new System.Drawing.Point(286, 138);
            this.myButton11.Name = "myButton11";
            this.myButton11.Outline = System.Drawing.Color.Black;
            this.myButton11.Size = new System.Drawing.Size(126, 25);
            this.myButton11.TabIndex = 24;
            this.myButton11.Text = "6";
            this.myButton11.TextColor = System.Drawing.Color.White;
            this.myButton11.UseVisualStyleBackColor = true;
            this.myButton11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton11_MouseUp);
            // 
            // myButton12
            // 
            this.myButton12.BGGradBot = System.Drawing.Color.Empty;
            this.myButton12.BGGradTop = System.Drawing.Color.Empty;
            this.myButton12.DefaultTheme = false;
            this.myButton12.Location = new System.Drawing.Point(154, 138);
            this.myButton12.Name = "myButton12";
            this.myButton12.Outline = System.Drawing.Color.Black;
            this.myButton12.Size = new System.Drawing.Size(126, 25);
            this.myButton12.TabIndex = 23;
            this.myButton12.Text = "5";
            this.myButton12.TextColor = System.Drawing.Color.White;
            this.myButton12.UseVisualStyleBackColor = true;
            this.myButton12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton12_MouseUp);
            // 
            // myButton13
            // 
            this.myButton13.BGGradBot = System.Drawing.Color.Empty;
            this.myButton13.BGGradTop = System.Drawing.Color.Empty;
            this.myButton13.DefaultTheme = false;
            this.myButton13.Location = new System.Drawing.Point(21, 138);
            this.myButton13.Name = "myButton13";
            this.myButton13.Outline = System.Drawing.Color.Black;
            this.myButton13.Size = new System.Drawing.Size(127, 25);
            this.myButton13.TabIndex = 22;
            this.myButton13.Text = "4";
            this.myButton13.TextColor = System.Drawing.Color.White;
            this.myButton13.UseVisualStyleBackColor = true;
            this.myButton13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton13_MouseUp);
            // 
            // myButton10
            // 
            this.myButton10.BGGradBot = System.Drawing.Color.Empty;
            this.myButton10.BGGradTop = System.Drawing.Color.Empty;
            this.myButton10.DefaultTheme = false;
            this.myButton10.Location = new System.Drawing.Point(286, 107);
            this.myButton10.Name = "myButton10";
            this.myButton10.Outline = System.Drawing.Color.Black;
            this.myButton10.Size = new System.Drawing.Size(126, 25);
            this.myButton10.TabIndex = 21;
            this.myButton10.Text = "3";
            this.myButton10.TextColor = System.Drawing.Color.White;
            this.myButton10.UseVisualStyleBackColor = true;
            this.myButton10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton10_MouseUp);
            // 
            // myButton9
            // 
            this.myButton9.BGGradBot = System.Drawing.Color.Empty;
            this.myButton9.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton9.DefaultTheme = false;
            this.myButton9.Location = new System.Drawing.Point(154, 107);
            this.myButton9.Name = "myButton9";
            this.myButton9.Outline = System.Drawing.Color.Black;
            this.myButton9.Size = new System.Drawing.Size(126, 25);
            this.myButton9.TabIndex = 20;
            this.myButton9.Text = "2";
            this.myButton9.TextColor = System.Drawing.Color.White;
            this.myButton9.UseVisualStyleBackColor = true;
            this.myButton9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton9_MouseUp);
            // 
            // myButton8
            // 
            this.myButton8.BGGradBot = System.Drawing.Color.Transparent;
            this.myButton8.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton8.DefaultTheme = false;
            this.myButton8.Location = new System.Drawing.Point(21, 107);
            this.myButton8.Name = "myButton8";
            this.myButton8.Outline = System.Drawing.Color.Black;
            this.myButton8.Size = new System.Drawing.Size(127, 25);
            this.myButton8.TabIndex = 19;
            this.myButton8.Text = "1";
            this.myButton8.TextColor = System.Drawing.Color.White;
            this.myButton8.UseVisualStyleBackColor = true;
            this.myButton8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton8_MouseUp);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(21, 84);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(164, 17);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Включить нагрузки в точке";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // myButton7
            // 
            this.myButton7.BGGradBot = System.Drawing.Color.Empty;
            this.myButton7.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton7.DefaultTheme = false;
            this.myButton7.Location = new System.Drawing.Point(352, 55);
            this.myButton7.Name = "myButton7";
            this.myButton7.Outline = System.Drawing.Color.Black;
            this.myButton7.Size = new System.Drawing.Size(60, 25);
            this.myButton7.TabIndex = 17;
            this.myButton7.Text = "60";
            this.myButton7.TextColor = System.Drawing.Color.White;
            this.myButton7.UseVisualStyleBackColor = true;
            this.myButton7.Click += new System.EventHandler(this.myButton7_Click);
            // 
            // myButton6
            // 
            this.myButton6.BGGradBot = System.Drawing.Color.Empty;
            this.myButton6.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton6.DefaultTheme = false;
            this.myButton6.Location = new System.Drawing.Point(286, 55);
            this.myButton6.Name = "myButton6";
            this.myButton6.Outline = System.Drawing.Color.Black;
            this.myButton6.Size = new System.Drawing.Size(60, 25);
            this.myButton6.TabIndex = 16;
            this.myButton6.Text = "30";
            this.myButton6.TextColor = System.Drawing.Color.White;
            this.myButton6.UseVisualStyleBackColor = true;
            this.myButton6.Click += new System.EventHandler(this.myButton6_Click);
            // 
            // myButton5
            // 
            this.myButton5.BGGradBot = System.Drawing.Color.Empty;
            this.myButton5.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton5.DefaultTheme = false;
            this.myButton5.Location = new System.Drawing.Point(220, 55);
            this.myButton5.Name = "myButton5";
            this.myButton5.Outline = System.Drawing.Color.Black;
            this.myButton5.Size = new System.Drawing.Size(60, 25);
            this.myButton5.TabIndex = 15;
            this.myButton5.Text = "20";
            this.myButton5.TextColor = System.Drawing.Color.White;
            this.myButton5.UseVisualStyleBackColor = true;
            this.myButton5.Click += new System.EventHandler(this.myButton5_Click);
            // 
            // myButton4
            // 
            this.myButton4.BGGradBot = System.Drawing.Color.Empty;
            this.myButton4.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton4.DefaultTheme = false;
            this.myButton4.Location = new System.Drawing.Point(154, 55);
            this.myButton4.Name = "myButton4";
            this.myButton4.Outline = System.Drawing.Color.Black;
            this.myButton4.Size = new System.Drawing.Size(60, 25);
            this.myButton4.TabIndex = 14;
            this.myButton4.Text = "10";
            this.myButton4.TextColor = System.Drawing.Color.White;
            this.myButton4.UseVisualStyleBackColor = true;
            this.myButton4.Click += new System.EventHandler(this.myButton4_Click);
            // 
            // myButton3
            // 
            this.myButton3.BGGradBot = System.Drawing.Color.Empty;
            this.myButton3.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton3.DefaultTheme = false;
            this.myButton3.Location = new System.Drawing.Point(88, 55);
            this.myButton3.Name = "myButton3";
            this.myButton3.Outline = System.Drawing.Color.Black;
            this.myButton3.Size = new System.Drawing.Size(60, 25);
            this.myButton3.TabIndex = 13;
            this.myButton3.Text = "5";
            this.myButton3.TextColor = System.Drawing.Color.White;
            this.myButton3.UseVisualStyleBackColor = true;
            this.myButton3.Click += new System.EventHandler(this.myButton3_Click);
            // 
            // myButton2
            // 
            this.myButton2.BGGradBot = System.Drawing.Color.Transparent;
            this.myButton2.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton2.DefaultTheme = false;
            this.myButton2.Location = new System.Drawing.Point(21, 55);
            this.myButton2.Name = "myButton2";
            this.myButton2.Outline = System.Drawing.Color.Black;
            this.myButton2.Size = new System.Drawing.Size(60, 25);
            this.myButton2.TabIndex = 12;
            this.myButton2.Text = "1";
            this.myButton2.TextColor = System.Drawing.Color.White;
            this.myButton2.UseVisualStyleBackColor = true;
            this.myButton2.Click += new System.EventHandler(this.myButton2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(372, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "минут";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(345, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(21, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(162, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Удерживать БПЛА в точке";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myButton1
            // 
            this.myButton1.BGGradBot = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton1.BGGradTop = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.myButton1.DefaultTheme = false;
            this.myButton1.Location = new System.Drawing.Point(12, 278);
            this.myButton1.Name = "myButton1";
            this.myButton1.Outline = System.Drawing.Color.Black;
            this.myButton1.Size = new System.Drawing.Size(463, 23);
            this.myButton1.TabIndex = 1;
            this.myButton1.Text = "Готово";
            this.myButton1.TextColor = System.Drawing.Color.Black;
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // wpAltSlidingScale1
            // 
            this.wpAltSlidingScale1.Location = new System.Drawing.Point(316, 3);
            this.wpAltSlidingScale1.Name = "wpAltSlidingScale1";
            this.wpAltSlidingScale1.Size = new System.Drawing.Size(133, 228);
            this.wpAltSlidingScale1.TabIndex = 14;
            // 
            // WPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(479, 313);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WPConfig";
            this.Text = "WPConfig";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private MissionPlanner.Controls.MyButton myButton1;
        private MissionPlanner.Controls.MyButton myButton10;
        private MissionPlanner.Controls.MyButton myButton11;
        private MissionPlanner.Controls.MyButton myButton12;
        private MissionPlanner.Controls.MyButton myButton13;
        private MissionPlanner.Controls.MyButton myButton14;
        private MissionPlanner.Controls.MyButton myButton15;
        private MissionPlanner.Controls.MyButton myButton16;
        private MissionPlanner.Controls.MyButton myButton2;
        private MissionPlanner.Controls.MyButton myButton3;
        private MissionPlanner.Controls.MyButton myButton4;
        private MissionPlanner.Controls.MyButton myButton5;
        private MissionPlanner.Controls.MyButton myButton6;
        private MissionPlanner.Controls.MyButton myButton7;
        private MissionPlanner.Controls.MyButton myButton8;
        private MissionPlanner.Controls.MyButton myButton9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TextBox latTB1;
        public System.Windows.Forms.TextBox lonTB1;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Timer timer1;
        public MissionPlanner.Controls.NewControls.WpAltSlidingScale wpAltSlidingScale1;

        #endregion

        private System.Windows.Forms.Label lonNotification;
        private System.Windows.Forms.Label latNotification;
    }
}