namespace MissionPlanner.Controls.NewControls
{
    partial class TimerControl
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "00:00:00.0";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // timetButton
            // 
            this.timetButton.BackColor = System.Drawing.Color.Transparent;
            this.timetButton.BackgroundImage = global::MissionPlanner.Properties.Resources.icons8_timer;
            this.timetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.timetButton.FlatAppearance.BorderSize = 0;
            this.timetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timetButton.ForeColor = System.Drawing.Color.Transparent;
            this.timetButton.Location = new System.Drawing.Point(3, 0);
            this.timetButton.Name = "timetButton";
            this.timetButton.Size = new System.Drawing.Size(24, 24);
            this.timetButton.TabIndex = 1;
            this.timetButton.UseVisualStyleBackColor = false;
            this.timetButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // TimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timetButton);
            this.Name = "TimerControl";
            this.Size = new System.Drawing.Size(136, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button timetButton;
    }
}
