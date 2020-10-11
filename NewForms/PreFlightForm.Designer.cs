namespace MissionPlanner.NewForms
{
    partial class PreFlightForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.armButton = new MissionPlanner.Controls.MyButton();
            this.nextButton1 = new MissionPlanner.Controls.MyButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.startCalibrationButton = new MissionPlanner.Controls.MyButton();
            this.AirSpeedLabel = new System.Windows.Forms.Label();
            this.backButton1 = new MissionPlanner.Controls.MyButton();
            this.gotReaction = new MissionPlanner.Controls.MyButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.myButton7 = new MissionPlanner.Controls.MyButton();
            this.myButton5 = new MissionPlanner.Controls.MyButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxСapacity = new System.Windows.Forms.TextBox();
            this.valueInPercentsTBox = new System.Windows.Forms.TextBox();
            this.flightTimeTBox = new System.Windows.Forms.TextBox();
            this.batt2_voltage = new System.Windows.Forms.TextBox();
            this.backButton2 = new MissionPlanner.Controls.MyButton();
            this.nextButton2 = new MissionPlanner.Controls.MyButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.nextButton = new MissionPlanner.Controls.MyButton();
            this.backButton = new MissionPlanner.Controls.MyButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.myButton4 = new MissionPlanner.Controls.MyButton();
            this.myButton3 = new MissionPlanner.Controls.MyButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkListControl1 = new MissionPlanner.Controls.PreFlight.CheckListControl();
            this.iceRun1 = new MissionPlanner.Controls.NewControls.ICERun();
            this.iceCheck1 = new MissionPlanner.Controls.NewControls.ICECheck();
            this.myButton6 = new MissionPlanner.Controls.MyButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(523, 509);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabStop = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.armButton);
            this.tabPage1.Controls.Add(this.nextButton1);
            this.tabPage1.Controls.Add(this.checkListControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(515, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Предполетная подготовка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // armButton
            // 
            this.armButton.Location = new System.Drawing.Point(130, 443);
            this.armButton.Name = "armButton";
            this.armButton.Size = new System.Drawing.Size(75, 23);
            this.armButton.TabIndex = 3;
            this.armButton.Text = "Arm/Disarm";
            this.armButton.UseVisualStyleBackColor = true;
            this.armButton.Click += new System.EventHandler(this.armButton_Click);
            // 
            // nextButton1
            // 
            this.nextButton1.Location = new System.Drawing.Point(422, 443);
            this.nextButton1.Name = "nextButton1";
            this.nextButton1.Size = new System.Drawing.Size(75, 23);
            this.nextButton1.TabIndex = 2;
            this.nextButton1.Text = "Далее";
            this.nextButton1.UseVisualStyleBackColor = true;
            this.nextButton1.Click += new System.EventHandler(this.nextButton1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.startCalibrationButton);
            this.tabPage2.Controls.Add(this.AirSpeedLabel);
            this.tabPage2.Controls.Add(this.backButton1);
            this.tabPage2.Controls.Add(this.gotReaction);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(515, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Калибровка ПВД";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Воздушная скорость:";
            // 
            // startCalibrationButton
            // 
            this.startCalibrationButton.Location = new System.Drawing.Point(148, 164);
            this.startCalibrationButton.Name = "startCalibrationButton";
            this.startCalibrationButton.Size = new System.Drawing.Size(260, 57);
            this.startCalibrationButton.TabIndex = 6;
            this.startCalibrationButton.Text = "Начать калибровку ПВД";
            this.startCalibrationButton.UseVisualStyleBackColor = true;
            this.startCalibrationButton.Click += new System.EventHandler(this.startCalibrationButton_Click);
            this.startCalibrationButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.startCalibrationButton_MouseUp);
            // 
            // AirSpeedLabel
            // 
            this.AirSpeedLabel.AutoSize = true;
            this.AirSpeedLabel.Location = new System.Drawing.Point(276, 349);
            this.AirSpeedLabel.Name = "AirSpeedLabel";
            this.AirSpeedLabel.Size = new System.Drawing.Size(0, 13);
            this.AirSpeedLabel.TabIndex = 5;
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(6, 454);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(75, 23);
            this.backButton1.TabIndex = 4;
            this.backButton1.Text = "Назад";
            this.backButton1.UseVisualStyleBackColor = true;
            this.backButton1.Click += new System.EventHandler(this.backButton1_Click);
            // 
            // gotReaction
            // 
            this.gotReaction.Location = new System.Drawing.Point(419, 454);
            this.gotReaction.Name = "gotReaction";
            this.gotReaction.Size = new System.Drawing.Size(75, 23);
            this.gotReaction.TabIndex = 3;
            this.gotReaction.Text = "Есть реакция";
            this.gotReaction.UseVisualStyleBackColor = true;
            this.gotReaction.Click += new System.EventHandler(this.gotReaction_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.myButton6);
            this.tabPage3.Controls.Add(this.myButton7);
            this.tabPage3.Controls.Add(this.myButton5);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.maxСapacity);
            this.tabPage3.Controls.Add(this.valueInPercentsTBox);
            this.tabPage3.Controls.Add(this.flightTimeTBox);
            this.tabPage3.Controls.Add(this.batt2_voltage);
            this.tabPage3.Controls.Add(this.backButton2);
            this.tabPage3.Controls.Add(this.nextButton2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(515, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Заправка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // myButton7
            // 
            this.myButton7.Location = new System.Drawing.Point(355, 299);
            this.myButton7.Name = "myButton7";
            this.myButton7.Size = new System.Drawing.Size(101, 23);
            this.myButton7.TabIndex = 24;
            this.myButton7.Text = "Выставить";
            this.myButton7.UseVisualStyleBackColor = true;
            this.myButton7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton7_MouseUp);
            // 
            // myButton5
            // 
            this.myButton5.Location = new System.Drawing.Point(162, 334);
            this.myButton5.Name = "myButton5";
            this.myButton5.Size = new System.Drawing.Size(187, 23);
            this.myButton5.TabIndex = 22;
            this.myButton5.Text = "Сохранить";
            this.myButton5.UseVisualStyleBackColor = true;
            this.myButton5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton5_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Минимальная емкость бака";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 272);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(249, 197);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(161, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Выставить автоматически";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "%";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Максимальная емкость бака";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Остаток топлива";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Расход Литров./Час";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Заправка, литров";
            // 
            // maxСapacity
            // 
            this.maxСapacity.Location = new System.Drawing.Point(249, 302);
            this.maxСapacity.Name = "maxСapacity";
            this.maxСapacity.Size = new System.Drawing.Size(100, 20);
            this.maxСapacity.TabIndex = 13;
            this.maxСapacity.Text = "0";
            // 
            // valueInPercentsTBox
            // 
            this.valueInPercentsTBox.Location = new System.Drawing.Point(234, 26);
            this.valueInPercentsTBox.Name = "valueInPercentsTBox";
            this.valueInPercentsTBox.Size = new System.Drawing.Size(100, 20);
            this.valueInPercentsTBox.TabIndex = 12;
            this.valueInPercentsTBox.Visible = false;
            this.valueInPercentsTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batt2_voltage_KeyPress);
            this.valueInPercentsTBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.valueInPercentsTBox_KeyUp);
            // 
            // flightTimeTBox
            // 
            this.flightTimeTBox.Location = new System.Drawing.Point(249, 220);
            this.flightTimeTBox.Name = "flightTimeTBox";
            this.flightTimeTBox.Size = new System.Drawing.Size(100, 20);
            this.flightTimeTBox.TabIndex = 11;
            this.flightTimeTBox.Text = "0";
            this.flightTimeTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batt2_voltage_KeyPress);
            this.flightTimeTBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.valueInPercentsTBox_KeyUp);
            // 
            // batt2_voltage
            // 
            this.batt2_voltage.Location = new System.Drawing.Point(249, 171);
            this.batt2_voltage.Name = "batt2_voltage";
            this.batt2_voltage.Size = new System.Drawing.Size(100, 20);
            this.batt2_voltage.TabIndex = 6;
            this.batt2_voltage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batt2_voltage_KeyPress);
            this.batt2_voltage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.valueInPercentsTBox_KeyUp);
            // 
            // backButton2
            // 
            this.backButton2.Location = new System.Drawing.Point(24, 440);
            this.backButton2.Name = "backButton2";
            this.backButton2.Size = new System.Drawing.Size(75, 23);
            this.backButton2.TabIndex = 5;
            this.backButton2.Text = "Назад";
            this.backButton2.UseVisualStyleBackColor = true;
            this.backButton2.Click += new System.EventHandler(this.backButton2_Click);
            // 
            // nextButton2
            // 
            this.nextButton2.Location = new System.Drawing.Point(338, 440);
            this.nextButton2.Name = "nextButton2";
            this.nextButton2.Size = new System.Drawing.Size(75, 23);
            this.nextButton2.TabIndex = 4;
            this.nextButton2.Text = "Далее";
            this.nextButton2.UseVisualStyleBackColor = true;
            this.nextButton2.Click += new System.EventHandler(this.nextButton2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.nextButton);
            this.tabPage4.Controls.Add(this.backButton);
            this.tabPage4.Controls.Add(this.iceRun1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(515, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Запуск ДВС";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(347, 441);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(19, 441);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.iceCheck1);
            this.tabPage5.Controls.Add(this.myButton2);
            this.tabPage5.Controls.Add(this.myButton1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(515, 483);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Проверка";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.Location = new System.Drawing.Point(347, 445);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(75, 23);
            this.myButton2.TabIndex = 3;
            this.myButton2.Text = "Далее";
            this.myButton2.UseVisualStyleBackColor = true;
            this.myButton2.Click += new System.EventHandler(this.myButton2_Click);
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(14, 445);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(75, 23);
            this.myButton1.TabIndex = 2;
            this.myButton1.Text = "Назад";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.myButton4);
            this.tabPage6.Controls.Add(this.myButton3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(515, 483);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ПУСК";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // myButton4
            // 
            this.myButton4.Location = new System.Drawing.Point(12, 445);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(75, 23);
            this.myButton4.TabIndex = 3;
            this.myButton4.Text = "Назад";
            this.myButton4.UseVisualStyleBackColor = true;
            this.myButton4.Click += new System.EventHandler(this.myButton4_Click);
            // 
            // myButton3
            // 
            this.myButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myButton3.Location = new System.Drawing.Point(109, 113);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(230, 230);
            this.myButton3.TabIndex = 0;
            this.myButton3.Text = "ПУСК";
            this.myButton3.UseVisualStyleBackColor = true;
            this.myButton3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myButton3_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkListControl1
            // 
            this.checkListControl1.Location = new System.Drawing.Point(6, 16);
            this.checkListControl1.Name = "checkListControl1";
            this.checkListControl1.Size = new System.Drawing.Size(491, 421);
            this.checkListControl1.TabIndex = 0;
            // 
            // iceRun1
            // 
            this.iceRun1.Location = new System.Drawing.Point(3, 3);
            this.iceRun1.Name = "iceRun1";
            this.iceRun1.Size = new System.Drawing.Size(432, 432);
            this.iceRun1.TabIndex = 0;
            // 
            // iceCheck1
            // 
            this.iceCheck1.Location = new System.Drawing.Point(6, 7);
            this.iceCheck1.Name = "iceCheck1";
            this.iceCheck1.Size = new System.Drawing.Size(509, 432);
            this.iceCheck1.TabIndex = 4;
            // 
            // myButton6
            // 
            this.myButton6.Location = new System.Drawing.Point(355, 270);
            this.myButton6.Name = "myButton6";
            this.myButton6.Size = new System.Drawing.Size(101, 23);
            this.myButton6.TabIndex = 25;
            this.myButton6.Text = "Выставить";
            this.myButton6.UseVisualStyleBackColor = true;
            // 
            // PreFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 526);
            this.Controls.Add(this.tabControl1);
            this.Name = "PreFlightForm";
            this.Text = "PreFlightForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreFlightForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PreFlight.CheckListControl checkListControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private Controls.MyButton nextButton1;
        private System.Windows.Forms.Label AirSpeedLabel;
        private Controls.MyButton backButton1;
        private Controls.MyButton gotReaction;
        private System.Windows.Forms.Timer timer1;
        private Controls.MyButton backButton2;
        private Controls.MyButton nextButton2;
        private System.Windows.Forms.TextBox maxСapacity;
        private System.Windows.Forms.TextBox valueInPercentsTBox;
        private System.Windows.Forms.TextBox flightTimeTBox;
        private System.Windows.Forms.TextBox batt2_voltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox1;
        private Controls.NewControls.ICERun iceRun1;
        private Controls.MyButton backButton;
        private Controls.MyButton nextButton;
        private Controls.MyButton myButton2;
        private Controls.MyButton myButton1;
        private Controls.NewControls.ICECheck iceCheck1;
        private System.Windows.Forms.TabPage tabPage6;
        private Controls.MyButton myButton3;
        private Controls.MyButton myButton4;
        private Controls.MyButton startCalibrationButton;
        private Controls.MyButton armButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private Controls.MyButton myButton5;
        private Controls.MyButton myButton7;
        private Controls.MyButton myButton6;
    }
}