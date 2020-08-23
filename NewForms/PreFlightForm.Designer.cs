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
            this.checkListControl1 = new MissionPlanner.Controls.PreFlight.CheckListControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.nextButton1 = new MissionPlanner.Controls.MyButton();
            this.gotReaction = new MissionPlanner.Controls.MyButton();
            this.backButton1 = new MissionPlanner.Controls.MyButton();
            this.AirSpeedLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkListControl1
            // 
            this.checkListControl1.Location = new System.Drawing.Point(6, 16);
            this.checkListControl1.Name = "checkListControl1";
            this.checkListControl1.Size = new System.Drawing.Size(426, 421);
            this.checkListControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(446, 509);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabStop = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nextButton1);
            this.tabPage1.Controls.Add(this.checkListControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(438, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Предполетная подготовка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AirSpeedLabel);
            this.tabPage2.Controls.Add(this.backButton1);
            this.tabPage2.Controls.Add(this.gotReaction);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(438, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Калибровка ПВД";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(438, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Заправка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(438, 443);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Запуск ДВС";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(438, 443);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Проверка";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // nextButton1
            // 
            this.nextButton1.Location = new System.Drawing.Point(357, 454);
            this.nextButton1.Name = "nextButton1";
            this.nextButton1.Size = new System.Drawing.Size(75, 23);
            this.nextButton1.TabIndex = 2;
            this.nextButton1.Text = "Далее";
            this.nextButton1.UseVisualStyleBackColor = true;
            this.nextButton1.Click += new System.EventHandler(this.nextButton1_Click);
            // 
            // gotReaction
            // 
            this.gotReaction.Location = new System.Drawing.Point(357, 454);
            this.gotReaction.Name = "gotReaction";
            this.gotReaction.Size = new System.Drawing.Size(75, 23);
            this.gotReaction.TabIndex = 3;
            this.gotReaction.Text = "Есть реакция";
            this.gotReaction.UseVisualStyleBackColor = true;
            this.gotReaction.Click += new System.EventHandler(this.gotReaction_Click);
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
            // AirSpeedLabel
            // 
            this.AirSpeedLabel.AutoSize = true;
            this.AirSpeedLabel.Location = new System.Drawing.Point(193, 186);
            this.AirSpeedLabel.Name = "AirSpeedLabel";
            this.AirSpeedLabel.Size = new System.Drawing.Size(0, 13);
            this.AirSpeedLabel.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PreFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 526);
            this.Controls.Add(this.tabControl1);
            this.Name = "PreFlightForm";
            this.Text = "PreFlightForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
    }
}