namespace MissionPlanner.Controls
{
    partial class AircraftMenuControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.aircraft_BUT1 = new MissionPlanner.Controls.MyButton();
            this.aircraft_BUT2 = new MissionPlanner.Controls.MyButton();
            this.aircraft_BUT3 = new MissionPlanner.Controls.MyButton();
            this.aircraft_BUT4 = new MissionPlanner.Controls.MyButton();
            this.centerButton = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // aircraft_BUT1
            // 
            this.aircraft_BUT1.Location = new System.Drawing.Point(0, 0);
            this.aircraft_BUT1.Name = "aircraft_BUT1";
            this.aircraft_BUT1.Size = new System.Drawing.Size(75, 23);
            this.aircraft_BUT1.TabIndex = 0;
            this.aircraft_BUT1.Text = "1";
            this.aircraft_BUT1.UseVisualStyleBackColor = true;
            this.aircraft_BUT1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.aircraft_BUT1_MouseClick);
            // 
            // aircraft_BUT2
            // 
            this.aircraft_BUT2.Location = new System.Drawing.Point(123, 0);
            this.aircraft_BUT2.Name = "aircraft_BUT2";
            this.aircraft_BUT2.Size = new System.Drawing.Size(75, 23);
            this.aircraft_BUT2.TabIndex = 1;
            this.aircraft_BUT2.Text = "2";
            this.aircraft_BUT2.UseVisualStyleBackColor = true;
            this.aircraft_BUT2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.aircraft_BUT2_MouseClick);
            // 
            // aircraft_BUT3
            // 
            this.aircraft_BUT3.Location = new System.Drawing.Point(0, 24);
            this.aircraft_BUT3.Name = "aircraft_BUT3";
            this.aircraft_BUT3.Size = new System.Drawing.Size(75, 23);
            this.aircraft_BUT3.TabIndex = 2;
            this.aircraft_BUT3.Text = "3";
            this.aircraft_BUT3.UseVisualStyleBackColor = true;
            this.aircraft_BUT3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.aircraft_BUT3_MouseClick);
            // 
            // aircraft_BUT4
            // 
            this.aircraft_BUT4.Location = new System.Drawing.Point(123, 24);
            this.aircraft_BUT4.Name = "aircraft_BUT4";
            this.aircraft_BUT4.Size = new System.Drawing.Size(75, 23);
            this.aircraft_BUT4.TabIndex = 3;
            this.aircraft_BUT4.Text = "4";
            this.aircraft_BUT4.UseVisualStyleBackColor = true;
            this.aircraft_BUT4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.aircraft_BUT4_MouseClick);
            // 
            // centerButton
            // 
            this.centerButton.Image = global::MissionPlanner.Properties.Resources._01_01;
            this.centerButton.Location = new System.Drawing.Point(81, 3);
            this.centerButton.Name = "centerButton";
            this.centerButton.Size = new System.Drawing.Size(35, 35);
            this.centerButton.TabIndex = 4;
            this.centerButton.Text = "1";
            this.centerButton.UseVisualStyleBackColor = true;
            // 
            // AircraftMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MissionPlanner.Properties.Resources.bgdark;
            this.Controls.Add(this.centerButton);
            this.Controls.Add(this.aircraft_BUT4);
            this.Controls.Add(this.aircraft_BUT3);
            this.Controls.Add(this.aircraft_BUT2);
            this.Controls.Add(this.aircraft_BUT1);
            this.Name = "AircraftMenuControl";
            this.Size = new System.Drawing.Size(199, 47);
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton aircraft_BUT1;
        private MyButton aircraft_BUT2;
        private MyButton aircraft_BUT3;
        private MyButton aircraft_BUT4;
        private MyButton centerButton;
    }
}
