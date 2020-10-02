namespace MissionPlanner.Controls.NewControls
{
    partial class ICECheck
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
            this.testButton = new MissionPlanner.Controls.MyButton();
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.startButton = new MissionPlanner.Controls.MyButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new BSE.Windows.Forms.ProgressBar();
            this.progressBar2 = new BSE.Windows.Forms.ProgressBar();
            this.progressBar3 = new BSE.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(321, 406);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(86, 23);
            this.testButton.TabIndex = 5;
            this.testButton.Text = "test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(136, 406);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(156, 23);
            this.myButton1.TabIndex = 4;
            this.myButton1.Text = "Пропустить";
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(136, 380);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(156, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Начать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 327);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.progressBar1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressBar1.Location = new System.Drawing.Point(0, 347);
            this.progressBar1.Maximum = 59;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(144, 30);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Text = "Полный";
            this.progressBar1.Value = 0;
            this.progressBar1.ValueColor = System.Drawing.Color.Lime;
            // 
            // progressBar2
            // 
            this.progressBar2.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.progressBar2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressBar2.Location = new System.Drawing.Point(144, 347);
            this.progressBar2.Maximum = 59;
            this.progressBar2.Minimum = 0;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(144, 30);
            this.progressBar2.TabIndex = 11;
            this.progressBar2.Text = "Малый";
            this.progressBar2.Value = 0;
            this.progressBar2.ValueColor = System.Drawing.Color.Cyan;
            // 
            // progressBar3
            // 
            this.progressBar3.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.progressBar3.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBar3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressBar3.Location = new System.Drawing.Point(289, 347);
            this.progressBar3.Maximum = 59;
            this.progressBar3.Minimum = 0;
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(144, 30);
            this.progressBar3.TabIndex = 12;
            this.progressBar3.Text = "Перегазовки";
            this.progressBar3.Value = 0;
            this.progressBar3.ValueColor = System.Drawing.Color.Cyan;
            // 
            // ICECheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Name = "ICECheck";
            this.Size = new System.Drawing.Size(432, 432);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton startButton;
        private System.Windows.Forms.Timer timer1;
        private MyButton myButton1;
        private MyButton testButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BSE.Windows.Forms.ProgressBar progressBar1;
        private BSE.Windows.Forms.ProgressBar progressBar2;
        private BSE.Windows.Forms.ProgressBar progressBar3;
    }
}
